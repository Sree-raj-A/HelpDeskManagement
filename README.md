# Help Desk Ticket Management System

A layered, full-stack support-ticket platform built on **ASP.NET Core MVC**, **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**. It gives users a clean interface for creating, tracking, and resolving help desk tickets from end to end.

---

## Overview

| | |
|---|---|
| **Type** | Full-stack web application |
| **Backend** | ASP.NET Core Web API |
| **Frontend** | ASP.NET Core MVC |
| **Database** | SQL Server via Entity Framework Core |
| **Architecture** | Layered, Repository Pattern, Dependency Injection |
| **Testing** | xUnit + Moq |
| **Containerization** | Docker |

---

## What It Does

The system covers the full lifecycle of a support ticket:

1. **Dashboard** — live statistics on ticket volume and status
2. **Create** — log new support tickets
3. **Browse** — view the full ticket list
4. **Inspect** — drill into individual ticket details
5. **Update** — edit ticket information as it progresses
6. **Resolve** — delete tickets once closed out
7. **Filter** — narrow the list to Open or Closed tickets

Underneath the UI, a RESTful Web API exposes the same functionality, built with a repository pattern and dependency injection throughout.

---

## Technology

**Languages & Frameworks:** C#, ASP.NET Core MVC, ASP.NET Core Web API, Entity Framework Core

**Data:** SQL Server

**Infrastructure & Tooling:** Docker, HttpClient, Git

**Testing:** xUnit, Moq

---

## Repository Layout

```
HelpDeskManagement/
├── HelpDesk.Api/          → Web API project
│   ├── Controllers/
│   ├── Models/
│   ├── Data/
│   ├── Repositories/
│   └── Services/
├── HelpDesk.Mvc/          → MVC front-end project
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   └── Views/
├── HelpDesk.Tests/        → xUnit test suite
└── HelpDeskManagement.sln
```

---

## Running the Project

**Requirements:** .NET 10 SDK, SQL Server, Docker Desktop, Visual Studio or VS Code

**1. Clone it**
```bash
git clone https://github.com/Sree-raj-A/HelpDeskManagement.git
cd HelpDeskManagement
```

**2. Start the API**
```bash
cd HelpDesk.Api
dotnet run
```

**3. Start the MVC app** (in a separate terminal)
```bash
cd HelpDesk.Mvc
dotnet run
```

**4. Run the tests**
```bash
cd HelpDesk.Tests
dotnet test
```

---

## Why It's Built This Way

- Clean separation of concerns via layered architecture
- Repository pattern keeps data access decoupled from business logic
- Dependency injection throughout for testability and flexibility
- RESTful API design for straightforward integration
- Dashboard analytics for at-a-glance ticket health
- Full unit test coverage using xUnit and Moq

---

## Author

**Sreeraj A**
ID: IN26013435
GitHub: [Sree-raj-A](https://github.com/Sree-raj-A)
