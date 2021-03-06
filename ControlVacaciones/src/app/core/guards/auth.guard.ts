import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { INTERNAL_ROUTES } from '@data/constants/routes';
import { AuthService } from '@data/services';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private authService: AuthService
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    const currentUser = this.authService.getUser; // Se obtiene el usuario actual
    if (currentUser) {
      if (route.data.roles && !this.authService.hasAccessToModule(route.data.roles)) {
        return false; 
      }
      return true;  // Si el usuario existe, se regresa un true
    }
    this.router.navigate([INTERNAL_ROUTES.AUTH_LOGIN], { 
      queryParams: { returnUrl: state.url }
    }); // En caso de que no exista, se devuelve al path de login con un queryParams con la propiedad returnUrl que indica la ultima url en la que se estubo
    return false;
  }
}
