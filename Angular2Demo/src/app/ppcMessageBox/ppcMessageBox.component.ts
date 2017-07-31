import { Component, Input, Output, AfterViewInit, EventEmitter, ViewEncapsulation } from '@angular/core';
import { AppModule } from '../app.module';
import { CommonModule } from '@angular/common';
@Component({
    selector: 'ppcMessageBox',
    templateUrl:`app/ppcMessageBox/ppcMessageBox.component.html`,
    styleUrls: [require(`app/ppcMessageBox/ppcMessageBox.component.css`)]
})
export class PPCMessageBoxComponent {

    @Input("MessageTitle")
    public messageTitle = "No Message Set";
    @Input("MessageText")
    public messageText = "No Message Set";
    @Input("IsOpened")
    public IsOpened: boolean;
    @Input("MessageBoxType")
    public messageBoxType: string = "Ok";
    public confirmStatus: boolean = false;
    public ReviewStatus: boolean = false;
    public ReviewComments: string;

    @Output('ShowPPCMessageBox')
    ShowPPCMessageBox = new EventEmitter<any>();

    @Output('PPCMessageBoxOnAccept')
    PPCMessageBoxOnAccept = new EventEmitter<any>();

    @Output('PPCMessageBoxOnDecline')
    PPCMessageBoxOnDecline = new EventEmitter<any>();

    @Output('PPCMessageBoxOnOk')
    PPCMessageBoxOnOk = new EventEmitter<any>();

    @Output('PPCMessageBoxOnReview')
    PPCMessageBoxOnReview = new EventEmitter<any>();

    public closeDialog() {
        this.IsOpened = false;
        this.PPCMessageBoxOnOk.emit("PARIS Dashboard");
    }

    public onAccept() {
        this.confirmStatus = true;
        this.IsOpened = false;
        this.PPCMessageBoxOnAccept.emit();
    }

    public onDecline() {
        this.confirmStatus = false;
        this.IsOpened = false;
        this.PPCMessageBoxOnDecline.emit();
    }

    public onReview(ReviewComments: any) {
        this.ReviewStatus = true;
        this.IsOpened = false;
        this.PPCMessageBoxOnReview.emit(ReviewComments);
    }

}

