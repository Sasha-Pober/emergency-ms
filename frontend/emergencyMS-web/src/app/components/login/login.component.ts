import { Component } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  isLoginMode: boolean = true;

  username: string = '';
  password: string = '';
  confirmPassword: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  toggleMode(): void {
    this.isLoginMode = !this.isLoginMode;
    this.errorMessage = '';
  }

  login(): void {
    this.authService.login(this.username, this.password).subscribe({
      next: (response) => {
        this.authService.saveToken(response);

        const decodedPayload = this.decodeJwt(response.accessToken);
        const roles = decodedPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || [];

        if (roles.includes('Manager') && roles) {
          this.router.navigate(['/dashboard']); // Navigate to the dashboard after successful login
        }
        else {
          this.router.navigate(['/']); // Navigate to the home page if not a manager
        }
      }
      ,
      error: (error) => {
        this.errorMessage = 'Неправильний логін або пароль';
        console.error('Login error:', error);
      }
    });
  }

  register(): void {
    if (this.password !== this.confirmPassword) {
      this.errorMessage = 'Паролі не співпадають';
      return;
    }

    const registerData = { email: this.username, password: this.password };
    this.authService.register(registerData).subscribe({
      next: () => {
        this.isLoginMode = true; // Switch to login mode after successful registration
        this.errorMessage = 'Реєстрація успішна! Тепер ви можете увійти.';
      },
      error: (error) => {
        this.errorMessage = 'Помилка реєстрації. Спробуйте ще раз.';
        console.error('Register error:', error);
      }
    });
  }

  decodeJwt(token: string): any {
    const payload = token.split('.')[1]; // Extract the payload part of the JWT
    const decodedPayload = atob(payload); // Decode the base64 string
    return JSON.parse(decodedPayload); // Parse the JSON string into an object
  }
}