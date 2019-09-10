import { Component, OnInit, Input, NgModule } from '@angular/core';
import { ConsultantsService } from '../../services/consultants.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { ChartModule } from '@progress/kendo-angular-charts';
import { SparklineModule } from '@progress/kendo-angular-charts';

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
  public marge: any;
  getConsultant(): void {
    const id = this.route.snapshot.paramMap.get('id');

    this.consultantservice.getConsultant(id)
      .subscribe(data => [
        console.log(data),
        this.consultant = data,
        this.contracts = data.contracts
        , console.log(this.contracts), this.marge = (this.contracts.sellingPrice - this.contracts.purchasePrice)
       , console.log(this.marge)
      ]);
    //todo contracts vergelijken met currentcontract en dit in andere kleur zetten
  }



  goBacktoMenu(): void {
    this.router.navigate(['/consultants']);

  }
  goBack(): void {
    this.location.back();
  }
}
