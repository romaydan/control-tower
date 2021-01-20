import { Component, Input, OnInit } from '@angular/core';
import IPlane from 'src/app/models/Plane';
import { SignalRService } from 'src/app/services/signal-r.service';

@Component({
  selector: 'app-plane-board',
  templateUrl: './plane-board.component.html',
  styleUrls: ['./plane-board.component.css'],
})
export class PlaneBoardComponent implements OnInit {
  displayedColumns = ['flightNumber', 'type', 'weight'];
  @Input()
  planes: IPlane[];
  @Input()
  title: string;
  @Input()
  imageUrl: string;
  constructor() {}
  ngOnInit(): void {}
}
