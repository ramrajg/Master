"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var kendo_angular_dropdowns_1 = require("@progress/kendo-angular-dropdowns");
var kendo_angular_buttons_1 = require("@progress/kendo-angular-buttons");
var kendo_angular_layout_1 = require("@progress/kendo-angular-layout");
var kendo_angular_inputs_1 = require("@progress/kendo-angular-inputs");
var kendo_angular_dialog_1 = require("@progress/kendo-angular-dialog");
//import { PPCMessageBoxComponent } from './ppcMessageBox/ppcMessageBox.component';
var app_component_1 = require("./app.component");
var employee_component_1 = require("./employee/employee-component");
var loginScreen_component_1 = require("./loginScreen/loginScreen-component");
//import { DropDownComponent } from './dropDown/dropDown-component';
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [platform_browser_1.BrowserModule, kendo_angular_dropdowns_1.DropDownsModule, kendo_angular_buttons_1.ButtonsModule, kendo_angular_layout_1.LayoutModule, kendo_angular_inputs_1.InputsModule, kendo_angular_dialog_1.DialogModule, forms_1.FormsModule],
        declarations: [app_component_1.AppComponent, employee_component_1.EmployeeComponent, loginScreen_component_1.LoginComponent],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map