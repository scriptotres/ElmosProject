import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { ConsultantsService } from '../services/consultants.service';
import { FilterPipe } from '../filter.pipe'
import { Router } from '@angular/router';
import consultant from '../models/consultant';
@Component({
  selector: 'app-conusltants',
  templateUrl: './consultants.component.html',
  styleUrls: ['./consultants.component.scss'],
  providers: [FilterPipe]
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
    this.consultantservice.loadConsultants().subscribe((consultantservice) => [this.consultants = consultantservice, console.log(this.consultants)]);
   
  }

  goToDetails(c: consultant) {
    this.router.navigateByUrl('consultants/contracts/' + c.id);
  }



  ngOnInit(): void {
    this.getConsultants();
  }

}
