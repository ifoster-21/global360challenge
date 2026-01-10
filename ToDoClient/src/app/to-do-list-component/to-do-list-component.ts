import { Component, inject, OnInit } from '@angular/core';
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
  toDoList: ToDo[] = [];

  constructor(private toDoService: ToDoService, private router: Router) {
  }

  ngOnInit() {
    // TODO: Error handling pattern
    this.toDoService.update$.subscribe(() => this.loadData());
    this.loadData();
  }

  loadData() {
    this.toDoService.getToDoList().subscribe({
      next: (results) => {
        this.toDoList = results;
      },
      error: (e) => console.error(e)
    });
  }

  handleDelete(e:any) {
    this.toDoService.deleteToDo(e.id).subscribe({
      next: (result) => this.toDoList = result as any as ToDo[],
      error: (e) => console.log(e)
    });
  }
}
