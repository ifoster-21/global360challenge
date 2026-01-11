describe('template spec', () => {
  it('displays four todo items with the relevant title and contents and delete button', () => {
    cy.visit('http://localhost:4200/')

    cy.get('ul')
      .first()
      .find('[data-testid=todo-title]')
      .should('contain.text', "Shopping");

    cy.get('ul')
      .first()
      .find('[data-testid=todo-contents]')
      .should('contain.text', "Shopping to be done for dinner.");

    cy.get('ul')
      .first()
      .find('[data-testid=todo-delete]')
      .should('contain.text', "Delete To Do Item");
  })

  it('deletes a todo item and displays three todo items with the relevant title, content and delete button', () => {
    cy.visit('http://localhost:4200/')

    cy.get('ul')
      .find('[data-testid=todo-delete]')
      .first()
      .click();
  })

  it('adds a new todo item and displays that item on the full list screen', () => {

  })

  it('returns to the full list screen without submitting the new item to be added and does not display the new item', () => {

  })
})