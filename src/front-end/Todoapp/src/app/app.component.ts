import { Component, DoCheck, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToDoApplication } from './models/todoApplication';
import { NewButtonComponent } from './Appearance/new-button/new-button.component';
import { ButtonModule } from 'primeng/button'
import { ApplicationsTableComponent } from './applications-table/applications-table.component'

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet,
        NewButtonComponent,
        ButtonModule,
        ApplicationsTableComponent,
    ],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent implements DoCheck, OnInit {
    title = 'Todoapp'
    applications: ToDoApplication[] = []
    applicationJson?: string

    constructor() {
    }

    ngDoCheck(): void {
    }
    ngOnInit(): void {

    }
}