import { Component } from "@angular/core"

@Component({
    selector: 'my-app',
    template: `<div>
                <h1>{{PageHeader ? PageHeader : getFullName()}}</h1>
                <img src ='{{imagePath}}'/>
                <my-employee></my-employee>
                <button [disabled] = 'isDisabled'>Click Me </button>
                <span bind-innerHTML= 'getFullName()'></span>
                </div>
                `
})

//@Component({
//    selector: 'my-app',
//    template: `<div>
//                <my-dropDown  (onPPCEnvChange)="onPPCEnvChange($event)"></my-dropDown>
//                </div>
//                `
//})
//@Component({
//    selector: 'my-app',
//    template: `<div>
//                <ppcMessageBox></ppcMessageBox>
//                </div>
//                `
//})
//@Component({
//    selector: 'my-app',
//    template: `
//                <div class="example-config" >
//                Selected value is: { { value | kendoDate:'MM/dd/yyyy' } }
//                </div>
//                < div class="example-wrapper" style= "min-height: 400px" >
//                <p>Select a date: </p>
//                < kendo - datepicker
//                [(value)]="value"
//                > </kendo-datepicker>
//                <p>(use Alt+↓ to open the calendar, ← and →  to navigate, ↑ to increment and ↓ to decrement the value) < /p>
//                < /div>      `
//    })






//@Component({
//    selector: 'my-app',
//    template: `
//                <div class="example-wrapper" >
//                <p>T - shirt size: </p>
//                < kendo-dropdownlist [data]="listItems" >
//                </kendo-dropdownlist>
//                < /div>
//                `
//})





export class AppComponent {
    public value: Date = new Date(2000, 2, 10);
    PageHeader: string = ''
    firstName: string = 'Tom'
    lastName: string = 'G'
    isDisabled: boolean = false
    imagePath: string = 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Microsoft_logo_%282012%29.svg/512px-Microsoft_logo_%282012%29.svg.png';
    listItems: Array<string> = ["X-Small", "Small", "Medium", "Large", "X-Large", "2X-Large"];
    getFullName(): string {
        return this.firstName + 'dsds ' + this.lastName;
    }
   
    onPPCEnvChange(value:any) {
        alert(value);
    }
}
