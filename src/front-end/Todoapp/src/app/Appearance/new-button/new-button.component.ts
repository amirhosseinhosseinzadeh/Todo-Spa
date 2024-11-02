import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button'
import { CalendarModule } from 'primeng/calendar';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ToDoApplication } from '../../models/todoApplication';
import { CheckboxModule } from 'primeng/checkbox';
import { TodoApplicationService } from '../../services/todo-application.service';

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
    todo: ToDoApplication = {}

    constructor(private todoService: TodoApplicationService) { }

    loadDialog() {
        this.visible = true
    }

    addTodoApplication() {
        let todoAdd = this.todoService.addApplication(this.todo)
            .subscribe(x => {

            })
    }
}
