import { Component, inject } from '@angular/core';
import { ToDo } from '../../api/models';
import { ToDoComponent } from '../to-do-component/to-do-component';
import { ToDoService } from '../../api/services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-to-do-list-component',
  imports: [ToDoComponent],
  templateUrl: './to-do-list-component.html',
  styleUrl: './to-do-list-component.css',
})
export class ToDoListComponent {
  private readonly toDoService = inject(ToDoService);
  toDoList: ToDo[] = [];

  constructor(private router: Router) {
    this.toDoService.toDoItemsGet();
    this.toDoList = this.toDoService.toDoList;
  }

  handleDisplay(e:any) {
    // How to deal with routing to get to ToDoDisplay component?
    console.log("Handling display event for " + e.id);
    this.toDoService.selectToDo(e.id);
    this.router.navigate(['ToDo'])
  }

  handleDelete(e:any) {
    console.log("Handling delete event for " + e.id);
    this.toDoService.toDoItemDelete(e.id);
    // Page refresh. Routing back to this component again?
  }
}
