import { CanActivateFn } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  // lógica de autenticação
  return true; // ou false, ou um Observable/Promise
};