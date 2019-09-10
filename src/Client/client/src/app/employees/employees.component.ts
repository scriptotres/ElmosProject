import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../services/employees.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  employees: any;

  constructor(private employeeservice: EmployeesService) { }

  getEmployees(): void {
    this.employeeservice.loadEmployees()
      .subscribe((employeeservice) => [this.employees = employeeservice, console.log(this.employees)]);
  }
    ngOnInit():void {
      this.getEmployees();
    }

  }

