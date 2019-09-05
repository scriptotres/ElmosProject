import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { ConsultantsService } from '../services/consultants.service';

import { Router } from '@angular/router';
import consultant from '../models/consultant';
@Component({
  selector: 'app-conusltants',
  templateUrl: './consultants.component.html',
  styleUrls: ['./consultants.component.scss']
})

export class ConsultantsComponent implements OnInit {
  @Input() consultant: consultant;
  @Output() remove: EventEmitter<consultant>;
  consultants: consultant[];
  
  public show: boolean = false;

  constructor( private consultantservice: ConsultantsService, private router: Router) { 
    this.remove = new EventEmitter;


  }

  getConsultants(): void  {
    this.consultantservice.loadConsultants().subscribe((consultantservice) => this.consultants = consultantservice);
   
  }

  toggle() {
    //let consultants = this.getConsultants();
    this.show = !this.show;

  }

  goToDetails(c: consultant) {
    this.router.navigateByUrl('consultants/details/'+c.id);
  }


  ngOnInit(): void {
    this.getConsultants();
  }

}
