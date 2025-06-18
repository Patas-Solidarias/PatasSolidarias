import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

import { Rotas } from '../app.routes';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (_route) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  if (authService.isAuthenticated()) {
    return true;
  } else {
    router.navigate([Rotas.Login]);
    return false;
  }
};
