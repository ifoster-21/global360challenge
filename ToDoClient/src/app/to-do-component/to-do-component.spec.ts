import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ToDoComponent } from './to-do-component';
import { ToDo, Priority } from '../../api/models/index';
import { inputBinding, outputBinding, signal } from '@angular/core';
import { By } from '@angular/platform-browser';

describe('ToDoComponent', () => {
  let component: ToDoComponent;
  let fixture: ComponentFixture<ToDoComponent>;
  let testDate: Date = new Date(2029, 1, 5, 12, 0, 0);

  const toDo: ToDo = {id:42, title: "Test Title", contents: "Test Contents", priority: 0, completionDate: testDate };

  beforeEach(async () => {
    fixture = TestBed.createComponent(ToDoComponent, {
      bindings: [
        inputBinding('toDo', () => toDo)
      ]
    });
    component = fixture.componentInstance;
    testDate = new Date(2029, 1, 5, 12, 0, 0);
    await fixture.whenStable(); 
  });

  it('should create', () => {
    expect(component).toBeDefined();
  });

  it('should correctly render the title of the passed-in ToDo element', () => {
    const inputToDo = signal(toDo);
    component.toDo = inputToDo as unknown as typeof component.toDo;
    fixture.detectChanges();

    const body: HTMLParagraphElement = fixture.debugElement.query(
      By.css('[data-testid=todo-title]'),
    ).nativeElement;

    expect(body.textContent).toContain('Test Title');
  });

  it('should correctly render the completion date of the passed-in ToDo element', () => {
    const inputToDo = signal(toDo);
    component.toDo = inputToDo as unknown as typeof component.toDo;
    fixture.detectChanges();

    const body: HTMLParagraphElement = fixture.debugElement.query(
      By.css('[data-testid=todo-completion-date]'),
    ).nativeElement;

    expect(body.textContent).toContain('February 5, 2029');
  });

  it('should handle the event thrown when clicking the "delete" button', () => {
    component.deleteToDo.subscribe((toDo: ToDo) => {
      expect(toDo.id).toBe(42);
    });
  });
});
