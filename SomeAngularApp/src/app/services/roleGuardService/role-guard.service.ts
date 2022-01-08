import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { AuthService } from '../AuthService/auth.service';
import jwt_decode from 'jwt-decode'
import { JwtToken } from 'src/app/models/jwt-token';

@Injectable({
  providedIn: 'root'
})
export class RoleGuardService implements CanActivate{

  constructor(public auth: AuthService, public router: Router) { }
  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedRole = route.data.expectedRole;

    const token = localStorage.getItem("access_token");
    
    const tokenPayload = jwt_decode<JwtToken>(token === null ? "" : token);

    console.log("Expected role: " + expectedRole + " but received: " + tokenPayload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
    if (!this.auth.isAuthenticated() || tokenPayload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] !== expectedRole) {
      this.router.navigate(["sign-in"]);
      return false;
    }

    return true;
  }
}
