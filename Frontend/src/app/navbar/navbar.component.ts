import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLoggedIn = false;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.checkLoginStatus();
    this.router.events.subscribe(() => {
      this.checkLoginStatus();
    });
  }

  checkLoginStatus(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  logout(): void {
    this.authService.logout();
    this.isLoggedIn = false;
    this.router.navigate(['/login']);
  }
}
