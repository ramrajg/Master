import { Component } from '@angular/core'


@Component({
    selector: 'my-employee',
    templateUrl: `app/employee/employee.component.html`,
    styleUrls: [`app/employee/employee.component.css`]
})

export class EmployeeComponent {
    //boldClasses: string = 'boldClasses';
    //italicsClasses: boolean = true;
    //colorClass: boolean = true;
    //colspan: number = 2;
    //firstname: string = 'TestFirstname';
    //lastname: string = 'TestLastName';
    //gender: string = 'TestGender';
    //age: number = 20

    fontSize: number = 30;
    isBold: boolean = true;
    isItalic: boolean = true;

    addStyle() {

        let styles = {
            'font-weight': this.isBold ? 'bold' : 'normal',
            'font-size.px': this.fontSize

        }
        return styles;

    }

}