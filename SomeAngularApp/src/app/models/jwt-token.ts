export class JwtToken {
    public token!: string;
    public expiry!: number;
    public 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'!: string;
}
