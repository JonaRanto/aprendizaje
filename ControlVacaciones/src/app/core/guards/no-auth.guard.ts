import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { INTERNAL_ROUTES } from '@data/constants/routes';
import { AuthService } from '@data/services';

@Injectable({
  providedIn: 'root'
})
export class NoAuthGuard implements CanActivate {

  constructor(
    private routers: Router,
    private authService: AuthService
  ) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
    ): boolean {
    const currentUser = this.authService.getUser; // Se obtiene el usuario actual
    if (currentUser) {
      this.routers.navigateByUrl(INTERNAL_ROUTES.PANEL_HISTORY);  // En caso de que el usuario exista, se retornará a su ruta principal y regresará false
      return false;
    }
    return true;  // Si el usuario no existe, se regresa un true
  }
  
}
