import { Component, input } from '@angular/core';
import { ToDo } from '../../api/models';

@Component({
  selector: 'app-to-do-detail-component',
  imports: [],
  templateUrl: './to-do-detail-component.html',
  styleUrl: './to-do-detail-component.css',
})
export class ToDoDetailComponent {
  toDo = input.required<ToDo>();
}
