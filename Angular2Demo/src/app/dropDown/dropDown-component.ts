import { Component, Input, Output, AfterViewInit, EventEmitter, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputsModule } from '@progress/kendo-angular-inputs';


@Component({
    selector: 'my-dropDown',
    templateUrl: `app/dropDown/dropDown-component.html`,
    styleUrls: [`app/dropDown/dropDown-component.css`]
})
export class DropDownComponent {
   // @Input("listItemsEnv")
    public listItemsEnv: Array<string> = ["PARISDEV ", "PARISQA ", "PARISUAT ", "PARISDEV02", "ParisQA_02", "PARISUAT_02", "PARISSTG", "PARIS"];
   // @Input("selectedValueEnv")
    public selectedValueEnv = "PARISDEV ";

    @Output('onPPCEnvChange')
    onPPCEnvChange = new EventEmitter<any>();

    public handleSelectionEnv(selectedValue: any) {
        this.selectedValueEnv = selectedValue;
        this.onPPCEnvChange.emit(selectedValue);
    }
}