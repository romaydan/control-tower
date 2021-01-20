import { Component, Input, OnInit } from '@angular/core';
import IFacility from 'src/app/models/facility';

@Component({
  selector: 'app-facility-list',
  templateUrl: './facility-list.component.html',
  styleUrls: ['./facility-list.component.css'],
})
export class FacilityListComponent implements OnInit {
  @Input()
  facilities: IFacility[];
  constructor() {}

  ngOnInit(): void {}
}
