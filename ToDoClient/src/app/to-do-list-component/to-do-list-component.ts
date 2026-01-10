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
    console.log("Calling loadData");
    this.toDoService.getToDoList().subscribe({
      next: (results) => {
        console.log(`list of results is ${JSON.stringify(results)}`);
        this.toDoList = results;
      },
      error: (e) => console.error(e)
    });
  }

  handleDisplay(e:any) {
    const redirectUrl = `DisplayToDo/${e.id}`;
    this.router.navigate([redirectUrl])
  }

  handleDelete(e:any) {
    this.toDoService.deleteToDo(e.id);
  }
}
