import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { ApiQuery } from '../models/ApiQuery';
import { ToDoApplication } from '../models/todoApplication';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ITodoApplicationService } from './ITodoApplicationService';

@Injectable({
    providedIn: 'root'
})

export class TodoApplicationService implements ITodoApplicationService {

    constructor(private client: HttpClient) { }

    getApplications(query: ApiQuery): Observable<ToDoApplication[]> {
        let apiFullAddress = environment.host + 'api/TodoApplication/Getlist'
        return this.client.post<ToDoApplication[]>(apiFullAddress, query)
    }

    addApplication(application:ToDoApplication): Observable<ToDoApplication>{
        const apiFullAddress = environment.host + 'api/TodoApplication/AddTodoApplication'
        let header = {
            headers: ({
                'Content-Type':'application/json'
            })
        }
        return this.client.post(apiFullAddress,application,header)
    }
}
