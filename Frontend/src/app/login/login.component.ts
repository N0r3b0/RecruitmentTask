import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { UserLogin } from '../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  user: UserLogin = { username: '', password: '' };
  errorMessage: string | null = null;

  constructor(private authService: AuthService, private router: Router) { }

  login(): void {
    this.authService.login(this.user).subscribe(
      (response) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/contacts']);
      },
      (error) => {
        this.errorMessage = 'Invalid username or password';
      }
    );
  }
}
