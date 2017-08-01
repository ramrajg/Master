"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var AppComponent = (function () {
    function AppComponent() {
        this.value = new Date(2000, 2, 10);
        this.PageHeader = '';
        this.firstName = 'Tom';
        this.lastName = 'G';
        this.isDisabled = false;
        this.imagePath = 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Microsoft_logo_%282012%29.svg/512px-Microsoft_logo_%282012%29.svg.png';
        this.listItems = ["X-Small", "Small", "Medium", "Large", "X-Large", "2X-Large"];
    }
    AppComponent.prototype.getFullName = function () {
        return this.firstName + 'dsds ' + this.lastName;
    };
    AppComponent.prototype.onPPCEnvChange = function (value) {
        alert(value);
    };
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'my-app',
        template: "<div>\n                <login></login>\n                </div>"
    })
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map