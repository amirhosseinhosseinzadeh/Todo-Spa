import { Component, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms'
import { TableModule } from 'primeng/table'
import { ToDoApplication } from '../models/todoApplication';
import { TodoApplicationService } from "../services/todo-application.service"
import { ApiQuery } from '../models/ApiQuery';
import { CheckboxModule } from 'primeng/checkbox';

@Component({
    selector: 'todo-applications-table',
    standalone: true,
    imports: [
        TableModule,
        CheckboxModule,
        CommonModule,
        FormsModule
    ],
    templateUrl: './applications-table.component.html',
    styleUrl: './applications-table.component.css'
})
export class ApplicationsTableComponent implements AfterViewInit {
    applications: ToDoApplication[] = []
    apiQuery: ApiQuery = new ApiQuery()
    test: boolean = true
    constructor(private todoService: TodoApplicationService) { }


    ngAfterViewInit(): void {
        this.todoService.GetApplications(this.apiQuery)
            .subscribe(x => {
                this.applications = x
            })
    }
}
