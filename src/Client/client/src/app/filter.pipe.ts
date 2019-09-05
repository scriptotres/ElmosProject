import { Pipe, PipeTransform } from '@angular/core';
import consultant from './models/consultant';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {
  searchLastname: string;


  transform(values: consultant[], searchLastname: string): any {

    if (!values) return;
    if (searchLastname == undefined || searchLastname === "") return values;

    return values.filter(items => items.lastname.toLowerCase().indexOf(searchLastname.toLowerCase()) !== -1)
  }
}
