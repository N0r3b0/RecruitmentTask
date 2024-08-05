import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserLogin, UserRegister } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5050/api/auth';

  constructor(private http: HttpClient) { }

  login(user: UserLogin): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, user);
  }

  register(user: UserRegister): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, user);
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    return this.isLoggedIn();
  }
}
