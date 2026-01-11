# global360challenge

Code Challenge for Global 360

# To run tests

- Use script 'run_unit_tests.ps1' to run all local unit tests.
- Use script 'run_api_tests.ps1' to run all integration API tests.

# To run

- Use script 'run_todo_app.ps1' to run the server and the client angular app.

# For brevity

- Avoided HTTPS interaction. Normally would be handled at Web API layer.
- Avoided any auth interaction. Normally would be handled at Web API layer.
- Bare minimal CSS bootstrap styling.
- Incomplete test coverage for Angular components. Sufficient to demonstrate working success of ng test.
- Demonstration of Cypress initial test as smoke test, but no extensive happy-path tests.
