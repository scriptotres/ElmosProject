import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import employee from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }
  private employeesurl: string = "https://localhost:44332/api/Employees";
  employee: employee;

  loadEmployees() {
    return this.http.get<employee>(this.employeesurl).pipe(
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
        return employees;

      }));

  }

  getEmployee(id: any): Observable<employee> {
    const url = `${this.employeesurl}/${id}`;
    return this.http.get<employee>(url).pipe();
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    body: this.employee
  }
}
