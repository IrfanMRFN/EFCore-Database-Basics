# Entity Framework Core 10 & SQL Server Basics 🗄️

This repository contains Phase 2 of my comprehensive C# and .NET 10 learning journey. It demonstrates the ability to design, generate, and manipulate a relational SQL Server database entirely through C# code using Entity Framework (EF) Core 10.

## 🚀 Features
* **Automated Schema Generation:** Database tables and relationships are generated directly from C# classes using EF Core Code-First Migrations.
* **Relational Data Management:** Implements a One-to-Many relationship between `Account` and `Transaction` entities.
* **Asynchronous Operations:** All database calls (`FirstOrDefaultAsync`, `SaveChangesAsync`) are completely asynchronous to ensure high performance and non-blocking threads.
* **Eager Loading:** Efficiently retrieves complex, joined data from multiple tables using the `.Include()` method.
* **Unit of Work Pattern:** Ensures data integrity by wrapping multiple database inserts and updates into a single, atomic SQL transaction.

## 🛠️ Tech Stack
* **Language:** C# 14
* **Framework:** .NET 10 (Console Application)
* **ORM:** Entity Framework Core 10
* **Database:** Microsoft SQL Server 2025 Developer Edition
* **Tools:** EF Core CLI (`dotnet-ef`), SQL Server Management Studio (SSMS)

## 🧠 Core Concepts Mastered
* Configuring a `DbContext` and `IDesignTimeDbContextFactory`.
* Mapping C# Models to SQL Tables using `DbSet<T>`.
* Understanding Primary Keys, Foreign Keys, and Navigation Properties.
* Troubleshooting locked assemblies and compiler masking during migrations.
* Writing secure, local connection strings using Windows Authentication (`Trusted_Connection=True`).

## ⚙️ How to Run Locally

1. Ensure you have the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) and a local instance of **SQL Server** installed.
2. Clone this repository:
   ```bash
   git clone [https://github.com/IrfanMRFN/EFCore-Database-Basics.git](https://github.com/IrfanMRFN/EFCore-Database-Basics.git)