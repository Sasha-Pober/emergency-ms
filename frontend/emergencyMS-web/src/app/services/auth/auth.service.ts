import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginResponse } from '../../responses/LoginResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private Url = 'http://localhost:5030';

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<LoginResponse> {
    const loginData = {email: username, password: password };
    return this.http.post<LoginResponse>(`${this.Url}/api/auth/login`, loginData);
  }

  saveToken(response: LoginResponse): void {

    localStorage.setItem('accessToken', response.accessToken);
    localStorage.setItem('tokenType', response.tokenType);
    const expiresAt = new Date().getTime() + response.expiresIn * 1000;
    localStorage.setItem('expiresAt', expiresAt.toString());
  }

  getToken(): string | null {
    const tokenType = localStorage.getItem('tokenType');
    const accessToken = localStorage.getItem('accessToken');
    return tokenType && accessToken ? `${tokenType} ${accessToken}` : null;
  }

  // getRefreshToken(): string | null {
  //   return localStorage.getItem('refreshToken');
  // }

  isTokenExpired(): boolean {
    const expiresAt = localStorage.getItem('expiresAt');
    if (!expiresAt) return true;
    return new Date().getTime() > parseInt(expiresAt);
  }

  logout(): void {
    localStorage.removeItem('tokenType');
    localStorage.removeItem('accessToken');
    // localStorage.removeItem('refreshToken');
    localStorage.removeItem('expiresAt');
  }

  register(registerData: { email: string; password: string }): Observable<any> {
    return this.http.post(`${this.Url}/api/auth/register`, registerData);
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    const expiresAt = localStorage.getItem('expiresAt');
    if (!token || !expiresAt) {
      return false;
    }
    return new Date().getTime() < parseInt(expiresAt); // Check if the token is still valid
  }
}