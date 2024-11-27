import { Observable } from "rxjs";
import { ApiQuery } from "../models/ApiQuery";
import { TodoApplication } from "../models/todoApplication";
import { ApiResult } from "../models/ApiResult";

export interface ITodoApplicationService {
    getApplications(query: ApiQuery): Observable<ApiResult<TodoApplication[]>>;
    addApplication(application: TodoApplication): Observable<ApiResult<TodoApplication>>;
}
