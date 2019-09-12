import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ConsultantsComponent } from './consultants/consultants.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { EmployeesComponent } from './employees/employees.component';
import { ConsultantDetailsComponent } from './consultants/consultant-details/consultant-details.component';
import { ContractsComponent } from './consultants/contracts/contracts.component';
import { ConsultantEmployeeComponent } from './consultants/consultant-employee/consultant-employee.component';
import { AccountsComponent } from './accounts/accounts.component';
import { AccountDetailsComponent } from './accounts/account-details/account-details.component';
import { EmployeeDetailsComponent } from './employees/employee-details/employee-details.component';

const routes: Routes = [{
  path: '', pathMatch: 'full', component: HomeComponent 
},
  { path: 'consultants', component: ConsultantsComponent },
  { path: 'employees', component: EmployeesComponent },
  { path: 'accounts', component: AccountsComponent },
  { path: 'consultants/details/:id', component: ConsultantDetailsComponent },
  { path: 'consultants/contracts/:id', component: ContractsComponent },
  { path: 'consultants/employees/:id', component: ConsultantEmployeeComponent },
  { path: 'klant/details/:id', component: AccountDetailsComponent },
  { path: 'employee/details/:id', component: EmployeeDetailsComponent }
  
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
