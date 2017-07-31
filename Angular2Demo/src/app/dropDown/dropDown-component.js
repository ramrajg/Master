"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var DropDownComponent = (function () {
    function DropDownComponent() {
        // @Input("listItemsEnv")
        this.listItemsEnv = ["PARISDEV ", "PARISQA ", "PARISUAT ", "PARISDEV02", "ParisQA_02", "PARISUAT_02", "PARISSTG", "PARIS"];
        // @Input("selectedValueEnv")
        this.selectedValueEnv = "PARISDEV ";
        this.onPPCEnvChange = new core_1.EventEmitter();
    }
    DropDownComponent.prototype.handleSelectionEnv = function (selectedValue) {
        this.selectedValueEnv = selectedValue;
        this.onPPCEnvChange.emit(selectedValue);
    };
    return DropDownComponent;
}());
__decorate([
    core_1.Output('onPPCEnvChange'),
    __metadata("design:type", Object)
], DropDownComponent.prototype, "onPPCEnvChange", void 0);
DropDownComponent = __decorate([
    core_1.Component({
        selector: 'my-dropDown',
        templateUrl: "app/dropDown/dropDown-component.html",
        styleUrls: ["app/dropDown/dropDown-component.css"]
    })
], DropDownComponent);
exports.DropDownComponent = DropDownComponent;
//# sourceMappingURL=dropDown-component.js.map