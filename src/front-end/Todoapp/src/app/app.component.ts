import { AfterViewInit, Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TodoApplication } from './models/todoApplication';
import { NewButtonComponent } from './Appearance/new-button/new-button.component';
import { ButtonModule } from 'primeng/button'
import { ApplicationsTableComponent } from './applications-table/applications-table.component'
import { TodoApplicationService } from './services/todo-application.service';
import { ApiQuery } from './models/ApiQuery';

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
export class AppComponent implements AfterViewInit {
    title = 'Todoapp'
    applications?: TodoApplication[]
    apiQuery: ApiQuery = new ApiQuery()
    constructor(private todoService: TodoApplicationService) { }

    ngAfterViewInit(): void {
        this.todoService.getApplications(this.apiQuery)
            .subscribe(x => {
                if (x?.success && x?.result) {
                    console.log(x.result)
                    this.applications = x.result
                }
            })
    }
    addTodoApplication(todoApplication: any) {
        this.todoService.addApplication(todoApplication)
            .subscribe(x => {
                if (x.success && x.result) {
                    this.applications?.push(x.result)
                }
                else {
                    alert('u suck :)')
                }
            });
    }

}
