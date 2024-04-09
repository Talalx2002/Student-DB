# Student Database

## Overview

The Student Database project is a simple C# application designed to store and manage student information. It offers basic CRUD (Create, Read, Update, Delete) operations and utilizes SQL as its backend database. The application includes security measures to prevent SQL injection attacks and ensure the integrity of student data.

## Key Features

- **CRUD Operations**: Perform basic CRUD operations to manage student records.
- **SQL Backend**: Utilizes SQL as the backend database for data storage.
- **Security Measures**: Implements security checks to prevent SQL injection attacks and ensure data integrity.
- **User-friendly Interface**: Provides a simple and intuitive interface for easy interaction.
- **Data Validation**: Includes validation mechanisms to ensure the accuracy and consistency of student information.

## Requirements

- .NET Framework
- SQL Server (or compatible database server)
- Visual Studio (or compatible C# IDE)

## Installation

1. Clone the repository.
2. Open `StudentDb.sln` in Visual Studio.
3. Build the solution.
4. Configure database connection in `app.config`.
5. Run the application or deploy to preferred environment.

## Usage

1. Launch the application.
2. Use the menu to access CRUD operations.
3. Input student information and perform desired operation.
4. Ensure to handle any errors or exceptions encountered during operation.
5. Utilize security features to prevent SQL injection attacks.

## Security Measures

- **Parameterized Queries**: Utilizes parameterized queries to prevent SQL injection attacks by separating SQL code from user input.
- **Input Sanitization**: Implements input sanitization techniques to remove or escape potentially harmful characters from user input.
- **Error Handling**: Includes error handling mechanisms to gracefully handle unexpected scenarios and prevent information leakage.

## Contributing

Contributions welcome! Open issues or submit pull requests for improvements.

## License

This project is licensed under the [MIT License](LICENSE).
