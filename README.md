# NeoGenesis 

Console application for managing genetically engineered dinosaurs in NeoGenesis Park. Built with C# (.NET 9) and Entity Framework Core with PostgreSQL.

---

## Architecture

```
NeoGenesis.App/
├── Data/           # AppDbContext (EF Core)
├── Models/         # Dinosaur, Zone, Sector
├── Repositories/   # Data access layer
├── Services/       # Business logic & validation
├── Helpers/        # ConsoleHelper (UI utilities)
├── UI/             # Menu classes
└── Migrations/     # EF Core migrations
```

The project follows a layered pattern: `UI → Service → Repository → DbContext`

---

## Features

- **Register** a dinosaur with name, species, registration code, age, diet type, tracking device, and location
- **View** all registered dinosaurs
- **Update** a dinosaur's name, species, and age
- **Delete** a dinosaur by ID with confirmation prompt
- Input validation: required fields, age format, numeric parsing
- Color-coded console feedback (success, error, warning)

---

## Models

| Model | Fields |
|---|---|
| `Dinosaur` | Id, Name, Species, RegistrationCode, Age, DietType, TrackingDevice, Location, RegistrationDate, ZoneId |
| `Zone` | Id, Name, SectorId |
| `Sector` | Id, Name |

---

## Tech Stack

- .NET 9 / C#
- Entity Framework Core 9.0.1
- PostgreSQL — Npgsql provider

---

## Getting Started

**Prerequisites:** .NET 9 SDK, access to a PostgreSQL instance.

**1. Clone the repository**

```bash
git clone https://github.com/your-org/NeoGenesis.git
cd NeoGenesis
```

**2. Update the connection string**

Edit `NeoGenesis.App/Data/AppDbContext.cs` and set your PostgreSQL credentials:

```csharp
options.UseNpgsql("Host=...;Database=neogenesis;Username=...;Password=...");
```

**3. Apply migrations**

```bash
dotnet ef database update --project NeoGenesis.App
```

**4. Run the application**

```bash
dotnet run --project NeoGenesis.App
```
