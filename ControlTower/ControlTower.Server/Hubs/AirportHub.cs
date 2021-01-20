using ControlTower.BL.Api;
using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.DTOs;
using ControlTower.Common.Models.Planes;
using ControlTower.Generator;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlTower.Server.Hubs
{
    public class AirportHub : Hub
    {
        private readonly IAirportMediator airportService;
        private readonly IPlaneGenerator generator;
        private readonly INotificationService notification;
        private readonly ISystemSnapshot systemSnapshot;

        public AirportHub(IAirportMediator airportService, IPlaneGenerator generator, INotificationService notification, ISystemSnapshot systemSnapshot)
        {
            this.airportService = airportService;
            this.generator = generator;
            this.notification = notification;
            this.systemSnapshot = systemSnapshot;
            notification.OnSendMessage += SendNotification;
            notification.OnChangeInLandings += UpdateBillBoard;
            notification.AirportState += SendAirportState;

        }

        private async void SendAirportState(IList<FacilityDTO> facilities)
        {
            if (facilities != null)
            {
                await Clients.All.SendAsync("FacilitiesUpdate", facilities);
            }
        }

        private async void UpdateBillBoard()
        {
            var landings = PlaneDTO.CollectionToDTOs(systemSnapshot.GetLandings());
            var takeoffs = PlaneDTO.CollectionToDTOs(systemSnapshot.GetTakeoffs());
            await Clients.All.SendAsync("NewBoardChange", landings, takeoffs);

        }

        //public async void CreatePlane()
        //{
        //    await generator.CreatePlane<PassengerPlane>();
        //}
        public async void SendNotification(string message)
        {
            await Clients.All.SendAsync("NewNotification", message);
        }
        public void ToggleAutoPlanes(bool data,int num)
        {
            generator.ToggleAutoPlanes(data,num);
        }
    }
}
