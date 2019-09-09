import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, tap } from 'rxjs/operators';
import consultant from '../models/consultant';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})



export class ConsultantsService {
  private consultantsurl: string = "https://localhost:44332/api/Consultants";

  consultant: consultant;
  constructor(private http: HttpClient) { }

  loadConsultants() {
    return this.http.get<consultant>(this.consultantsurl).pipe(
      map((res: any) => {
        let consultants: consultant[] = [];
        for (let i = 0, l = res.length; i < l; i++) {
          let c = res[i];
          let newC = new consultant(
            c.id,
            c.firstname,
            c.lastname,
            c.birthdate,
            c.email,
            c.workEmail,
            c.telephone,
            c.mobile,
            c.address.id,
            c.address.street,
            c.address.number,
            c.address.city,
            c.address.country,
            c.address.zip,
            c.employeeId,
            c.currentContract,
            c.contracts,
          );

          consultants.push(newC);
        }
        console.log(consultants);
        return consultants;

      }));
  }

  getConsultant(id: any): Observable<consultant> {
    const url = `${this.consultantsurl}/${id}`;
    return this.http.get<consultant>(url).pipe();
  }

  updateConsultant(consultant: consultant): Observable<any> {
    console.log(consultant);
    this.httpOptions.body = consultant;
    return this.http.put(this.consultantsurl, consultant, this.httpOptions);
  }

  deleteConsultant(consultant: consultant): Observable<any> {
    this.httpOptions.body = consultant;
    return this.http.delete<consultant>(this.consultantsurl, this.httpOptions).pipe()
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    body: this.consultant
  }

}






