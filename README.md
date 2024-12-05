# KanzWay Screening API

This ASP.NET Core Web API project implements an endpoint that generates a list of strings based on certain rules for a given input number.

## API Endpoint

The API provides a GET endpoint '/api/v1/screening/{number}' that accepts a number as input and returns a list of strings based on the following rules:
- If the number is divisible by 3, "Kanz" is added to the list.
- If the number is divisible by 5, "Way" is added to the list.
- If the number is divisible by both 3 and 5, "KanzWay" is added to the list.
- For all other numbers, the number itself is added to the list.

## Getting Started

To set up the project locally, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution file in Visual Studio.
3. Build the solution to restore packages.
4. Run the project.

## Testing

The project includes unit tests to cover different scenarios for the '/api/v1/screening/{number}' endpoint. To run the tests:
1. Navigate to the 'Tests' folder.
2. Run the tests using Visual Studio's Test Explorer or the 'dotnet test' command.

## Project Structure

The project structure is as follows:
- 'Controllers': Contains the 'ScreeningController.cs' file with the API endpoint implementation.
- 'ScreeningTests': Includes test files to test the API endpoint.
- 'README.md': This file providing information about the project.

## Author

Eng Kareem Saeed
