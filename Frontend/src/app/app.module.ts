import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactsComponent } from './contacts/contacts.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';


import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './services/token-interceptor.service';
import { NavbarComponent } from './navbar/navbar.component';
import { LogoutComponent } from './logout/logout.component';
import { AddContactComponent } from './add-contact/add-contact.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactsComponent,
    ContactDetailsComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    LogoutComponent,
    AddContactComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
