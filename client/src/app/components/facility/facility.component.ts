import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  Input,
} from '@angular/core';
import IFacility from 'src/app/models/facility';

@Component({
  selector: 'app-facility',
  templateUrl: './facility.component.html',
  styleUrls: ['./facility.component.css'],
})
export class FacilityComponent implements OnInit {
  @Input()
  facility: IFacility;
  flightNumber: string;
  constructor() {}
  ngOnInit(): void {
    if (this.facility.plane !== null) {
      this.flightNumber = this.facility.plane.flightNumber;
    } else {
      this.flightNumber = '';
    }
  }
}
