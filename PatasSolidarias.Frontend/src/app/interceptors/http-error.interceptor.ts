import { HttpErrorResponse, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { MessageService } from 'primeng/api';
import { catchError, throwError } from 'rxjs';

export const httpErrorInterceptor: HttpInterceptorFn = (request: HttpRequest<any>, next: HttpHandlerFn) => {
  const messageService = inject(MessageService);

  return next(request).pipe(
    catchError((error: HttpErrorResponse) => {
      let msg = 'Erro desconhecido';
      if (error.error instanceof ErrorEvent) {
        msg = `Erro: ${error.error.message}`;
      } else if (error.error?.message) {
        msg = error.error.message;
      } else if (typeof error.error === 'string') {
        msg = error.error;
      } else if (error.message) {
        msg = error.message;
      }

      messageService.add({ severity: 'error', summary: 'Erro', detail: msg });
      return throwError(() => error);
    })
  );
};
