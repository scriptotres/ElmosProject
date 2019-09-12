import { Component, OnInit, Input, NgModule } from '@angular/core';
import { ConsultantsService } from '../../services/consultants.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { ChartModule } from '@progress/kendo-angular-charts';
import { SparklineModule } from '@progress/kendo-angular-charts';
import consultant from '../../models/consultant';

@NgModule
  ({
    imports: [ChartModule, SparklineModule]
  })
@Component({
  selector: 'app-contracts',
  templateUrl: './contracts.component.html',
  styleUrls: ['./contracts.component.scss'],

})
export class ContractsComponent implements OnInit {

  constructor(private consultantservice: ConsultantsService, private location: Location, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getConsultant()

  }

  public contracts: any;
  public consultant: any;
  public contractid: any;
  public currentcontractid: any;
  public currentcontract: any;
  public cont: any;
  getConsultant(): void {
    const id = this.route.snapshot.paramMap.get('id');

    this.consultantservice.getConsultant(id)
      .subscribe(data => [
        console.log(data),
        this.consultant = data,
        this.contracts = data.contracts,
        this.currentcontractid = this.consultant.currentContract.id,
        this.compareContracts(this.contracts),
      ]);

  }
  compareContracts(contracts): void {
    for (let o of contracts) {
      this.contractid = o.id;
      //this.cont = o;
      console.log(this.contractid);
      if (this.contractid == this.currentcontractid) {
  //      this.currentcontract = this.cont;
        console.log(this.currentcontract);
      //  this.currentContract();
      }
      else {
        console.log("not same");
      }
    }


  }
  currentContract(contract) {

      if (contract.id == this.currentcontractid) {
        let bool = true;
        return bool;
      

    }
  }

  goToDetails() {
    const id = this.route.snapshot.paramMap.get('id');
    this.router.navigateByUrl('consultants/details/' + id);
  }
  goBack(): void {
    this.location.back();
  }
}
