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
    applications: TodoApplication[] = []
    apiQuery: ApiQuery = new ApiQuery()
    constructor(private todoService: TodoApplicationService) { }

    ngAfterViewInit(): void {
        this.todoService.getApplications(this.apiQuery)
            .subscribe(x => {
                if (x?.success && x?.result) {
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
                    alert(x.error)
                }
            });
    }

    delete(todoApplicationId: number): void {
        this.todoService.deleteApplication(todoApplicationId)
            .subscribe(x => {
                if (x.success) {
                    let removedItemIndex = this.applications?.findIndex(x => x.id === todoApplicationId)
                    if (removedItemIndex)
                        this.applications?.splice(removedItemIndex, 1)
                }
                else {
                    alert(x.error)
                }
            });
    }

    toggleStatus(todoApplication: TodoApplication): void {
        let itemIndex = this.applications.indexOf(todoApplication)
        this.todoService.toggleApplicationStatus(todoApplication?.id ?? 0)
            .subscribe(x => {
                if (x.success) {
                    todoApplication.isActive = !todoApplication.isActive
                    this.applications.splice(itemIndex, 1, todoApplication)
                }
                else {
                    alert(x.error)
                }
            })
    }

    update(todoApplication: TodoApplication): void {
        this.todoService.editApplication(todoApplication)
            .subscribe(x => {
                if (x.success) {
                    let index = this.applications.indexOf(
                        this.applications.find(x => x?.id ?? 0 === todoApplication?.id ?? 0) ?? new TodoApplication()
                    )
                    this.applications.splice(index - 1, 1, x.result)
                }
                else {
                    alert(x.error)
                }
            })
    }
}
