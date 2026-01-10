import { Component, inject } from '@angular/core';
import { ToDo } from '../../api/models';
import { ToDoComponent } from '../to-do-component/to-do-component';
import { ToDoService } from '../../api/services';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-to-do-list-component',
  imports: [ToDoComponent, AsyncPipe],
  templateUrl: './to-do-list-component.html',
  styleUrl: './to-do-list-component.css',
})
export class ToDoListComponent {
  private readonly toDoService = inject(ToDoService);
  toDoList: Observable<ToDo[]>;

  constructor(private router: Router) {
    this.toDoList = this.toDoService.toDoItemsGet();
  }

  handleDisplay(e:any) {
    // How to deal with routing to get to ToDoDisplay component?
    this.toDoService.selectToDo(e.id);
    this.router.navigate(['ToDo'])
  }

  handleDelete(e:any) {
    this.toDoService.toDoItemDelete(e.id);
    this.toDoList = this.toDoService.toDoItemsGet();
  }
}
