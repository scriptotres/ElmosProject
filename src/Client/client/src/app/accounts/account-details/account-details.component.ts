import { Component, OnInit, Input } from '@angular/core';
import { AccountsService } from '../../services/accounts.service';
import { ActivatedRoute, Router } from '@angular/router';
import account from '../../models/account';
import { Location } from '@angular/common';


@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.scss']
})
export class AccountDetailsComponent implements OnInit {
  @Input() account: account;

  constructor(private accountservice: AccountsService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit() {
    this.getAccount();
  }

  getAccount(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.accountservice.getAccount(id)
      .subscribe(a => [
        this.account = a,
        console.log(this.account)
        ]);
  }

  updateAccount(): void {
    let id = this.route.snapshot.paramMap.get('id');
    this.account.id = id;
    this.accountservice.updateAccount(this.account)
      .subscribe(a => [
        this.account = a,
        console.log(this.account), this.goBack()
      ]);
  }

  goBack(): void {
    this.location.back();
  }
}
