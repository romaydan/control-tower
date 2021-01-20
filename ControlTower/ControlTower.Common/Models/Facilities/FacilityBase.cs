using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlTower.Common.Models.Facilities
{
    public abstract class FacilityBase : IFacility
    {

        public event EventHandler FacilityIsEmpty;
        public int Id { get; set; }
        public IPlane Plane { get; set; }
        public bool IsEmpty { get => Plane == null; }
        protected TimeSpan TaskTime { get; set; }
        public IList<Type> PrevTypes { get; set; }
        public IList<IFacility> NextFacilities { get; set; }
        public Action<IFacility> SaveState { get; set; }
        public Action<string> SendMessage { get; set; }
        public Action<IFacility, IFacility, IPlane> SaveHistory { get; set; }
        private object obj;
        private List<IFacility> fullFacilities;

        public FacilityBase()
        {
            PrevTypes = new List<Type>();
            NextFacilities = new List<IFacility>();
            obj = new object();
            fullFacilities = new List<IFacility>();
        }

        public virtual void PlaneArrival(IPlane plane)
        {
            if (Plane == null)
            {
                AcceptPlane(plane);
                SpecialOperation(plane);
                if (NextFacilities.Count != 0)
                {
                    Redirect(plane, NextFacilities);
                }
                else
                {
                    Plane = null;
                    SaveState?.Invoke(this);
                }
            }

        }

        private void RedirectFacilityHandler(object sender, EventArgs e)
        {
            if (sender != null && sender is IFacility)
            {
                IFacility facility; facility = sender as IFacility;
                if (Plane != null && facility.Plane == null)
                    RemovePlaneAndRedirect(Plane, facility);
            }
        }

        private void RemovePlaneAndRedirect(IPlane plane, IFacility facility)
        {
            lock (obj)
            {
                RemoveEvents();
                Plane = null;
                Task.Run(() => SaveHistory?.Invoke(this, facility, plane));
                Task.Run(() => FacilityIsEmpty?.Invoke(this, EventArgs.Empty));
                facility.PlaneArrival(plane);
            }
        }

        private void RemoveEvents()
        {
            fullFacilities.ForEach(ff =>
            {
                ff.FacilityIsEmpty -= RedirectFacilityHandler;
            });
        }

        private bool AcceptPlane(IPlane plane)
        {
            bool flag = false;
            if (IsEmpty && plane != null)
            {
                Plane = plane;
                SaveState?.Invoke(this);
                flag = true;
            }
            return flag;
        }

        protected virtual void Redirect(IPlane plane, IList<IFacility> facilities)
        {

            lock (obj)
            {
                foreach (var facility in facilities)
                {
                    lock (obj)
                    {
                        if (facility.IsEmpty)
                        {
                            RemovePlaneAndRedirect(plane, facility);
                            return;
                        }
                        else
                            fullFacilities.Add(facility);
                    }
                }
                if (fullFacilities.Count > 0)
                {
                    fullFacilities.ForEach(f => f.FacilityIsEmpty += RedirectFacilityHandler);
                }
            }
        }

        protected abstract void SpecialOperation(IPlane plane);
    }
}
