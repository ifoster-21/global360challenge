describe('template spec', () => {
  it('displays four todo items with the relevant title and contents and delete button', () => {
    cy.visit('http://localhost:4200/')

    cy.get('app-to-do-component')
      .should('have.length', 4);

    cy.get('app-to-do-component')
      .first()
      .find('[data-testid=todo-title]')
      .should('contain.text', "Shopping");

    cy.get('app-to-do-component')
      .first()
      .find('[data-testid=todo-contents]')
      .should('contain.text', "Shopping to be done for dinner.");

    cy.get('app-to-do-component')
      .first()
      .find('[data-testid=todo-delete]')
      .find('i')
      .should('have.class', 'bi-trash');
  })

  it('deletes a todo item and displays three todo items with the relevant title, content and delete button', () => {
    cy.visit('http://localhost:4200/')

    cy.get('app-to-do-component')
      .should('have.length', 4);

    cy.get('app-to-do-component')
      .first()
      .find('[data-testid=todo-delete]')
      .click();

    cy.get('app-to-do-component')
      .should('have.length', 3);
  })

  it('adds a new todo item and displays that item on the full list screen', () => {
    cy.visit('http://localhost:4200/')

    cy.get('app-to-do-component')
      .should('have.length', 3);

    const titleToAdd = 'New Test To Do Item';
    const contentToAdd = 'New Test To Do Content';

    cy.get('app-to-do-list-component')
      .first()
      .find('[data-testid=add-new-to-do]')
      .click();

    cy.visit('http://localhost:4200/AddNewToDo');

    cy.get('input[name="title"]').type(titleToAdd);
    cy.get('input[name="contents"]').type(contentToAdd);

    cy.get('button')
      .contains('Save New ToDo')
      .click();

    cy.get('app-to-do-component')
      .should('have.length', 4);
  })
/*
  it('returns to the full list screen without submitting the new item to be added and does not display the new item', () => {

  })
  */
})