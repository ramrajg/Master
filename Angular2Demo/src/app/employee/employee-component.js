"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var EmployeeComponent = (function () {
    function EmployeeComponent() {
        //boldClasses: string = 'boldClasses';
        //italicsClasses: boolean = true;
        //colorClass: boolean = true;
        //colspan: number = 2;
        //firstname: string = 'TestFirstname';
        //lastname: string = 'TestLastName';
        //gender: string = 'TestGender';
        //age: number = 20
        this.fontSize = 30;
        this.isBold = true;
        this.isItalic = true;
    }
    EmployeeComponent.prototype.addStyle = function () {
        var styles = {
            'font-weight': this.isBold ? 'bold' : 'normal',
            'font-size.px': this.fontSize
        };
        return styles;
    };
    return EmployeeComponent;
}());
EmployeeComponent = __decorate([
    core_1.Component({
        selector: 'my-employee',
        templateUrl: "app/employee/employee.component.html",
        styleUrls: ["app/employee/employee.component.css"]
    })
], EmployeeComponent);
exports.EmployeeComponent = EmployeeComponent;
//# sourceMappingURL=employee-component.js.map