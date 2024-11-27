import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button'
import { CalendarModule } from 'primeng/calendar';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { TodoApplication } from '../../models/todoApplication';
import { CheckboxModule } from 'primeng/checkbox';

@Component({
    selector: 'new-button',
    styleUrl: './new-button.component.css',
    standalone: true,
    imports: [
        ButtonModule,
        DialogModule,
        InputTextModule,
        CalendarModule,
        FormsModule,
        CheckboxModule
    ],
    templateUrl: './new-button.component.html',
})

export class NewButtonComponent {
    visible: boolean = false
    todo: TodoApplication = {}
    @Output() addNewItem = new EventEmitter();

    constructor() { }

    addItem() {
        this.visible = false
        this.addNewItem.next(this.todo);
    }

    loadDialog() {
        this.visible = true
        this.clearModel()
    }

    clearModel() {
        this.todo = new TodoApplication();
    }
}
