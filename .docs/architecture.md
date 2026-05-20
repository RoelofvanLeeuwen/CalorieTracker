# Architectuur — CalorieTracker

## Overzicht

CalorieTracker gebruikt Clean Architecture met een strikt gelaagde structuur. Lagen mogen alleen naar binnen verwijzen (Web → Application/Infrastructure → Application → Domain).

## Projectstructuur

```
CalorieTracker.slnx
├── src/
│   ├── CalorieTracker.Domain          — Entiteiten, value objects, domeinlogica, domeininterfaces
│   ├── CalorieTracker.Application     — Use cases, DTO's, interfaces voor infrastructuur
│   ├── CalorieTracker.Infrastructure  — EF Core DbContext, repositories, externe services
│   └── CalorieTracker.Web             — Blazor Server-app (InteractiveServer), UI-components
└── tests/
    ├── CalorieTracker.Domain.Tests
    └── CalorieTracker.Application.Tests
```

## Afhankelijkheden

```
Domain        ← geen externe afhankelijkheden
Application   → Domain
Infrastructure → Application (en dus Domain via transitief)
Web           → Application + Infrastructure
Tests         → afhankelijk van het te testen project
```

## Laagverantwoordelijkheden

### Domain
- `IEntity<TKey>` en `EntityBase<TKey>` als basisprimitieven
- Domeinentiteiten (POCO-classes, geen EF-attributen in Domain)
- Value objects
- Domain-enums (mogen **niet** rechtstreeks in DTO's of UI worden gebruikt)

### Application
- Use-case handlers (CQRS via MediatR, of eigen handlers)
- DTO's en view models (nooit Domain-enums; eigen Application-enums via expliciete mapping)
- Interfaces voor repositories en services (geïmplementeerd in Infrastructure)
- `DependencyInjection.cs` registreert Application-services

### Infrastructure
- EF Core `ApplicationDbContext`
- Repository-implementaties
- Migraties
- `DependencyInjection.cs` registreert Infrastructure-services

### Web
- Blazor-pagina's en -componenten
- `MainLayout.razor` — GC shell (appbar, drawer)
- `GcIcon.razor` — SVG-iconcomponent
- `DependencyInjection.cs` of directe registratie in `Program.cs`

## Render mode

`<Routes>` in `App.razor` heeft `@rendermode="InteractiveServer"` — de hele app is interactief.

## Technische keuzes

Zie `.docs/decisions.md` voor ADR's.

## DI-registraties

```csharp
// Program.cs
builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
```

Elke laag levert een eigen static extension class `DependencyInjection`.
