# Library Management System (WinForms & VB.NET)

A desktop application built with **VB.NET**, **WinForms**, and **SQL Server**. The project demonstrates modern software engineering principles toward a clean, maintainable, and fully testable architecture.

---

## 🛠️ Key Architectural Highlights

* **Model-View-Presenter (MVP) Pattern**: Decouples the presentation layer (`WinForms`) from business logic. Forms are intentionally "dumb" and only handle rendering and user input routing.
* **Composition Root**: Object graphs (Presenters, Repositories, Validators) are composed at the application's entry points without heavy service locators.
* **Asynchronous I/O (`Async/Await`)**: Database opertions execute asynchronously (`SqlCommand.ExecuteReaderAsync`, `ExecuteNonQueryAsync`) to prevent UI freezing and ensure a responsive experience.
* **Notification Pattern Validation**: Custom, open/closed (SOLID) validation framework. Reusable rules (`StringLengthRule`, `ExternalIsbnRule`) validate objects without throwing expensive exceptions for control flow.
* **Security First**: Authentication uses **PBKDF2** with individual salts for password hashing, and all SQL queries are fully parameterized to prevent SQL Injection.

---

## 🏗️ Solution Structure

```text
LibraryMS/
├── Database/               # DDL Scripts & Dummy Data (script.sql)
├── Domain/                 # Core Entities (Book, User)
├── Data/                   # Data Access Layer / Repositories (ADO.NET)
├── Infrastructure/         # Cross-cutting concerns (Security, Validation Engine)
├── Views/                  # Abstraction contracts (IMainView) & WinForms Views
├── Presenters/             # Presentation Logic & Orchestration
└── Tests/                  # Unit Tests for Presenters and Domain Logic
```

🚀 Getting Started

    Database Setup:

        Execute the script located in Database/script.sql on your local SQL Server instance.

        The script initializes the database schema and populates it with dummy data for immediate testing.

        Startup file is Program.vb

    Configuration:

        Update the connection string in Data/DatabaseHelper.vb (or App.config) to point to your SQL Server instance.

    Build & Run:

        Open the solution in Visual Studio, restore dependencies, and press F5.

🧪 Testing

The separation enforced by the MVP pattern allows presentation and business logic to be tested independently of the WinForms GUI. Unit tests mock IMainView contracts to verify presenter behavior, validation execution, and error handling flow.