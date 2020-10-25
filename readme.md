# Shipping Engine

## Running The Application

### Technical requirements

    1. .NET Core CLI 3.1
    2. Node.js (optional)

### To Run

There are two ways to run the application and tests:

- Use Node.js 'npm run start' and 'npm run tests' in command-line.
- Open the solution with Visual Studio and press F5 (Run) or Ctrl-R, A (Run All Tests)

## Architecture

### Architectural decisions

- File/Folder structure is done followed Domain Driven Design
- The solution is logically divided into 4 services:
  - Shipping service - main service responsible for processing shipments
  - File service - responsible for reading text files
  - Data service - services which holds all the data regarding app, could be replaced by database
  - Pricing - services which calculates prices and discounts for shipments.
- Pricing Service first calculate the prices, then creates a discount using DiscountFactory
based on shipment properties
- The Application has automated tests covering the main parts of the code. ApplicationTests has
a full End-To-End tests which compares every printed line with a line in results file.

### Possible improvements

- Not every service is covered with unit tests
- I am personally not happy with DataService, I feel like InMemory EntityFramework Core Repositories
would have been a better approach rather than coding every method by myself. DataService is messy.
