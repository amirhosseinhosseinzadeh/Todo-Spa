import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms'
import { TableModule } from 'primeng/table'
import { CheckboxModule } from 'primeng/checkbox';
import { Button } from 'primeng/button';

@Component({
    selector: 'todo-applications-table',
    standalone: true,
    imports: [
        TableModule,
        CheckboxModule,
        CommonModule,
        FormsModule,
        Button
    ],
    templateUrl: './applications-table.component.html',
    styleUrl: './applications-table.component.css'
})
export class ApplicationsTableComponent {
    @Input() applicationList: any

    constructor() { }
}
