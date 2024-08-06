import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../services/contact.service';
import { Contact } from '../models/contact';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit {
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
  isAuthenticated: boolean = false; 

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private contactService: ContactService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.isAuthenticated = this.authService.isAuthenticated();
    this.getContact();
  }

  getContact(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.contactService.getContact(id).subscribe((contact) => {
      contact.birthDate = contact.birthDate.split('T')[0]; // UTC to yyyy-mm-dd conversion
      this.contact = contact;
    });
  }

  onCategoryChange(event: any): void {
    if (event.target.value !== 'Business') {
      this.contact.subCategory = '';
    }
  }

  save(): void {
    if (!this.authService.isAuthenticated()) {
      this.errorMessage = 'You must be logged in to save a contact.';
      return;
    }
    if (this.contact) {
      this.contact.birthDate = new Date(this.contact.birthDate).toISOString(); // UTC conversion
      this.contactService.updateContact(this.contact).subscribe(() => this.router.navigate(['/contacts']),
        (error) => {
          this.errorMessage = 'Failed to save contact. Please try again.';
          this.contact.birthDate = this.contact.birthDate.split('T')[0]; // UTC to yyyy-mm-dd conversion in case of an error
        }
       );

    }
  }

  delete(): void {
    if (!this.authService.isAuthenticated()) {
      this.errorMessage = 'You must be logged in to delete a contact.';
      return;
    }
    if (this.contact) {
      this.contactService.deleteContact(this.contact.id).subscribe(() => this.router.navigate(['/contacts']));
    }
  }
}
