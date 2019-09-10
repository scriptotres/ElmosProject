import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import account from '../models/account';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  constructor(private http: HttpClient) { }
  private accounturl: string = "https://localhost:44332/api/accounts";

  loadAccounts() {
    return this.http.get<account>(this.accounturl).pipe(
      map((res: any) => {
        let accounts: account[] = [];
        for (let i = 0, l = res.length; i < l; i++) {
          let a = res[i];
          let newA = new account(
            a.id,
            a.companyName,
            a.vatNumber,
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

  getAccount(id: any): Observable<account> {
    const url = `${this.accounturl}/${id}`;
    return this.http.get<account>(url).pipe();
  }
}
