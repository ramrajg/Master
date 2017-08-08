import { Component } from "@angular/core"
//import '../assets/app.css'

@Component({
    selector: 'my-app',
    template: `<div>
                <login></login>
                </div>`
    
})

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
