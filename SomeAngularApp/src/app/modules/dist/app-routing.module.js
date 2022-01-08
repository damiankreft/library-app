"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.AppRoutingModule = void 0;
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var accounts_component_1 = require("../components/accountComponents/accounts/accounts.component");
var register_component_1 = require("../components/accountComponents/register/register.component");
var sign_in_component_1 = require("../components/accountComponents/sign-in/sign-in.component");
var gateway_timeout_component_1 = require("../components/errors/gateway-timeout/gateway-timeout.component");
var not_found_component_1 = require("../components/errors/not-found/not-found.component");
var home_component_1 = require("../components/home/home.component");
var library_browser_component_1 = require("../components/library/browser/library-browser.component");
var auth_guard_service_1 = require("../services/authGuardService/auth-guard.service");
var login_guard_service_1 = require("../services/loginGuardService/login-guard.service");
var role_guard_service_1 = require("../services/roleGuardService/role-guard.service");
var routes = [
    { path: '', component: home_component_1.HomeComponent },
    { path: 'register', component: register_component_1.AccountRegisterComponent, canActivate: [auth_guard_service_1.AuthGuardService] },
    { path: 'sign-in', component: sign_in_component_1.AccountSignInComponent, canActivate: [login_guard_service_1.LoginGuardService] },
    { path: 'accounts', component: accounts_component_1.AccountsComponent, canActivate: [role_guard_service_1.RoleGuardService] },
    { path: 'resources', component: library_browser_component_1.LibraryBrowserComponent, canActivate: [role_guard_service_1.RoleGuardService] },
    { path: "error", component: gateway_timeout_component_1.GatewayTimeoutComponent },
    { path: '**', component: not_found_component_1.NotFoundComponent }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        core_1.NgModule({
            imports: [router_1.RouterModule.forRoot(routes)],
            exports: [router_1.RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
exports.AppRoutingModule = AppRoutingModule;
