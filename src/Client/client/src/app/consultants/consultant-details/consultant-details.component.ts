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
import { AccountsService } from '../../services/accounts.service';


@Component({
  selector: 'app-consultant-details',
  templateUrl: './consultant-details.component.html',
  styleUrls: ['./consultant-details.component.scss']
})
export class ConsultantDetailsComponent implements OnInit {
  @Input() consultant: consultant;

  editForm: FormGroup;

  constructor(private accountservice: AccountsService, private employeeservice: EmployeesService, private consultantservice: ConsultantsService, private route: ActivatedRoute, private location: Location, private router: Router) {
  }

  ngOnInit() {
    this.getConsultant();
    this.getEmployees();
    this.getAccounts();
  }
  public employees: any;
  public accounts: any;
  public employeeofconsultant: any;
  public accountofconsultant: any;

  getConsultant(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.consultantservice.getConsultant(id)
      .subscribe(c => [
        this.consultant = c,
        console.log(this.consultant),
        this.getAccount( this.consultant.accountId),
        this.getEmployee(this.consultant.employeeId),
        this.consultant.birthdate = this.consultant.birthdate.slice(0, 10),
        this.consultant.currentContract.endDate = this.consultant.currentContract.endDate.slice(0, 10),
        this.consultant.currentContract.startDate = this.consultant.currentContract.startDate.slice(0, 10),
        this.consultant.currentContract.signedDate = this.consultant.currentContract.signedDate.slice(0,10)]);
  }

  getEmployees(): void {
    this.employeeservice.loadEmployees()
      .subscribe(e => [this.employees = e]);
  }

  getAccounts(): void {
    this.accountservice.loadAccounts()
      .subscribe(e => [this.accounts = e]);
  }


  getAccount(idAccount): void {
    const id = idAccount;
    this.accountservice.getAccount(id).subscribe(a => [this.accountofconsultant = a]);
  }

  getEmployee(idEmployee): void {
    const id = idEmployee;
    this.employeeservice.getEmployee(id).subscribe(e => [this.employeeofconsultant = e
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
  updateAccount(accountId): void {
    let id = this.route.snapshot.paramMap.get('id');
    this.consultant.accountId = accountId;
    this.consultant.id = id;
    this.consultantservice.updateConsultant(this.consultant)
      .subscribe((data) => window.location.reload())
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

  viewEmployees() {
    const id = this.route.snapshot.paramMap.get('id');

    this.router.navigateByUrl('consultants/employees/' + id);
  }
  goBack(): void {
    this.location.back();
  }



}
