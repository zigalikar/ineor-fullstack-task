import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
  name: 'times',
})
export class TimesPipe implements PipeTransform {
  transform(value: number) {
    return new Array(Math.ceil(value)).fill(1);
  }
}
