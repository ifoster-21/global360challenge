import { Routes } from '@angular/router';
import { ToDoListComponent } from './to-do-list-component/to-do-list-component';

export const routes: Routes = [
  {
    path: '',
    component: ToDoListComponent,
    title: 'Home Page',
  }
];
