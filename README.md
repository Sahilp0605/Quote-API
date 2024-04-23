# Quote Search Application

## Overview
The Quote Search Application is a project developed to provide a search functionality for quotes based on authors, tags, and quote text. The application utilizes ASP.NET Core Web API for the backend and Blazor Server for the frontend. The data is stored in a SQL Server database.

## Technologies Used
### Backend
- **ASP.NET Core 6 Web API**: Used to create RESTful APIs for retrieving quotes based on search criteria.
- **Entity Framework Core**: Provides object-relational mapping (ORM) to interact with the SQL Server database.
- **C#**: Programming language used for backend development.

### Frontend
- **Blazor Server**: Used to build interactive web user interfaces using C# and .NET instead of JavaScript.
- **Razor Pages**: Provides a simple and powerful page-based programming model for building dynamic web UIs with Blazor.
- **HTML/CSS**: Frontend markup and styling languages used for UI development.

### Database
- **Microsoft SQL Server**: Relational database management system used to store quotes data.
- **T-SQL**: Used to define database schema, tables, and stored procedures.

## Database Schema
The database consists of a single table named `Quotes`, which stores information about quotes including author, tags, and quote text. Here's the schema for the `Quotes` table:

| Column Name | Data Type   | Description                   |
|-------------|-------------|-------------------------------|
| Id          | INT         | Primary key auto-incremented  |
| Author      | NVARCHAR    | Name of the quote's author    |
| Tags        | NVARCHAR    | Tags associated with the quote|
| QuoteText   | NVARCHAR    | Text of the quote             |

## Blazor Server Application
The frontend of the application is built using Blazor Server, allowing for dynamic and interactive user interfaces. Blazor Server enables developers to write interactive web applications using C# instead of JavaScript, providing a seamless integration with the backend ASP.NET Core Web API.

## Getting Started
To run the application locally, follow these steps:
1. Ensure you have Visual Studio 2022 or later installed.
2. Clone this repository to your local machine.
3. Open the solution in Visual Studio.
4. Modify the database connection string in `appsettings.json` to point to your SQL Server instance.
5. Run the database migrations to create the necessary tables using Entity Framework Core:
    ```
    dotnet ef database update
    ```
6. Build and run the solution.

## Usage
Once the application is running, you can access the frontend using your web browser. Use the search functionality to find quotes based on author, tags, or quote text.

## Contributors
- Sahil Patel - FullStack Software Engineer (.Net)
---
