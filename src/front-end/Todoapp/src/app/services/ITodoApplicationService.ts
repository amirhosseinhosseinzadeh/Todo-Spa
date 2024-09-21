import { Observable } from "rxjs";
import { ApiQuery } from "../models/ApiQuery";
import { ToDoApplication } from "../models/todoApplication";

export interface ITodoApplicationService {
    GetApplications(query: ApiQuery): Observable<ToDoApplication[]>;
}
