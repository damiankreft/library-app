"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.AccountService = void 0;
var core_1 = require("@angular/core");
var environment_1 = require("src/environments/environment");
var operators_1 = require("rxjs/operators");
var AccountService = /** @class */ (function () {
    function AccountService(http) {
        this.http = http;
        this.accountsUri = environment_1.environment.apiHost + "accounts";
    }
    AccountService.prototype.getAccount = function (email) {
        return this.http.get(this.accountsUri + email);
    };
    AccountService.prototype.getAccounts = function () {
        return this.http.get(this.accountsUri);
    };
    AccountService.prototype.register = function (registerDto) {
        return this.http.post(this.accountsUri, registerDto).pipe(operators_1.shareReplay());
    };
    AccountService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], AccountService);
    return AccountService;
}());
exports.AccountService = AccountService;
