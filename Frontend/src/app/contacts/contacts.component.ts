import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { Contact } from '../models/contact';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {
  contacts: Contact[] = [];

  constructor(private contactService: ContactService, private router: Router) { }

  ngOnInit(): void {
    this.contactService.getContacts().subscribe((data: Contact[]) => {
      this.contacts = data;
    });
  }

  addContact(): void {
    this.router.navigate(['/contacts/new']);
  }
}
