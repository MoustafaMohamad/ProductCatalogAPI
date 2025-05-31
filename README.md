# ProductCatalogAPI

A robust, extensible ASP.NET Core Web API for managing product catalogs, categories, and users, built with modern .NET 8 and C# 12 features. The solution follows clean architecture principles, leverages MediatR for CQRS and notifications, and is designed for scalability, maintainability, and testability.

---

## Table of Contents

- [Features](#features)
- [Architecture Overview](#architecture-overview)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [API Usage](#api-usage)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Product Management:** CRUD operations for products with category association.
- **Category Management:** Manage product categories.
- **User Management:** Role-based authorization and authentication.
- **CQRS Pattern:** Command and Query separation using MediatR.
- **Event Notifications:** Decoupled event handling for actions like product addition.
- **Logging:** Centralized application logging with event-driven log creation.
- **Global Error Handling:** Consistent error responses and exception management.
- **Pagination:** Efficient data paging for large result sets.
- **Extensible Repository Pattern:** Generic repository for data access abstraction.

---

## Architecture Overview

The solution is structured around **Clean Architecture** and **CQRS** (Command Query Responsibility Segregation) principles:

- **API Layer:** Exposes RESTful endpoints using ASP.NET Core controllers. Handles HTTP requests, model validation, and response formatting.
- **Features Layer:** Contains business logic grouped by domain features (e.g., Products, Categories). Each feature includes Commands, Queries, Handlers, and Events.
- **Common Layer:** Shared utilities, middleware, base classes, and infrastructure (e.g., logging, error handling, repositories).
- **Data Access Layer:** Uses Entity Framework Core for database operations, abstracted via repositories.
- **MediatR:** Decouples request handling (commands/queries) and notifications (events), promoting single responsibility and testability.
- **Event Handlers:** Listen for domain events (e.g., `ProductAddedEvent`) and perform side effects such as logging.

**Key Patterns & Technologies:**
- **Repository Pattern:** Abstracts data access for testability and flexibility.
- **MediatR:** Implements CQRS and event-driven architecture.
- **Dependency Injection:** All services and handlers are registered for DI.
- **Global Middleware:** Handles cross-cutting concerns like error handling and logging.

---

## Project Structure


---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server or compatible database

### Setup

1. **Clone the repository:**
 
3. **Configure the database:**
   - Update the connection string in `appsettings.json`.

4. **Apply migrations:**
 
5. **Run the API:**
     

5. **Access Swagger UI:**
   - Navigate to `https://localhost:5001/swagger` for interactive API documentation.

---

---

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements and bug fixes.

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes.
4. Push to your fork and submit a pull request.

---
     
