import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { ChartsModule } from '@progress/kendo-angular-charts';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConsultantsComponent } from './consultants/consultants.component';
import { HomeComponent } from './home/home.component';
import { AccountsComponent } from './accounts/accounts.component';
import { EmployeesComponent } from './employees/employees.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConsultantDetailsComponent } from './consultants/consultant-details/consultant-details.component';
import { ContractsComponent } from './consultants/contracts/contracts.component';
import { FilterPipe } from './filter.pipe';
import { ConsultantEmployeeComponent } from './consultants/consultant-employee/consultant-employee.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import 'hammerjs';
import { AccountDetailsComponent } from './accounts/account-details/account-details.component';
import { EmployeeDetailsComponent } from './employees/employee-details/employee-details.component';



@NgModule({
  declarations: [
    AppComponent,
    ConsultantsComponent,
    HomeComponent,
    AccountsComponent,
    EmployeesComponent,
    ConsultantDetailsComponent,
    ContractsComponent,
    FilterPipe,
    ConsultantEmployeeComponent,
    AccountDetailsComponent,
    EmployeeDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, ReactiveFormsModule, ChartsModule, BrowserAnimationsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
