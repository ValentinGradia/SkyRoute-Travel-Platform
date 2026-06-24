# SkyRoute — Travel Platform (Backend)

## Build & Test
```bash
dotnet restore
dotnet build
dotnet test TestProject1/TestProject1.csproj
```

## Key facts
- **Framework:** .NET 10 / ASP.NET Core 10, attribute routing
- **Database:** EF Core **InMemory** only (`AppDbContext`). No migrations, no persistence across restarts.
- **Dev server:** `http://localhost:5182` / `https://localhost:7105`
- **CORS:** allows `http://localhost:4200` (Angular dev server)

## Architecture layers
| Layer | Directory |
|-------|-----------|
| Controllers | `Controllers/` |
| Services | `Services/` |
| Providers (Strategy) | `Providers/` |
| Chain of Responsibility | `ChainCabins/` |
| Models / DTOs | `Models/`, `DTOs/` |
| DB Context | `Data/` |
| Middleware | `Middleware/` |

## Design patterns
- **Strategy:** `IFlightProvider` → `BaseFlightProvider` → `GlobalAirProvider`, `BudgetWindsProvider`. `ArcticAirProvider` exists but **not registered** in DI.
- **Chain of Responsibility:** `EconomyHandler` → `BusinessHandler` → `FirstClassHandler` for cabin checks.

## Conventions & gotchas
- Controllers use **primary constructors** (C# 12) for DI.
- All service methods are **async** — controllers use `await`, never `.Result`.
- Services registered both by interface and concrete type in DI.
- JSON serialization: string enums, case-insensitive properties.
- Swagger/OpenAPI enabled in Development mode.
- `Passenger` entity and `PassengerDTO` defined but **not used** in any flow.
- Seed data bug: flight GA300 has `CountryDestination = "Peru"` for destination JFK.
- `.http` test file references `/weatherforecast` — no longer exists.

## Testing
- **Framework:** xUnit + Moq, project in `TestProject1/`.
- Some test packages (Moq, xunit.assert) in main `.csproj` too — unusual but functional.
