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
var PPCMessageBoxComponent = (function () {
    function PPCMessageBoxComponent() {
        this.messageTitle = "No Message Set";
        this.messageText = "No Message Set";
        this.messageBoxType = "Ok";
        this.confirmStatus = false;
        this.ReviewStatus = false;
        this.ShowPPCMessageBox = new core_1.EventEmitter();
        this.PPCMessageBoxOnAccept = new core_1.EventEmitter();
        this.PPCMessageBoxOnDecline = new core_1.EventEmitter();
        this.PPCMessageBoxOnOk = new core_1.EventEmitter();
        this.PPCMessageBoxOnReview = new core_1.EventEmitter();
    }
    PPCMessageBoxComponent.prototype.closeDialog = function () {
        this.IsOpened = false;
        this.PPCMessageBoxOnOk.emit("PARIS Dashboard");
    };
    PPCMessageBoxComponent.prototype.onAccept = function () {
        this.confirmStatus = true;
        this.IsOpened = false;
        this.PPCMessageBoxOnAccept.emit();
    };
    PPCMessageBoxComponent.prototype.onDecline = function () {
        this.confirmStatus = false;
        this.IsOpened = false;
        this.PPCMessageBoxOnDecline.emit();
    };
    PPCMessageBoxComponent.prototype.onReview = function (ReviewComments) {
        this.ReviewStatus = true;
        this.IsOpened = false;
        this.PPCMessageBoxOnReview.emit(ReviewComments);
    };
    return PPCMessageBoxComponent;
}());
__decorate([
    core_1.Input("MessageTitle"),
    __metadata("design:type", Object)
], PPCMessageBoxComponent.prototype, "messageTitle", void 0);
__decorate([
    core_1.Input("MessageText"),
    __metadata("design:type", Object)
], PPCMessageBoxComponent.prototype, "messageText", void 0);
__decorate([
    core_1.Input("IsOpened"),
    __metadata("design:type", Boolean)
], PPCMessageBoxComponent.prototype, "IsOpened", void 0);
__decorate([
    core_1.Input("MessageBoxType"),
    __metadata("design:type", String)
], PPCMessageBoxComponent.prototype, "messageBoxType", void 0);
__decorate([
    core_1.Output('ShowPPCMessageBox'),
    __metadata("design:type", Object)
], PPCMessageBoxComponent.prototype, "ShowPPCMessageBox", void 0);
__decorate([
    core_1.Output('PPCMessageBoxOnAccept'),
    __metadata("design:type", Object)
], PPCMessageBoxComponent.prototype, "PPCMessageBoxOnAccept", void 0);
__decorate([
    core_1.Output('PPCMessageBoxOnDecline'),
    __metadata("design:type", Object)
], PPCMessageBoxComponent.prototype, "PPCMessageBoxOnDecline", void 0);
__decorate([
    core_1.Output('PPCMessageBoxOnOk'),
    __metadata("design:type", Object)
], PPCMessageBoxComponent.prototype, "PPCMessageBoxOnOk", void 0);
__decorate([
    core_1.Output('PPCMessageBoxOnReview'),
    __metadata("design:type", Object)
], PPCMessageBoxComponent.prototype, "PPCMessageBoxOnReview", void 0);
PPCMessageBoxComponent = __decorate([
    core_1.Component({
        selector: 'ppcMessageBox',
        templateUrl: "app/ppcMessageBox/ppcMessageBox.component.html",
        styleUrls: [require("app/ppcMessageBox/ppcMessageBox.component.css")]
    })
], PPCMessageBoxComponent);
exports.PPCMessageBoxComponent = PPCMessageBoxComponent;
//# sourceMappingURL=ppcMessageBox.component.js.map