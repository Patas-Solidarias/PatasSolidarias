import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';

import { LoginRequest, LoginResponse } from '../../api/login';
import { Usuario } from '../../api/usuario';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _apiUrl = 'api/Auth/';

  private http = inject(HttpClient);
  constructor() { }

  async login(email: string, senha: string): Promise<LoginResponse> {
    const body: LoginRequest = { email, senha };

    const uri = this._apiUrl + 'login';
    const request = this.http.post<LoginResponse>(uri, body);
    const response = await lastValueFrom(request);

    if (response && response.token) {
      this.saveToken(response.token);
    } else {
      throw new Error('Login inválido');
    }

    return response;
  }

  async getUser(): Promise<Usuario> {
    const uri = this._apiUrl + 'usuario';
    const request = this.http.get<Usuario>(uri);
    const retorno = await lastValueFrom(request);

    return retorno;
  }

  async register(usuario: Usuario): Promise<Usuario> {
    const uri = this._apiUrl + 'register';
    const request = this.http.post<Usuario>(uri, usuario);
    var retorno = await lastValueFrom(request);
    return retorno;
  }

  saveToken(token: string): void {
    localStorage.setItem('authToken', token);
  }

  getToken(): string | null {
    return localStorage.getItem('authToken');
  }

  isAuthenticated(): boolean {
    const retorno = this.getToken();
    return !!retorno;
  }

  logout(): void {
    localStorage.removeItem('authToken');
  }
}
