import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { ApiQuery } from '../models/ApiQuery';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ITodoApplicationService } from './ITodoApplicationService';
import { ApiResult } from '../models/ApiResult';
import { TodoApplication } from '../models/todoApplication';

@Injectable({
    providedIn: 'root'
})

export class TodoApplicationService implements ITodoApplicationService {

    constructor(private client: HttpClient) { }

    getApplications(query: ApiQuery): Observable<ApiResult<TodoApplication[]>> {
        let apiFullAddress = environment.host + 'api/TodoApplication/Getlist'
        return this.client.post<ApiResult<TodoApplication[]>>(apiFullAddress, query)
    }

    addApplication(application: TodoApplication): Observable<ApiResult<TodoApplication>> {
        const apiFullAddress = environment.host + 'api/TodoApplication/Add'
        let header = {
            headers: ({
                'Content-Type': 'application/json'
            })
        }
        return this.client.post<ApiResult<TodoApplication>>(apiFullAddress, application, header)
    }
    
}
