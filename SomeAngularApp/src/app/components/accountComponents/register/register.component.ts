import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from 'src/app/services/accountService/account.service';
import { RegisterDto } from 'src/app/Dto/register-dto'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class AccountRegisterComponent implements OnInit {
  public readonly PASSWORD_PLACEHOLDER = "*********";
  public clicked = false;
  public registerForm!: FormGroup;
  private registerDto: RegisterDto;

  constructor(private accountService: AccountService, public formBuilder: FormBuilder) {
    this.registerDto = new RegisterDto();
  }

  ngOnInit(): void {
    const passwordValidators = [Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')];
    this.registerForm = this.formBuilder.group({
      email: new FormControl(this.registerDto.Email, Validators.email),
      username: new FormControl(this.registerDto.Username, [ Validators.minLength(2), Validators.maxLength(13)]),
      password: new FormControl(this.registerDto.Password, passwordValidators),
      confirmPassword: new FormControl(this.registerDto.confirmPassword, passwordValidators),
      role: new FormControl(this.registerDto.Role),
    }, { validators: Validators.required, updateOn: 'blur' });
  }

  onSubmit(): void {
    this.clicked = true;
    console.log(this.registerForm.errors);
    this.accountService.register(this.registerForm.value)
      .subscribe(
        (next) => {},
        (error) => { this.clicked = false; },
        () => {
          this.registerForm.reset();
        });
  }

  get email() { return this.registerForm.get('email')!; }
  get username() { return this.registerForm.get('username')!; }
  get password() { return this.registerForm.get('password')!; }
  get confirmPassword() { return this.registerForm.get('confirmPassword')!; }
  get role() { return this.registerForm.get('role')!; }
}
