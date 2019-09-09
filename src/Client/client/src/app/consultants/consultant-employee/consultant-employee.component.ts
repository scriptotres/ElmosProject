import { Component, OnInit, Input } from '@angular/core';
import { ConsultantsService } from '../../services/consultants.service';
import { EmployeesService } from '../../services/employees.service';
import { ActivatedRoute, Router } from '@angular/router';
import consultant from '../../models/consultant';
import { Location } from '@angular/common';


@Component({
  selector: 'app-consultant-employee',
  templateUrl: './consultant-employee.component.html',
  styleUrls: ['./consultant-employee.component.scss']
})
export class ConsultantEmployeeComponent implements OnInit {
  @Input() consultant: consultant;

  constructor(private consultantservice: ConsultantsService, private employeeservice: EmployeesService, private location: Location, private router: Router, private route: ActivatedRoute) { }
  employees: any;
  ngOnInit() {
    this.getConsultant();
    this.getEmployees();

  }

  getConsultant(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.consultantservice.getConsultant(id)
      .subscribe(c => this.consultant = c);

    //todo contracts vergelijken met currentcontract en dit in andere kleur zetten
  }
  getEmployees(): void {
    this.employeeservice.loadEmployees().subscribe((employeeservice) => this.employees = employeeservice);
  }

  selectEmployee(employeeID:any): void {
    let id = this.route.snapshot.paramMap.get('id');
    this.consultant.id = id;
    this.consultant.employeeId = employeeID;
    this.consultantservice.updateConsultant(this.consultant)
      .subscribe((data) => this.goBack())
  }


  goBacktoMenu(): void {
    this.router.navigate(['/consultants']);

  }
  goBack(): void {
    this.location.back();
  }
}
