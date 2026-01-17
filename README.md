# global360challenge

Code Challenge for Global 360

## Requirements

- Assumes DotNet 10.0.100
- Assumes Node 24.11.1
- Assumes Npm 11.6.2
- Assumes Angular 21.0.0

## To run tests

- Use script 'run_unit_tests.ps1' to run all local unit tests.
- Use script 'run_api_tests.ps1' to run all integration API tests.

## To run

- Use script 'run_todo_app.ps1' to run the server and the client angular app.

## Test breakdown

- Repository tests. Unit test-level, as using InMemory implementation for the persistence layer. This verifies the storage system correctly works to the requirements.
- Service tests. Minimal behaviour here, but will exericise business-logic and validation rules for functionality.
- API tests. End-to-end through the API layer. Used to verify all data communication works correctly and, when implemented, verifies Authentication and Authorisation behaviour is correctly followed.
- Angular component tests. Individual components to verify components display correctly and signal/emit as expected.
- Cypress tests. End-to-end 'happy path' smoke tests to ensure full system hangs together from user interaction through to data storage access.

## For brevity

- Avoided HTTPS interaction. Normally would be handled at Web API layer.
- Avoided any auth interaction. Normally would be handled at Web API layer.
- Bare minimal CSS bootstrap styling.
- Incomplete test coverage for Angular components. Sufficient to demonstrate working success of ng test.
- Demonstration of Cypress initial test as smoke test, but no extensive happy-path tests.

## Known bugs

- On initial page load, 'Delete To Do Item' button does not remove the ToDo from the viewable list until a page refresh is done. Page refresh can be done via browser, or via 'Add New ToDo' and returning to the main page.
  - Bug fix for above. 'e.preventDefault();' is used to prevent the default behaviour of the 'click' event on the 'delete' button. This default behaviour causes the containing component to re-draw, and this drops the subscription of the 'next': callback handler on the delete event so the update returned from the delete call is not applied as the function is lost.
