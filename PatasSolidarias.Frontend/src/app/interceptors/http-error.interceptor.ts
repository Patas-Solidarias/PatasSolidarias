import { HttpErrorResponse, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { catchError, throwError } from 'rxjs';

import { Rotas } from '../app.routes';
import { AuthService } from '../services/auth.service';

export const httpErrorInterceptor: HttpInterceptorFn = (request: HttpRequest<any>, next: HttpHandlerFn) => {
  const messageService = inject(MessageService);
  const authService: AuthService = inject(AuthService);
  const router = inject(Router);

  if (authService.isAuthenticated()) {
    const token = authService.getToken();
    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }
  }

  const newLocal = next(request).pipe(
    catchError((error: HttpErrorResponse) => {
      let message = 'Erro desconhecido';

      if (error.status === 401) {
        message = 'Sessão expirada. Por favor, faça login novamente.';
        authService.logout();
        router.navigate([Rotas.Login]);
        return throwError(() => error);
      }
      if (error.error instanceof ErrorEvent) {
        message = `Erro: ${error.error.message}`;
      } else if (error.error?.errors && typeof error.error.errors === 'object') {
        const fieldErrors = Object.values(error.error.errors)
          .flatMap((errArray) => errArray as string[])
          .join('\n ');
        if (fieldErrors) {
          message = fieldErrors;
        }
      } else if (error.error?.message) {
        message = error.error.message;
      } else if (typeof error.error === 'string') {
        message = error.error;
      } else if ((typeof error.error.error) === 'string') {
        message = error.error.error;
      } else if (error.message) {
        message = error.message;
      }


      messageService.add({ severity: 'error', summary: 'Erro', detail: message, life: 5000 });
      return throwError(() => error);
    })
  );

  return newLocal;
};
