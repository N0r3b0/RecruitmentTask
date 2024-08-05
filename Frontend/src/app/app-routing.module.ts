import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ContactsComponent } from './contacts/contacts.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LogoutComponent } from './logout/logout.component';
import { AddContactComponent } from './add-contact/add-contact.component';



const routes: Routes = [
  { path: '', redirectTo: '/contacts', pathMatch: 'full' },
  { path: 'contacts', component: ContactsComponent },
  { path: 'contacts/new', component: AddContactComponent },
  { path: 'contacts/:id', component: ContactDetailsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'logout', component: LogoutComponent } 
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
