using ControlTower.BL.Api;
using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.DTOs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.BL.Services
{
    public class NotificationService : INotificationService
    {
        public Action<string> OnSendMessage { get; set; }
        public Action OnChangeInLandings { get; set; }
        public Action<IList<FacilityDTO>> AirportState { get; set; }

        public void SendMessage(string message)
        {
            OnSendMessage?.Invoke(message);
        }
        public void UpdateBoard()
        {
            OnChangeInLandings?.Invoke();
        }
        void INotificationService.UpdateAirportState(IList<FacilityDTO> facilities)
        {
            AirportState?.Invoke(facilities);
        }
    }
}
