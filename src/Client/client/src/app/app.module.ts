import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConsultantsComponent } from './consultants/consultants.component';
import { HomeComponent } from './home/home.component';
import { AccountsComponent } from './accounts/accounts.component';
import { EmployeesComponent } from './employees/employees.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConsultantDetailsComponent } from './consultants/consultant-details/consultant-details.component';
import { ContractsComponent } from './consultants/contracts/contracts.component';

@NgModule({
  declarations: [
    AppComponent,
    ConsultantsComponent,
    HomeComponent,
    AccountsComponent,
    EmployeesComponent,
    ConsultantDetailsComponent,
    ContractsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
