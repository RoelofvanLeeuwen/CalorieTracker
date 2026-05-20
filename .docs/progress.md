# Voortgang — CalorieTracker

## Huidige fase

**Fase 1: Initiële setup** — bezig (2026-05-20)

## Fase 1 — Initiële setup

- [x] Documentatiebestanden aangemaakt (architecture.md, decisions.md, progress.md, specification.md)
- [x] .gitignore en global.json aangemaakt
- [x] Git-repository geïnitialiseerd en main gepusht naar GitHub
- [x] development aangemaakt en gepusht
- [x] Clean Architecture-baseline (Domain / Application / Infrastructure / Web / Tests)
- [x] Blazor .Web shell met GC design (MainLayout, GcIcon, app.css)
- [x] Bouw slaagt zonder fouten (0 errors, 0 warnings)

## Fase 2 — Scope en US-001

- [x] Applicatiescope vastgelegd in specification.md
- [x] US-001 voorgesteld en verfijnd (per-100g macros, datum/tijd aanpasbaar, varianten als aparte producten)
- [x] Featurebranch `feature/US-001-consumptie-invoeren` aangemaakt
- [x] US-001 geïmplementeerd (Domain / Application / Infrastructure / Web)
- [x] EF Core InitialCreate migratie aangemaakt
- [x] Build: 0 errors, 0 warnings
- [x] US-001 getest in browser — werkt correct
- [x] Pull request naar development

## Fase 3 — US-002

- [ ] Featurebranch `feature/US-002-dagdashboard` aanmaken
- [ ] UserProfile entity + enums (MacroProfile, ActivityLevel, GoalType)
- [ ] DailyGoalCalculator service (Mifflin-St Jeor)
- [ ] Profielpagina `/profiel`
- [ ] Dashboard op `/` (voortgangsbalken kcal + macros, maaltijdmomenten)
- [ ] EF migratie
- [ ] Testen + PR naar development

## Openstaande vragen

_Geen._

## User stories

Nog geen user stories gedefinieerd.
