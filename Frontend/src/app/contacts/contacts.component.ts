import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { Contact } from '../models/contact';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {
  contacts: Contact[] = [];
  errorMessage: string | null = null;

  constructor(private contactService: ContactService, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['/login']);
      return;
    }

    this.contactService.getContacts().subscribe((data: Contact[]) => {
      this.contacts = data;
    }, error => {
      this.errorMessage = 'Failed to load contacts. Please try again later.';
    });
  }

  addContact(): void {
    this.router.navigate(['/contacts/new']);
  }
}
