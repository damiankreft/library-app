import { HttpErrorResponse, HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/AuthService/auth.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class AccountSignInComponent implements OnInit{
  public loginForm!: FormGroup;
  public invalidCredentials = false;
  private returnUrl!: string;

  constructor(
    public formBuilder: FormBuilder, 
    private loginService: AuthService,
    private router: Router, 
    private route: ActivatedRoute) { 
  }
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: new FormControl(''),
      password: new FormControl('')
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  login(): void {
    this.loginService.login(this.loginForm.value)
      .subscribe(
        () => { 
          this.router.navigateByUrl(this.returnUrl);
        },
        (error) => {
          this.loginErrorHandler(error);
        });
  }

  loginErrorHandler(error: HttpErrorResponse | any): void {
    if (!error.status)
      this.router.navigate(['error']);
    else if (error.status == HttpStatusCode.Unauthorized) {
      this.invalidCredentials = true;
      console.log("Credentials are invalid.");
    }
  }
}
