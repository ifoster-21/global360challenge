import { Routes } from '@angular/router';
import { ToDoListComponent } from './to-do-list-component/to-do-list-component';
import { ToDoDetailComponent } from './to-do-detail-component/to-do-detail-component';

export const routes: Routes = [
  {
    path: '',
    component: ToDoListComponent,
    title: 'Home Page',
  },
  {
    path: 'ToDo',
    component: ToDoDetailComponent,
    title: 'Home Page',
  }
];
