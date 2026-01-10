import { Component, input } from '@angular/core';
import { ToDo } from '../../api/models';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-to-do-component',
  imports: [DatePipe],
  templateUrl: './to-do-component.html',
  styleUrl: './to-do-component.css',
})
export class ToDoComponent {
  toDo = input.required<ToDo>();
}
