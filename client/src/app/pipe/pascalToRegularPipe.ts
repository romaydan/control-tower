import { Pipe, PipeTransform } from '@angular/core';
@Pipe({ name: 'PascalToRegular' })
export class PascalToRegularPipe implements PipeTransform {
  transform(value: string): string {
    return value.replace(/([A-Z][a-z])/g, ' $1');
  }
}
