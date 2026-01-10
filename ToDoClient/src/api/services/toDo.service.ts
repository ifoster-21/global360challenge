import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ToDo } from "../models";
import { Observable } from "rxjs/internal/Observable";
import { environment } from '../../environments/environment';

@Injectable({ providedIn: "root" })
export class ToDoService {
    private apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    getToDoList(): Observable<ToDo[]> {
        return this.http.get<ToDo[]>(`${this.apiUrl}ToDoItems`);
    };

    deleteToDo(toDoId: number): Observable<Object> {
        return this.http.delete(`${this.apiUrl}ToDoItems/${toDoId}`);
    };
}
