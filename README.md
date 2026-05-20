# CalorieTracker

Webapplicatie voor het bijhouden van calorie-inname en voedingswaarden.

## Technologie

- .NET 10 · Blazor Interactive Server
- Clean Architecture
- EF Core 10 + SQLite
- GC design system (Graafschap College huisstijl)

## Projectstructuur

```
src/
  CalorieTracker.Domain
  CalorieTracker.Application
  CalorieTracker.Infrastructure
  CalorieTracker.Web
tests/
  CalorieTracker.Domain.Tests
  CalorieTracker.Application.Tests
```

## Ontwikkelen

```bash
dotnet restore
dotnet build
dotnet run --project src/CalorieTracker.Web
```

## Documentatie

Zie `.docs/` voor architectuurbeschrijving, beslissingen en voortgang.
