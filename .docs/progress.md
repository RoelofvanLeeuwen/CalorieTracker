# Voortgang — CalorieTracker

## Huidige fase

**Actieve branch:** `feature/UX-BUG-001-modal-sluit-bij-tekstselectie`

## Afgeronde onderdelen

| Onderdeel | Resultaat | Teststatus |
|-----------|-----------|------------|
| Fase 1 — Initiële setup | Clean Architecture-baseline, GC design shell, .slnx | Geslaagd |
| US-001 — Consumptie invoeren | Lazy productaanmaak, per-100g macros, datum/tijd aanpasbaar, dagtotaal | Getest, PR gemerged |
| US-002 — Dagdashboard | Dagdoel (Mifflin-St Jeor), profielpagina, voortgangsbalken kcal + macros | Getest, PR gemerged |
| US-003 — Activiteiten registreren | ActiviteitWizard, MET-berekening, zichtbaar op dashboard | Getest, PR gemerged |
| UX-BUG-001 — Modal sluit bij tekst selecteren | onmousedown/onmouseup fix in beide wizards | Getest, PR gemerged |

## Lopende onderdelen

| Onderdeel | Status | Volgende stap |
|----------|--------|---------------|
| UX-004 — Dashboard inklapbare maaltijdmomenten | In ontwikkeling | Testen in browser, daarna PR naar development |

## Nog te doen

| Prioriteit | Onderdeel | Reden |
|-----------|-----------|-------|
| Should | US-004 — Meldingen bij vergeten invoer of overschrijding dagdoel | Conform specification.md |
| Could | UX-verbetering ConsumptieWizard (autocomplete, keyboard UX, mobile layout) | Bewust uitgesteld |

## Bekende problemen

_Geen._

## Volgende logische stap

UX-004 testen in browser aan de hand van de acceptatiescenario's. Na goedkeuring PR aanmaken naar development.
