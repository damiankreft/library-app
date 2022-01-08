import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountDto } from 'src/app/Dto/account-dto';
import { environment } from 'src/environments/environment';
import { RegisterDto } from 'src/app/Dto/register-dto';
import { shareReplay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private accountsUri: string;
      
  constructor(private http: HttpClient) {
    this.accountsUri = environment.apiHost + "accounts";
  }

  getAccount(email: string): Observable<AccountDto> {
    return this.http.get<AccountDto>(this.accountsUri + email);
  }

  getAccounts(): Observable<AccountDto[]> {
    return this.http.get<AccountDto[]>(this.accountsUri);
  }

  register(registerDto: RegisterDto): Observable<any> {
    return this.http.post(this.accountsUri, registerDto).pipe(shareReplay());
  }
}
