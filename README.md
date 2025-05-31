ProductCatalogAPI
A robust, extensible ASP.NET Core Web API for managing product catalogs, categories, and users, built with modern .NET 8 and C# 12 features. The solution follows clean architecture principles, leverages MediatR for CQRS and notifications, and is designed for scalability, maintainability, and testability.
---
Table of Contents
•	#features
•	#architecture-overview
•	#project-structure
•	#getting-started
•	#api-usage
•	#logging-with-seq
•	#contributing
•	#license
---
Features
•	Product Management: CRUD operations for products with category association.
•	Category Management: Manage product categories.
•	User Management: Role-based authorization and authentication.
•	CQRS Pattern: Command and Query separation using MediatR.
•	Event Notifications: Decoupled event handling for actions like product addition.
•	Logging: Centralized application logging with event-driven log creation.
•	Global Error Handling: Consistent error responses and exception management.
•	Pagination: Efficient data paging for large result sets.
•	Extensible Repository Pattern: Generic repository for data access abstraction.
---
Architecture Overview
The solution is structured around Clean Architecture and CQRS (Command Query Responsibility Segregation) principles:
•	API Layer: Exposes RESTful endpoints using ASP.NET Core controllers. Handles HTTP requests, model validation, and response formatting.
•	Features Layer: Contains business logic grouped by domain features (e.g., Products, Categories). Each feature includes Commands, Queries, Handlers, and Events.
•	Common Layer: Shared utilities, middleware, base classes, and infrastructure (e.g., logging, error handling, repositories).
•	Data Access Layer: Uses Entity Framework Core for database operations, abstracted via repositories.
•	MediatR: Decouples request handling (commands/queries) and notifications (events), promoting single responsibility and testability.
•	Event Handlers: Listen for domain events (e.g., ProductAddedEvent) and perform side effects such as logging.
Key Patterns & Technologies:
•	Repository Pattern: Abstracts data access for testability and flexibility.
•	MediatR: Implements CQRS and event-driven architecture.
•	Dependency Injection: All services and handlers are registered for DI.
•	Global Middleware: Handles cross-cutting concerns like error handling and logging.
---
Project Structure
ProductCatalogAPI/
│
├── Common/
│   ├── Middlewares/
│   ├── Repositories/
│   ├── Helpers/
│   └── Data/
├── Features/
│   ├── Products/
│   ├── Common/
│   │   ├── AppLogs/
│   │   └── ...
│   └── ...
├── Entities/
├── Controllers/
├── GlobalUsings.cs
├── Program.cs
└── appsettings.json
---
Getting Started
Prerequisites
 •	.NET 8 SDK
 •	SQL Server or compatible database
Setup
1.	Clone the repository:
   git clone https://github.com/yourusername/ProductCatalogAPI.git
   cd ProductCatalogAPI
2.	Configure the database:
 •	Update the connection string in appsettings.json.
3.	Apply migrations:
    dotnet ef database update
4.	Run the API:
      dotnet run
5.	Access Swagger UI:
•	Navigate to https://localhost:5001/swagger for interactive API documentation.
---
Logging with Seq
This project supports structured, centralized logging using Seq, a modern log server for .NET applications. Seq enables real-time log collection, searching, filtering, and visualization, making it easier to monitor application health and diagnose issues.
 •	Event Logging: Key business events (such as product additions) are logged through the application’s event and command pipeline. For example, when a product is added, a ProductAddedEvent is handled by ProductAddedEventHandler, which      creates a structured log entry.
 •	Centralized Storage: Logs can be sent to a Seq server, allowing you to view and analyze them in a single, searchable interface.
 •	Structured Data: Logs are written with context (such as product name, ID, and creation date), making it easy to filter and correlate events.
Example: Product Addition Log
 Product Added: {ProductName} with ID: {ProductId} at {CreationDate}
Setting Up Seq:
1.	Install Seq from https://datalust.co/download.
2.	Configure your logger (e.g., Serilog) to write to Seq:
      Log.Logger = new LoggerConfiguration()
       .WriteTo.Seq("http://localhost:5341")
       .CreateLogger();
3.	Open the Seq UI (default: http://localhost:5341) to search, filter, and visualize your application logs.
Seq helps you gain deep insights into your application’s behavior, making monitoring and troubleshooting efficient and effective.
---
Contributing
Contributions are welcome! Please open issues or submit pull requests for improvements and bug fixes.
1.	Fork the repository.
2.	Create a new branch (git checkout -b feature/your-feature).
3.	Commit your changes.
4.	Push to your fork and submit a pull request.
