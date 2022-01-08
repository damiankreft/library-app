import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from '../components/app/app.component';
import { AccountRegisterComponent } from '../components/accountComponents/register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AccountSignInComponent } from '../components/accountComponents/sign-in/sign-in.component';
import { LogoutComponent as AccountLogoutComponent } from '../components/accountComponents/logout/logout.component';
import { NavigationComponent } from '../components/navigation/navigation.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AccountsComponent } from '../components/accountComponents/accounts/accounts.component';
import { LibraryBrowserComponent } from '../components/library/browser/library-browser.component';

export function tokenGetter() {
  return localStorage.getItem("access_token");
}

@NgModule({
  declarations: [
    AppComponent,
    AccountRegisterComponent,
    AccountSignInComponent,
    AccountLogoutComponent,
    AccountsComponent,
    NavigationComponent,
    LibraryBrowserComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5000", "localhost:5001"],
        disallowedRoutes: ["localhost:5000/sign-in", "localhost:5001/sign-in"]
      }
    }),
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
