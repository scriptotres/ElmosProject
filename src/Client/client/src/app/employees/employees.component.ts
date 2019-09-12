import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../services/employees.service';
import employee from '../models/employee';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  employees: any;

  constructor(private employeeservice: EmployeesService, private router: Router) { }

  getEmployees(): void {
    this.employeeservice.loadEmployees()
      .subscribe((employeeservice) => [this.employees = employeeservice, console.log(this.employees)]);
  }
  goToDetails(e: employee) {
    this.router.navigateByUrl('employee/details/' + e.id);
  }
    ngOnInit():void {
      this.getEmployees();
    }

  }

