using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.BL.Api
{
    public interface INotificationService
    {
        public Action<string> OnSendMessage { get; set; }
        public Action OnChangeInLandings { get; set; }
        public Action<IList<FacilityDTO>> AirportState { get; set; }
        public void UpdateAirportState(IList<FacilityDTO> facilities);
        void SendMessage(string message);
        void UpdateBoard();
}
}
