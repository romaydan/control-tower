import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
import { Subject } from 'rxjs';
import IFacility from '../models/facility';
import IMessage from '../models/message';
import IPlane from '../models/Plane';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  url = 'http://localhost:34256/hub';
  private connection: HubConnection;
  NotificationRecieved: Subject<IMessage>;
  NewLandings: Subject<IPlane[]>;
  NewTakeoff: Subject<IPlane[]>;
  FacilitiesUpdate: Subject<IFacility[]>;

  constructor() {
    this.NotificationRecieved = new Subject<IMessage>();
    this.NewLandings = new Subject<IPlane[]>();
    this.NewTakeoff = new Subject<IPlane[]>();
    this.NewTakeoff = new Subject<IPlane[]>();
    this.FacilitiesUpdate = new Subject<IFacility[]>();

    this.createConnection();
    this.registerOnServerEvents();
    this.start();
  }

  private registerOnServerEvents() {
    this.connection.on('NewNotification', (message) =>
      this.NotificationRecieved.next({ content: message, date: new Date() })
    );
    this.connection.on(
      'NewBoardChange',
      (landings: IPlane[], takeoffs: IPlane[]) => {
        this.NewLandings.next(landings);
        this.NewTakeoff.next(takeoffs);
      }
    );
    this.connection.on('FacilitiesUpdate', (facilities: IFacility[]) => {
      this.FacilitiesUpdate.next(facilities);
    });

    this.connection.onclose(() => {
      this.start();
    });
  }
  private createConnection() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(this.url)
      .build();
  }
  private async start() {
    await this.connection.start();
    console.log('SignalR Connected.');
  }
  public async createPlane() {
    await this.connection.invoke('CreatePlane');
  }
  public async autoPlaneGenrate(bool: boolean, interval: number) {
    await this.connection.invoke('ToggleAutoPlanes', bool, interval);
  }
}
