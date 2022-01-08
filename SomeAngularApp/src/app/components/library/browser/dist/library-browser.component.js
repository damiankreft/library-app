"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.LibraryBrowserComponent = void 0;
var core_1 = require("@angular/core");
var LibraryBrowserComponent = /** @class */ (function () {
    function LibraryBrowserComponent(libraryService) {
        this.libraryService = libraryService;
    }
    LibraryBrowserComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.libraryService.getGenericResources()
            .subscribe(function (data) { _this.resources = data; console.log(data); });
    };
    LibraryBrowserComponent.prototype.lease = function () {
        this.libraryService.lease();
    };
    LibraryBrowserComponent = __decorate([
        core_1.Component({
            selector: 'app-accounts',
            templateUrl: './library-browser.component.html',
            styleUrls: ['./library-browser.component.scss']
        })
    ], LibraryBrowserComponent);
    return LibraryBrowserComponent;
}());
exports.LibraryBrowserComponent = LibraryBrowserComponent;
