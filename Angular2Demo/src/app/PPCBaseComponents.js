"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var PPCBaseComponents = PPCBaseComponents_1 = (function () {
    function PPCBaseComponents() {
    }
    Object.defineProperty(PPCBaseComponents.prototype, "staticisOpened", {
        //public abstract PPCMessageBoxClose(eventName: any);
        //public abstract PPCMessageBoxAccep();
        //public abstract PPCMessageBoxDecline();
        //public abstract PPCMessageBoxReview(e);
        //public PPCMessageBoxOnOk(e: any): void {
        //    PPCBaseComponents.IsOpened = false;
        //    this.PPCMessageBoxClose(e);
        //}
        //PPCMessageBoxOnAccept(): void {
        //    PPCBaseComponents.IsOpened = false;
        //    this.PPCMessageBoxAccep();
        //}
        //PPCMessageBoxOnDecline(): void {
        //    PPCBaseComponents.IsOpened = false;
        //    this.PPCMessageBoxDecline();
        //}
        //PPCMessageBoxOnReview(e): void {
        //    PPCBaseComponents.IsOpened = false;
        //    this.PPCMessageBoxReview(e);
        //}
        //public static PPCMessageBox(messageTitle, messageText, messageBoxType): void {
        //    PPCBaseComponents.messageTitle = messageTitle;
        //    PPCBaseComponents.messageBoxType = messageBoxType;
        //    PPCBaseComponents.messageText = messageText;
        //    PPCBaseComponents.IsOpened = true;
        //}
        get: function () {
            return PPCBaseComponents_1.IsOpened;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(PPCBaseComponents.prototype, "staticmessageTitle", {
        get: function () {
            return PPCBaseComponents_1.messageTitle;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(PPCBaseComponents.prototype, "staticmessageBoxType", {
        get: function () {
            return PPCBaseComponents_1.messageBoxType;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(PPCBaseComponents.prototype, "staticmessageText", {
        get: function () {
            return PPCBaseComponents_1.messageText;
        },
        enumerable: true,
        configurable: true
    });
    return PPCBaseComponents;
}());
PPCBaseComponents.messageTitle = "PPC Warnings / Errors / Informations";
PPCBaseComponents.messageText = "No Message Set";
PPCBaseComponents.messageBoxType = "Ok";
PPCBaseComponents = PPCBaseComponents_1 = __decorate([
    core_1.Injectable()
], PPCBaseComponents);
exports.PPCBaseComponents = PPCBaseComponents;
var PPCBaseComponents_1;
//# sourceMappingURL=PPCBaseComponents.js.map