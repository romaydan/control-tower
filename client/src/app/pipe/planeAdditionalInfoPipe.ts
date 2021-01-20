import { Pipe, PipeTransform } from '@angular/core';
import IPlane from '../models/Plane';
@Pipe({ name: 'planeAdditionalInfo' })
export class PlaneAdditionalInfoPipe implements PipeTransform {
  transform(plane: IPlane): string {
    if (plane.planeType === 'PassengerPlane') {
      return plane.additionalInfo + ' Passengers 🧍';
    } else if (plane.planeType === 'CargoPlane') {
      return plane.additionalInfo + ' Tons 📦';
    }
    return plane.additionalInfo.toString();
  }
}
