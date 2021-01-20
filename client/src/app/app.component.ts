import { Component, OnInit } from '@angular/core';
import IFacility from './models/facility';
import IMessage from './models/message';
import IPlane from './models/Plane';
import ITimer from './models/timer';
import { SignalRService } from './services/signal-r.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent  {
  title = 'ControlTower';
  messages: IMessage[];
  landings: IPlane[];
  takeoffs: IPlane[];
  facilites: IFacility[];
  constructor(private signalR: SignalRService) {
    this.subscribeToEvents();
  }

  createPlane() {
    this.signalR.createPlane();
  }
  subscribeToEvents() {
    this.messages = [];
    this.signalR.NotificationRecieved.subscribe((message) => {
      this.messages.push(message);
    });
    this.signalR.NewLandings.subscribe((landings) => {
      this.landings = landings;
    });
    this.signalR.NewTakeoff.subscribe((takeoffs) => {
      this.takeoffs = takeoffs;
    });
    this.signalR.FacilitiesUpdate.subscribe((facilities) => {
      this.facilites = facilities;
    });
  }
  autoGenerate(timer: ITimer) {

    this.signalR.autoPlaneGenrate(timer.toggle, timer.interval);
  }
}
