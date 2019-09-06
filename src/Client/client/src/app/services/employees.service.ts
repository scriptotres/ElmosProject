import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import employee from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }

  loadEmployees() {
    return this.http.get<employee>('https://localhost:44332/api/Employees').pipe(
      map((res: any) => {
        let employees: employee[] = [];
        for (let i = 0, l = res.length; i < l; i++) {
          let e = res[i];
          let newE = new employee(
            e.id,
            e.firstname,
            e.lastname,
            e.middlename,
            e.birthdate,
            e.email,
            e.telephone);

          employees.push(newE);
        }
//      console.log(employees);
        return employees;

      }));
  }
}
