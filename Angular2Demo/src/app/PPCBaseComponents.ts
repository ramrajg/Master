import { Injectable } from '@angular/core';
@Injectable()
export abstract class PPCBaseComponents {

    public static messageTitle = "PPC Warnings / Errors / Informations";
    public static messageText = "No Message Set";
    public static IsOpened: boolean;
    public static messageBoxType: string = "Ok";

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

    public get staticisOpened() {
        return PPCBaseComponents.IsOpened;
    }
    public get staticmessageTitle() {
        return PPCBaseComponents.messageTitle;
    }
    public get staticmessageBoxType() {
        return PPCBaseComponents.messageBoxType;
    }
    public get staticmessageText() {
        return PPCBaseComponents.messageText;
    }
}

