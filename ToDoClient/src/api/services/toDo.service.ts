import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ToDo } from "../models";

@Injectable({ providedIn: "root" })
export class ToDoService {
    // TODO: Put into environment settings.
    BASE_PATH_DEFAULT="http://localhost:5124/"
    toDoList: ToDo[] = [];
    selectedToDo: ToDo | undefined = undefined;

    constructor(private http: HttpClient) {
    }

    toDoItemsGet = async () => {
        // TODO: Workout out how to handle errors in latest angular pattern.
        this.http.get<ToDo[]>(`${this.BASE_PATH_DEFAULT}ToDoItems`).subscribe((result) => {
            this.toDoList = result;
        });
    };

    toDoItemDelete = async (toDoId: number) => {
        // TODO: Workout out how to handle errors in latest angular pattern.
        this.http.delete(`${this.BASE_PATH_DEFAULT}ToDoItems/${toDoId}`).subscribe((result) => {
            console.log(JSON.stringify(result));
            this.selectedToDo = undefined;
        });
    };

    selectToDo(toDoId: number) {
        const newSelectionOptions = this.toDoList.filter((t) => t.id === toDoId);
        if(newSelectionOptions.length === 1) {
            this.selectedToDo = newSelectionOptions[0];
        } else {
            // TODO: Error handling here.
        }
    }
}
