import { Component } from '@angular/core';
import { ToDo, ToDoId } from '../../api/models';
import { ToDoComponent } from '../to-do-component/to-do-component';

@Component({
  selector: 'app-to-do-list-component',
  imports: [ToDoComponent],
  templateUrl: './to-do-list-component.html',
  styleUrl: './to-do-list-component.css',
})
export class ToDoListComponent {
  toDoList:Array<ToDo> = [
    { id: {id: 1} ,title: "Test Title 1", contents: "Test Contents 1", priority: 1, completionDate: new Date()},
    { id: {id: 2}, title: "Test Title 2", contents: "Test Contents 2", priority: 0, completionDate: new Date()},
    { id: {id: 3}, title: "Test Title 3", contents: "Test Contents 3", priority: 2, completionDate: new Date()},
  ];
}
