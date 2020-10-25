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
        * Shipping Service - main service responsible for processing shipments
        * File Service
