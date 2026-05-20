# Voortgang — CalorieTracker

## Huidige fase

**Actieve branch:** `feature/UX-007-responsive-modals`

## Afgeronde onderdelen

| Onderdeel | Resultaat | Teststatus |
|-----------|-----------|------------|
| Fase 1 — Initiële setup | Clean Architecture-baseline, GC design shell, .slnx | Geslaagd |
| US-001 — Consumptie invoeren | Lazy productaanmaak, per-100g macros, datum/tijd aanpasbaar, dagtotaal | Getest, PR gemerged |
| US-002 — Dagdashboard | Dagdoel (Mifflin-St Jeor), profielpagina, voortgangsbalken kcal + macros | Getest, PR gemerged |
| US-003 — Activiteiten registreren | ActiviteitWizard, MET-berekening, zichtbaar op dashboard | Getest, PR gemerged |
| UX-BUG-001 — Modal sluit bij tekst selecteren | onmousedown/onmouseup fix in beide wizards | Getest, PR gemerged |
| UX-004 — Dashboard inklapbaar + activiteiten bovenaan | Home.razor aangepast | Getest, PR gemerged |
| UX-005 — Verwijderen consumptie en activiteiten | BevestigingModal + DeleteAsync | Getest, PR gemerged |

## Lopende onderdelen

| Onderdeel | Status | Volgende stap |
|----------|--------|---------------|
| UX-007 — Responsive modals (bottom sheet op mobiel) | In ontwikkeling | Testen in browser, daarna PR naar development |

## Nog te doen

| Prioriteit | Onderdeel | Reden |
|-----------|-----------|-------|
| Must | UX-006 — Bewerken consumptie en activiteiten via modal | Reworked na UX-007: BewerkenModal i.p.v. inline |
| Should | US-004 — Meldingen bij vergeten invoer of overschrijding dagdoel | Conform specification.md |
| Could | UX-verbetering ConsumptieWizard (autocomplete, keyboard UX, mobile layout) | Bewust uitgesteld |

## Bekende problemen

_Geen._

## Volgende logische stap

UX-007 testen in browser (desktop + mobiel viewport) aan de hand van de acceptatiescenario's. Na goedkeuring PR aanmaken naar development, daarna UX-006 oppakken.
