import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import account from '../models/account';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  constructor(private http: HttpClient) { }
  private accounturl: string = "https://localhost:44332/api/accounts";
  account : account;

  loadAccounts() {
    return this.http.get<account>(this.accounturl).pipe(
      map((res: any) => {
        let accounts: account[] = [];
        for (let i = 0, l = res.length; i < l; i++) {
          let a = res[i];
          let newA = new account(
            a.id,
            a.adressId,
            a.companyName,
            a.vatNumber,
            a.telephoneNumber,
            a.city,
            a.zip,
            a.street,
            a.number,
          a.country)

          accounts.push(newA);
        }
        return accounts;
      }));
  }

  deleteAccount(a: account): Observable<account> {
    this.httpOptions.body = a;
    return this.http.delete<account>(this.accounturl, this.httpOptions).pipe()
  }

  getAccount(id: any): Observable<account> {
    const url = `${this.accounturl}/${id}`;
    return this.http.get<account>(url).pipe();
  }

  updateAccount(account: account): Observable<any> {
    console.log(account);
    this.httpOptions.body = account;
    return this.http.put(this.accounturl, account, this.httpOptions);
    
  }


httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  body: this.account
}
}
