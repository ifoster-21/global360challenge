import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ToDoListComponent } from './to-do-list-component';
import { ToDoService } from '../../api/services/toDo.service';
import { Observable } from 'rxjs/internal/Observable';
import { ToDo } from '../../api/models';
import { from } from 'rxjs';

class MockToDoService extends ToDoService{
  override getToDoList(): Observable<ToDo[]> {
    const testValues: ToDo[] = [
      {
        id: 1,
        title: "Test Title",
        contents: "Test Contents"
      },
      {
        id: 2,
        title: "Test Title2",
        contents: "Test Contents2"
      }
    ];
    return from([testValues]);
  };
}

describe('ToDoListComponent', () => {
  let component: ToDoListComponent;
  let fixture: ComponentFixture<ToDoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ToDoListComponent],
      providers: [                   
        { provide: ToDoService, useClass: MockToDoService },
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToDoListComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
