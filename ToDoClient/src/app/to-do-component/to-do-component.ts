import { Component, input, output } from '@angular/core';
import { ToDo } from '../../api/models';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-to-do-component',
  imports: [],
  templateUrl: './to-do-component.html',
  styleUrl: './to-do-component.css',
})
export class ToDoComponent {
  toDo = input.required<ToDo>();
  deleteToDo = output<ToDo>();

  onDelete(e:any) {
    e.preventDefault(); // Prevent containing component from redrawing. The re-draw loses the callback event subscription to refresh the UI todo list.
    this.deleteToDo.emit(this.toDo());
  }
}
