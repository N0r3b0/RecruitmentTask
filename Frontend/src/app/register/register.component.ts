import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { UserRegister } from '../models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  user: UserRegister = { username: '', email: '', password: '' };
  errorMessage: string | null = null;

  constructor(private authService: AuthService, private router: Router) { }

  register(): void {
    this.authService.register(this.user).subscribe(
      (response) => {
        console.log('Registration response:', response);
        this.router.navigate(['/login']);
      },
      (error) => {
        console.error('Registration failed:', error);
        this.errorMessage = 'Registration failed';
      }
    );
  }
}
