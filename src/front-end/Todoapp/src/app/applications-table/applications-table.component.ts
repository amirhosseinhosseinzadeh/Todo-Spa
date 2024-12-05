import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms'
import { TableModule } from 'primeng/table'
import { CheckboxModule } from 'primeng/checkbox';
import { Button } from 'primeng/button';
import { TodoApplication } from '../models/todoApplication';
import { DialogModule } from 'primeng/dialog';
import { CalendarModule } from 'primeng/calendar';

@Component({
    selector: 'todo-applications-table',
    standalone: true,
    imports: [
        TableModule,
        CheckboxModule,
        CommonModule,
        FormsModule,
        Button,
        DialogModule,
        CalendarModule
    ],
    templateUrl: './applications-table.component.html',
    styleUrl: './applications-table.component.css'
})
export class ApplicationsTableComponent {
    @Input() applicationList: TodoApplication[] = []
    @Output('update') update: EventEmitter<TodoApplication>
    @Output('toggleStatus') toggleStatus: EventEmitter<TodoApplication>
    @Output('delete') delete: EventEmitter<number>
    editDialogVisible: boolean = false
    selectedApplication: TodoApplication = {}

    constructor() {
        this.delete = new EventEmitter<number>
        this.toggleStatus = new EventEmitter<TodoApplication>
        this.update = new EventEmitter<TodoApplication>
    }

    attemptToDelete(e: MouseEvent): void {
        let index = this.getElementIndexInTable(e)
        if (index < 0) {
            alert('Item not found')
            return
        }
        let selectedApplication = this.applicationList[index - 1]
        if (selectedApplication)
            this.delete?.next(selectedApplication.id ?? 0)
    }

    attemptToToggleStatus(e: MouseEvent): void {
        var index = this.getElementIndexInTable(e)
        if (index < 0) {
            alert('Item not found!')
            return
        }
        let todoApplication = this.applicationList[index - 1]
        this.toggleStatus.next(todoApplication)
    }

    showEditDialog(e: MouseEvent) {
        let target: HTMLElement = e.target as HTMLElement
        let index = target.closest('tr')?.rowIndex ?? 0
        let todoApplication = this.applicationList[index - 1]
        if (!todoApplication) {
            alert('Item not found!')
            return
        }
        this.selectedApplication = new TodoApplication()
        this.selectedApplication.anounceDate = new Date(todoApplication.anounceDate)
        this.selectedApplication.id = todoApplication.id
        this.selectedApplication.title = todoApplication.title
        this.selectedApplication.description = todoApplication.description
        this.selectedApplication.isActive = todoApplication.isActive
        this.editDialogVisible = true
    }

    dateToString(date: Date): string {
        return date?.toString() ?? ''
    }

    attemptToUpdate(): void {
        this.editDialogVisible = false
        this.update.next(this.selectedApplication)
    }

    private getElementIndexInTable(e: MouseEvent): number {
        let target: HTMLElement = e.target as HTMLElement
        let index = target.closest('tr')?.rowIndex ?? -1
        return index
    }
}
