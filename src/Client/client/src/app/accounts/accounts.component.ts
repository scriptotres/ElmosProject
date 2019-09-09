import { Component, OnInit } from '@angular/core';
import { AccountsService } from '../services/accounts.service';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.scss']
})
export class AccountsComponent implements OnInit {
  accounts: any;

  constructor(private accountservice: AccountsService) { }



  getAccounts(): void {
    this.accountservice.loadAccounts()
      .subscribe((accountservice) => [this.accounts = accountservice, console.log(this.accounts)]);
  }
  ngOnInit() {
    this.getAccounts();
  }
}
