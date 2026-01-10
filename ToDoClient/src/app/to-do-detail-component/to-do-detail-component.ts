import { Component, inject, input } from '@angular/core';
import { ToDoService } from '../../api';

@Component({
  selector: 'app-to-do-detail-component',
  imports: [],
  templateUrl: './to-do-detail-component.html',
  styleUrl: './to-do-detail-component.css',
})
export class ToDoDetailComponent {
  private readonly toDoService = inject(ToDoService);
}
