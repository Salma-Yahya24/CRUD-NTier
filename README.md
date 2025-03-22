# CRUD N-Tier Application

This is a simple N-Tier architecture CRUD (Create, Read, Update, Delete) application built using ASP.NET MVC. The application follows a clean separation of concerns by dividing the application into three layers:

- **Client (UI Layer)** - Handles the user interface.
- **DAL (Data Access Layer)** - Manages data interaction with the database.
- **Entities (Model Layer)** - Defines the data structures used throughout the application.

## Features
- CRUD Operations for **Product** and **Category**.
- Clean architecture following the N-Tier pattern.
- Unit of Work pattern for efficient database management.
- Bootstrap styling for improved user interface.

## Project Structure
|-- ClsAppNtier.Client (UI Layer) |-- ClsAppNtier.DAL (Data Access Layer) |-- ClsAppNtier.Entities (Model Layer) |-- ClsAppNtier.sln (Solution File)

markdown
Copy
Edit

## Technologies Used
- ASP.NET MVC
- Entity Framework Core
- C#
- Bootstrap (For UI Styling)
- Microsoft SQL Server

## Setup and Installation
1. Clone the repository:
```bash
git clone https://github.com/Salma-Yahya24/CRUD-NTier.git
Open the solution in Visual Studio.

Restore NuGet packages.

Update the connection string in the appsettings.json file.

Run the application.

Usage
Navigate to the Product and Category sections to add, edit, delete, and view items.

License
This project is licensed under the MIT License.

Author
Developed by Salma Yahya. 😊
