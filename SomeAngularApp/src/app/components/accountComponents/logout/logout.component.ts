import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/AuthService/auth.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent {

  constructor(private auth: AuthService, private router: Router) { }

  logoutClick(): void {
    this.auth.logout();
    this.router.navigate([""]);
  }

  isAuthenticated(): boolean {
    return this.auth.isAuthenticated();
  }
}
