import { Component, inject, OnInit, signal } from '@angular/core';
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
export class ToDoListComponent implements OnInit {
  toDoList = signal<ToDo[]>([]);

  constructor(private toDoService: ToDoService, private router: Router) {
  }

  ngOnInit() {
    // TODO: Error handling pattern
    this.loadData();
  }

  loadData() {
    this.toDoService.getToDoList().subscribe({
      next: (results) => {
        this.toDoList.update(() => { return results; });
      },
      error: (e) => console.error(e)
    });
  }

  handleDelete(e:any) {
    this.toDoService.deleteToDo(e.id).subscribe({
      next: (result) => {
        this.toDoList.update(() => { return result as any as ToDo[];});
      },
      error: (e) => console.log(e)
    });
  }

  onAddNew(e:any) {
    this.router.navigate(['/AddNewToDo']);
  }
}
