"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.AppModule = exports.tokenGetter = void 0;
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/common/http");
var app_routing_module_1 = require("./app-routing.module");
var app_component_1 = require("../components/app/app.component");
var register_component_1 = require("../components/accountComponents/register/register.component");
var forms_1 = require("@angular/forms");
var ng_bootstrap_1 = require("@ng-bootstrap/ng-bootstrap");
var sign_in_component_1 = require("../components/accountComponents/sign-in/sign-in.component");
var logout_component_1 = require("../components/accountComponents/logout/logout.component");
var navigation_component_1 = require("../components/navigation/navigation.component");
var angular_jwt_1 = require("@auth0/angular-jwt");
var accounts_component_1 = require("../components/accountComponents/accounts/accounts.component");
var library_browser_component_1 = require("../components/library/browser/library-browser.component");
function tokenGetter() {
    return localStorage.getItem("access_token");
}
exports.tokenGetter = tokenGetter;
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                register_component_1.AccountRegisterComponent,
                sign_in_component_1.AccountSignInComponent,
                logout_component_1.LogoutComponent,
                accounts_component_1.AccountsComponent,
                navigation_component_1.NavigationComponent,
                library_browser_component_1.LibraryBrowserComponent,
            ],
            imports: [
                platform_browser_1.BrowserModule,
                http_1.HttpClientModule,
                angular_jwt_1.JwtModule.forRoot({
                    config: {
                        tokenGetter: tokenGetter,
                        allowedDomains: ["localhost:5000", "localhost:5001"],
                        disallowedRoutes: ["localhost:5000/sign-in", "localhost:5001/sign-in"]
                    }
                }),
                forms_1.ReactiveFormsModule,
                app_routing_module_1.AppRoutingModule,
                ng_bootstrap_1.NgbModule,
            ],
            providers: [],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
