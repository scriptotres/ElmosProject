import { Component, OnInit, Input } from '@angular/core';
import consultant from '../../models/consultant';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConsultantsService } from '../../services/consultants.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Location } from '@angular/common';
import { error } from 'util';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-consultant-details',
  templateUrl: './consultant-details.component.html',
  styleUrls: ['./consultant-details.component.scss']
})
export class ConsultantDetailsComponent implements OnInit {
  @Input() consultant: consultant;
  editForm: FormGroup;

  constructor(private consultantservice: ConsultantsService, private route: ActivatedRoute, private location: Location, private router: Router) {
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
  }

  getConsultant(): void {
    const id = this.route.snapshot.paramMap.get('id');

    this.consultantservice.getConsultant(id)
      .subscribe(c => this.consultant = c);
  }


  deleteConsultant(): void {

    if (confirm(`ben je zeker dat je consultant ${this.consultant.firstname} ${this.consultant.lastname} wilt verwijderen?`)) {
      let id = this.route.snapshot.paramMap.get('id');
      this.consultant.id = id;
      this.consultantservice.deleteConsultant(this.consultant)
        .subscribe(() => this.goBack());
    }
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
    let id = this.route.snapshot.paramMap.get('id');

    this.router.navigateByUrl('consultants/contracts/' + id);
  }

  goBack(): void {
    this.location.back();
  }


}
