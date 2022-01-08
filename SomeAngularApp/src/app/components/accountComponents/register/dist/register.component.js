"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.AccountRegisterComponent = void 0;
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var register_dto_1 = require("src/app/Dto/register-dto");
var AccountRegisterComponent = /** @class */ (function () {
    function AccountRegisterComponent(accountService, formBuilder) {
        this.accountService = accountService;
        this.formBuilder = formBuilder;
        this.PASSWORD_PLACEHOLDER = "*********";
        this.clicked = false;
        this.registerDto = new register_dto_1.RegisterDto();
    }
    AccountRegisterComponent.prototype.ngOnInit = function () {
        var passwordValidators = [forms_1.Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')];
        this.registerForm = this.formBuilder.group({
            email: new forms_1.FormControl(this.registerDto.Email, forms_1.Validators.email),
            username: new forms_1.FormControl(this.registerDto.Username, [forms_1.Validators.minLength(2), forms_1.Validators.maxLength(13)]),
            password: new forms_1.FormControl(this.registerDto.Password, passwordValidators),
            confirmPassword: new forms_1.FormControl(this.registerDto.confirmPassword, passwordValidators),
            role: new forms_1.FormControl(this.registerDto.Role)
        }, { validators: forms_1.Validators.required, updateOn: 'blur' });
    };
    AccountRegisterComponent.prototype.onSubmit = function () {
        var _this = this;
        this.clicked = true;
        console.log(this.registerForm.errors);
        this.accountService.register(this.registerForm.value)
            .subscribe(function (next) { }, function (error) { _this.clicked = false; }, function () {
            _this.registerForm.reset();
        });
    };
    Object.defineProperty(AccountRegisterComponent.prototype, "email", {
        get: function () { return this.registerForm.get('email'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(AccountRegisterComponent.prototype, "username", {
        get: function () { return this.registerForm.get('username'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(AccountRegisterComponent.prototype, "password", {
        get: function () { return this.registerForm.get('password'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(AccountRegisterComponent.prototype, "confirmPassword", {
        get: function () { return this.registerForm.get('confirmPassword'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(AccountRegisterComponent.prototype, "role", {
        get: function () { return this.registerForm.get('role'); },
        enumerable: false,
        configurable: true
    });
    AccountRegisterComponent = __decorate([
        core_1.Component({
            selector: 'app-register',
            templateUrl: './register.component.html',
            styleUrls: ['./register.component.scss']
        })
    ], AccountRegisterComponent);
    return AccountRegisterComponent;
}());
exports.AccountRegisterComponent = AccountRegisterComponent;
