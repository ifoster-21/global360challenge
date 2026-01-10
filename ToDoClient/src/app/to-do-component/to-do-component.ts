import { Component, input, output } from '@angular/core';
import { ToDo, ToDoId } from '../../api/models';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-to-do-component',
  imports: [DatePipe],
  templateUrl: './to-do-component.html',
  styleUrl: './to-do-component.css',
})
export class ToDoComponent {
  toDo = input.required<ToDo>();
  deleteToDo = output<ToDo>();
  displayToDo = output<ToDo>();

  onDisplay(e:any) {
    e.stopPropagation();
    console.log("Called onDisplay");
    this.displayToDo.emit(this.toDo());
  }

  onDelete(e:any) {
    e.stopPropagation();
    console.log("Called onDelete");
    this.deleteToDo.emit(this.toDo());
  }
}
