# Voortgang — CalorieTracker

## Huidige fase

**Actieve branch:** `development`

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
| UX-007 — Responsive modals (bottom sheet op mobiel) | Media query in app.css | Getest, PR gemerged |
| UX-006 — Bewerken consumptie en activiteiten via modal | BewerkenConsumptieModal + BewerkenActiviteitModal | Getest, PR gemerged |
| US-004 — Inline dashboard-meldingen | MeldingBanner.razor, Home.razor, app.css | Getest, PR gemerged |

## Lopende onderdelen

_Geen._

## Nog te doen

| Prioriteit | Onderdeel | Reden |
|-----------|-----------|-------|
| Should | US-005 — Meldingencentrum (belpictogram + geschiedenis) | Nieuw gepland na US-004 |
| Could | UX-verbetering ConsumptieWizard (autocomplete, keyboard UX, mobile layout) | Bewust uitgesteld |

## Bekende problemen

_Geen._

## Volgende logische stap

US-005 oppakken: meldingencentrum met belpictogram en geschiedenis.
