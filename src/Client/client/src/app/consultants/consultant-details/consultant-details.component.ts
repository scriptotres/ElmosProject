import { Component, OnInit, Input } from '@angular/core';
import consultant from '../../models/consultant';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConsultantsService } from '../../services/consultants.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Location } from '@angular/common';
import { error } from 'util';
import { HttpErrorResponse } from '@angular/common/http';
import { EmployeesService } from '../../services/employees.service';
import employee from '../../models/employee';


@Component({
  selector: 'app-consultant-details',
  templateUrl: './consultant-details.component.html',
  styleUrls: ['./consultant-details.component.scss']
})
export class ConsultantDetailsComponent implements OnInit {
  @Input() consultant: consultant;

  editForm: FormGroup;

  constructor(private employeeservice: EmployeesService, private consultantservice: ConsultantsService, private route: ActivatedRoute, private location: Location, private router: Router) {
    //this.editForm = this.formBuilder.group({
    //  firstname: [''],
    //  lastname: [''],
    //  email: [''],
    //  workemail: [''],
    //  birthdate: [''],
    //  mobile: [''],
    //  telephone: [''],
    //  street:[''],
    //  number: [''],
    //  city: [''],
    //  zip: [''],
    //  country:['']
    //  //TODO: required toevoegen
    //});
  }

  ngOnInit() {
    this.getConsultant();
    this.getEmployees();
  }
  public employees: any;
  public employeeofconsultant: any;

  getConsultant(): void {
    const id = this.route.snapshot.paramMap.get('id');

    this.consultantservice.getConsultant(id)
      .subscribe(c => [this.consultant = c, this.consultant.employeeId, console.log(this.consultant),
      this.getEmployee(this.consultant.employeeId)]);
  }

  getEmployee(idEmployee): void {
    const id = idEmployee;
    this.employeeservice.getEmployee(id).subscribe(e => [this.employeeofconsultant = e,
      console.log(this.employeeofconsultant)
    ]);
  }


  getEmployees(): void {
    this.employeeservice.loadEmployees()
      .subscribe(e => [this.employees = e,
      console.log(this.employees)
      ]);
  }
  deleteConsultant(): void {

    if (confirm(`ben je zeker dat je consultant ${this.consultant.firstname} ${this.consultant.lastname} wilt verwijderen?`)) {
      let id = this.route.snapshot.paramMap.get('id');
      this.consultant.id = id;
      this.consultantservice.deleteConsultant(this.consultant)
        .subscribe(() => this.goBack());
    }
  }

  updateEmployee(employeeId): void {
    let id = this.route.snapshot.paramMap.get('id');
    this.consultant.employeeId = employeeId;
    this.consultant.id = id;
    this.consultantservice.updateConsultant(this.consultant)
      .subscribe((data)=>window.location.reload())
}


  updateConsultant(): void {
    let id = this.route.snapshot.paramMap.get('id');
    this.consultant.id = id;
    this.consultantservice.updateConsultant(this.consultant)
      .subscribe((data) => {
        console.log(data);
        this.goBack();
      }, (err: HttpErrorResponse) => {
        console.log(err.message);
      });
  }

  viewContracts() {

    const id = this.route.snapshot.paramMap.get('id');
    this.router.navigateByUrl('consultants/contracts/' + id);
  }
  viewEmployees() {
    const id = this.route.snapshot.paramMap.get('id');

    this.router.navigateByUrl('consultants/employees/' + id);
  }
  goBack(): void {
    this.location.back();
  }



}
