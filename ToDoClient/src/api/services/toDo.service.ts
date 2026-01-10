import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ToDo } from "../models";
import { Observable } from "rxjs/internal/Observable";
import { BehaviorSubject } from "rxjs/internal/BehaviorSubject";

@Injectable({ providedIn: "root" })
export class ToDoService {
    // TODO: Put into environment settings.
    BASE_PATH_DEFAULT="http://localhost:5124/"
    toDoList: ToDo[] = [];
    selectedToDo: ToDo | undefined = undefined;

    private updateSubject = new BehaviorSubject<boolean>(false);
    update$ = this.updateSubject.asObservable();

    constructor(private http: HttpClient) {
    }

    getToDoList(): Observable<ToDo[]> {
        return this.http.get<ToDo[]>(`${this.BASE_PATH_DEFAULT}ToDoItems`);
    };

    deleteToDo(toDoId: number) {
        this.http.delete(`${this.BASE_PATH_DEFAULT}ToDoItems/${toDoId}`).subscribe({
            next: () => this.updateSubject.next(true),
            error: (e) => console.error(e)
        });
    };
}
