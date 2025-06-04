import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';

import { backendApi as backendOpenApi } from '../../api/openApi';
import { LoginRequest, LoginResponse } from '../../api/login';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _apiUrl = 'http://localhost:5000/api/Auth/login';

  private http = inject(HttpClient);
  constructor() { }

  async login(email: string, password: string): Promise<LoginResponse> {
    const body: LoginRequest = { email, password };

    const request = this.http.post<LoginResponse>(this._apiUrl, body);
    const response = await lastValueFrom(request);

    if (response && response.token) {
      this.saveToken(response.token);
    } else {
      throw new Error('Login inválido');
    }

    return response;
  }

  saveToken(token: string): void {
    localStorage.setItem('authToken', token);
  }

  getToken(): string | null {
    return localStorage.getItem('authToken');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  logout(): void {
    localStorage.removeItem('authToken');
  }
}
