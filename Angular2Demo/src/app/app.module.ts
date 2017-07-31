import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



//import { PPCMessageBoxComponent } from './ppcMessageBox/ppcMessageBox.component';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './employee/employee-component';
import { DropDownComponent } from './dropDown/dropDown-component';


@NgModule({
    imports: [BrowserModule, DropDownsModule, ButtonsModule, LayoutModule, InputsModule, DialogModule, FormsModule],
    declarations: [AppComponent,  DropDownComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
