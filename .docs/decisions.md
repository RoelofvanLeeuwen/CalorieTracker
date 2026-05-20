# Architecture Decision Records — CalorieTracker

## ADR-001 — .NET 10 als doelplatform

**Status:** Geaccepteerd  
**Beslissing:** Gebruik .NET 10 (LTS)  
**Reden:** Meest recente versie; alle gewenste taalfeatures en framework-verbeteringen beschikbaar. `global.json` pinned op 10.0.203.

---

## ADR-002 — .slnx als solution-formaat

**Status:** Geaccepteerd  
**Beslissing:** `CalorieTracker.slnx`  
**Reden:** Beter leesbaar XML-formaat, minder merge-conflicten, native ondersteund in .NET 9+.

---

## ADR-003 — Blazor Interactive Server Rendering

**Status:** Geaccepteerd  
**Beslissing:** Blazor Web App met `@rendermode InteractiveServer` op `<Routes>` in `App.razor`  
**Reden:** Eenvoudigste setup voor interne applicatie; volledige C#-interactiviteit zonder WASM-download. Geen dubbele projectstructuur (Server + Client) nodig.

---

## ADR-004 — EF Core 10 + SQLite

**Status:** Geaccepteerd (ontwikkeling)  
**Beslissing:** SQLite voor lokale ontwikkeling; productie-database nader te bepalen  
**Reden:** Zero-config voor lokale ontwikkeling; eenvoudig te vervangen via configuratie.

---

## ADR-005 — int als primaire sleutel

**Status:** Geaccepteerd  
**Beslissing:** `IEntity` en `EntityBase` gebruiken `int` als PK-type  
**Reden:** Eenvoud; voldoende voor de verwachte schaal van de applicatie.

---

## ADR-006 — GC design system, geen Bootstrap

**Status:** Geaccepteerd  
**Beslissing:** Eigen CSS gebaseerd op `.docs/DefaultTemplate.zip` (Manrope-font, magenta `#E5007D` accent)  
**Reden:** Huisstijl Graafschap College; lichtgewicht; geen JavaScript-afhankelijkheden van Bootstrap of andere UI-frameworks.

---

## ADR-007 — Domain-enums niet in DTO's of UI

**Status:** Geaccepteerd  
**Beslissing:** Domain-enums worden nooit rechtstreeks gebruikt in DTO's, Razor-componenten of API-contracten  
**Reden:** Strikte laagscheiding; UI/API kunnen onafhankelijk evolueren van het domein. Application-enums worden expliciet gemapt via extension methods.
