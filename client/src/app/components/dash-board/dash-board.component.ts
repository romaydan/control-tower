import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import ITimer from 'src/app/models/timer';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css'],
})
export class DashBoardComponent implements OnInit {

  @Output() generatePlane = new EventEmitter();
  @Output() autoGeneratePlane = new EventEmitter<ITimer>();
  interval: number;


  constructor() {
    this.interval = 7;
  }

  ngOnInit(): void {}
  autoPlane(e) {
    const timer: ITimer = {
      toggle: e.checked,
      interval: this.interval,
    };
    this.autoGeneratePlane.emit(timer);
  }
}
