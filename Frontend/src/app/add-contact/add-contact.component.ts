import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContactService } from '../services/contact.service';
import { Contact } from '../models/contact';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {
  contact: Contact = {
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    category: 'Personal',
    subCategory: '',
    phoneNumber: '',
    birthDate: ''
  };
  errorMessage: string | null = null;

  constructor(
    private contactService: ContactService,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['/login']);
    }
  }

  save(): void {
    if (!this.authService.isAuthenticated()) {
      this.errorMessage = 'You must be logged in to add a contact.';
      return;
    }

    this.contact.birthDate = new Date(this.contact.birthDate).toISOString(); // UTC conversion
    this.contactService.createContact(this.contact).subscribe(() => this.router.navigate(['/contacts']),
      (error) => {
        this.errorMessage = 'Failed to save contact. Please try again.';
        this.contact.birthDate = this.contact.birthDate.split('T')[0]; // UTC to yyyy-mm-dd conversion in case of an error
      }
    );
  }

  onCategoryChange(event: any): void {
    if (event.target.value !== 'Business') {
      this.contact.subCategory = '';
    }
  }
}
