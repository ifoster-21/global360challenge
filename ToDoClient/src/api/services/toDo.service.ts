import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { NewToDo, ToDo } from "../models";
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

    addNewToDo(newToDo: NewToDo): Observable<ToDo> {
        return this.http.post(`${this.apiUrl}ToDoItems`, newToDo);
    }

    deleteToDo(toDoId: number): Observable<ToDo[]> {
        return this.http.delete<ToDo[]>(`${this.apiUrl}ToDoItems/${toDoId}`);
    };
}
