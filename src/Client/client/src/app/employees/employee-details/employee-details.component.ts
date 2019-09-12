import { Component, OnInit, Input } from '@angular/core';
import employee from '../../models/employee';
import { ActivatedRoute } from '@angular/router';
import { EmployeesService } from '../../services/employees.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.scss']
})
export class EmployeeDetailsComponent implements OnInit {
  @Input() employee: employee;

  constructor(private employeeservice: EmployeesService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getEmployee();
  }
  getEmployee():void {
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeservice.getEmployee(id)
      .subscribe(a => [
        this.employee = a,
        console.log(this.employee)
      ]);
  }
}
