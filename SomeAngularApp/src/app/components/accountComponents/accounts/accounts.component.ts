import { Component, OnInit } from '@angular/core';
import { AccountDto } from 'src/app/Dto/account-dto';
import { AccountService } from 'src/app/services/accountService/account.service';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.scss']
})
export class AccountsComponent implements OnInit {

  selectedAccount?: AccountDto;
  public accounts!: AccountDto[];

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.accountService.getAccounts()
      .subscribe((data) => { this.accounts = data; });
  }
}
