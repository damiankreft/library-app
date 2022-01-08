import { AccountDto } from "./account-dto";

export class AccountResponse {
    '$id': string;
    '$values': Array<AccountDto>;
}
