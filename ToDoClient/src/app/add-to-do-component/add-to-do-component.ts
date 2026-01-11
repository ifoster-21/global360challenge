import { Component } from '@angular/core';
import { NewToDo, Priority } from '../../api/models';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToDoService } from '../../api/services/toDo.service';

@Component({
  selector: 'app-add-to-do-component',
  imports: [FormsModule],
  templateUrl: './add-to-do-component.html',
  styleUrl: './add-to-do-component.css',
})
export class AddToDoComponent {
  newToDo: NewToDo = {title: '', contents: '', priority: Priority.Low, completionDate: new Date()};

  constructor(private toDoService: ToDoService, private router: Router){
    
  }

  cancelNewToDo() {
    this.router.navigate(['']);
  }

  saveNewToDo() {
    console.log("About to save thing " + JSON.stringify(this.newToDo));
    this.toDoService.addNewToDo(this.newToDo).subscribe({
      next: (results) => {
        console.log(JSON.stringify(results));
        this.router.navigate(['']);
      },
      error: (e) => console.error(e)
    });
  }
}
