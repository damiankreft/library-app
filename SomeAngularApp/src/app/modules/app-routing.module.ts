import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountsComponent } from '../components/accountComponents/accounts/accounts.component';
import { AccountRegisterComponent } from '../components/accountComponents/register/register.component';
import { AccountSignInComponent } from '../components/accountComponents/sign-in/sign-in.component';
import { GatewayTimeoutComponent } from '../components/errors/gateway-timeout/gateway-timeout.component';
import { NotFoundComponent } from '../components/errors/not-found/not-found.component';
import { HomeComponent } from '../components/home/home.component';
import { LibraryBrowserComponent } from '../components/library/browser/library-browser.component';
import { AuthGuardService as AuthGuard }  from '../services/authGuardService/auth-guard.service';
import { LoginGuardService as LoginGuard } from '../services/loginGuardService/login-guard.service';
import { RoleGuardService as RoleGuard } from '../services/roleGuardService/role-guard.service';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'register', component: AccountRegisterComponent, canActivate: [AuthGuard] },
  { path: 'sign-in', component: AccountSignInComponent, canActivate: [LoginGuard] },
  { path: 'accounts', component: AccountsComponent, canActivate: [RoleGuard], },
  { path: 'resources', component: LibraryBrowserComponent, canActivate: [RoleGuard], },
  { path: "error", component: GatewayTimeoutComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
