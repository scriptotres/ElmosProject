import { Component, OnInit } from '@angular/core';
import { AccountsService } from '../services/accounts.service';
import account from '../models/account';
import { Router } from '@angular/router';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.scss']
})
export class AccountsComponent implements OnInit {
  accounts: any;

  constructor(private accountservice: AccountsService, private router: Router) { }



  getAccounts(): void {
    this.accountservice.loadAccounts()
      .subscribe((accountservice) => [this.accounts = accountservice, console.log(this.accounts)]);
  }

  deleteAccount(a: account): void {

    if (confirm(`ben je zeker dat je bedrijf ${a.companyname} wilt verwijderen?`)) {

      this.accountservice.deleteAccount(a).subscribe((data) => window.location.reload())
    }
  }

  goToDetails(a: account) {
    this.router.navigateByUrl('klant/details/' + a.id);
  }
  ngOnInit() {
    this.getAccounts();
  }
}
