# BookStore API

## Project Description

The BookStore API is a RESTful web service that allows users to manage books and authors. It provides endpoints for creating, reading, updating, and deleting books and authors. The project uses Entity Framework Core for data access, AutoMapper for object mapping, and follows a clean architecture to ensure separation of concerns.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- AutoMapper
- SQL Server 
- Swagger (for API documentation)

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/your-username/BookStore.git](https://github.com/shuhratrahmonov146/BookStoreApplication.git
    cd BookStore
    ```

2. Set up the database:
    - Ensure your database server is running.
    - Update the connection string in `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=your_server;Database=BookStoreDb;"
    }
    ```

3. Build the project:
    ```sh
    dotnet build
    ```

5. Run the project:
    ```sh
    dotnet run
    ```

### Running the Application

- The API will be available at `https://localhost:5001` or `http://localhost:5000`.
- Swagger UI for testing the API will be available at `https://localhost:5001/swagger`.
