import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms'
import { TableModule } from 'primeng/table'
import { CheckboxModule } from 'primeng/checkbox';
import { Button } from 'primeng/button';
import { TodoApplication } from '../models/todoApplication';

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
    @Output('update') update?: EventEmitter<TodoApplication>
    @Output('toggleStatus') toggleStatus?: EventEmitter<number>
    @Output('delete') delete?: EventEmitter<number>

    constructor() { }

    attemptToDelete(e:MouseEvent): void {
        console.log(e.target)
        this.delete?.next(1);
    }

    attemptToToggleStatus(): void {
        this.toggleStatus?.next(1)
    }

    attemptToUpdate(): void {
        this.update?.next(new TodoApplication())
    }
}
