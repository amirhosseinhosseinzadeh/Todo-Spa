import { Observable } from "rxjs";
import { ApiQuery } from "../models/ApiQuery";
import { ToDoApplication } from "../models/todoApplication";

export interface ITodoApplicationService {
    getApplications(query: ApiQuery): Observable<ToDoApplication[]>;
    addApplication(application:ToDoApplication): Observable<ToDoApplication>;
}
