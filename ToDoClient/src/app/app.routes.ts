import { Routes } from '@angular/router';
import { ToDoListComponent } from './to-do-list-component/to-do-list-component';
import { AddToDoComponent } from './add-to-do-component/add-to-do-component';

export const routes: Routes = [
  {
    path: '',
    component: ToDoListComponent,
    title: 'Home Page',
  },
  {
    path: 'AddNewToDo',
    component: AddToDoComponent,
    title: 'Home Page',
  }
];
