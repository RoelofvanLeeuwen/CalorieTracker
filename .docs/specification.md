# Specificatie — CalorieTracker

## Projectdoel

CalorieTracker is een persoonlijke webapplicatie waarmee één gebruiker zijn/haar calorie-inname en activiteiten bijhoudt, met als doel inzicht te geven in de energiebalans per dag.

## Gebruiker

Consument (enkelvoudig, geen login/authenticatie vereist in de initiële scope).

## Kernprincipes

- **Gebruiksvriendelijk boven correct**: de gebruiker hoeft geen product aan te maken voordat hij een consumptie invoert. Als een product onbekend is, vraagt het systeem om de benodigde informatie op het moment van invoer.
- **Lazy product creation**: producten worden automatisch aangemaakt als een gebruiker ze voor het eerst invoert en de benodigde kcal-informatie opgeeft.
- **Maaltijdmomenten**: consumptie wordt altijd gekoppeld aan een maaltijdmoment (ontbijt, lunch, diner, tussendoor).
- **Eenheden**: producten kunnen zowel op basis van gewicht (gram) als eenheid (stuk, plak, beker, etc.) worden ingevoerd.

## Functies (overzicht)

| # | Functie                                | Scope       |
|---|----------------------------------------|-------------|
| 1 | Consumptie invoeren + lazy producten   | US-001      |
| 2 | Dagdashboard met totalen en dagdoel    | US-002      |
| 3 | Activiteiten registreren               | US-003      |
| 4 | Meldingen bij vergeten invoer of overschrijding dagdoel | US-004 |
| 5 | AI-fotoherkenning van maaltijden       | Toekomstig  |

## User stories

### US-001 — Consumptie invoeren met automatisch productbeheer

**Status:** Voorgesteld — wacht op akkoord

**Verhaal:**
> Als gebruiker wil ik een consumptie invoeren voor een maaltijdmoment, waarbij het systeem automatisch om productinformatie vraagt als een product nog niet bekend is, zodat ik mijn calorie-inname eenvoudig kan bijhouden zonder eerst aparte producten te moeten aanmaken.

**Verfijningen (vastgelegd na bespreking):**
- Datum én tijd zijn door de gebruiker aanpasbaar bij iedere invoer (geen "altijd vandaag").
- Het dagtotaal kcal wordt getoond in US-001 (zonder vergelijking met een doel).
- Iedere productvariëteit is een apart product: "witte boterham" en "tarweboterham" zijn twee afzonderlijke producten.

**Acceptatiescenario's:**

1. **Bekend product**
   - Ik open de dagboekinvoer en kies een maaltijdmoment (bijv. ontbijt).
   - Ik pas indien nodig datum en tijd aan.
   - Ik typ een productnaam die al in het systeem staat (bijv. "witte boterham").
   - Ik voer de hoeveelheid in (bijv. 2).
   - Het systeem berekent de kcal en voegt de consumptie toe.
   - Het totaal kcal voor dat maaltijdmoment én het dagtotaal worden bijgewerkt.

2. **Onbekend product — eenheidgebaseerd (bijv. "tarweboterham")**
   - Ik typ "tarweboterham" — het systeem herkent dit niet.
   - Het systeem vraagt: is dit een eenheidsproduct of gewichtgebaseerd (gram)?
   - Ik kies eenheid en vul in: eenheidslabel = "snee", kcal per snee = 80.
   - Het product wordt opgeslagen; ik voer de hoeveelheid in (2).
   - De consumptie wordt opgeslagen en de kcal (160) worden meegenomen in het totaal.

3. **Onbekend product — gewichtgebaseerd (bijv. "jonge kaas")**
   - Ik typ "jonge kaas" — het systeem herkent dit niet.
   - Ik kies "gewichtgebaseerd (gram)" en vul kcal per 100 g in (380).
   - Ik voer de hoeveelheid in grams in (bijv. 20 g).
   - De consumptie (76 kcal) wordt opgeslagen.

4. **Meerdere producten per maaltijdmoment**
   - Ik voeg meerdere producten toe aan hetzelfde maaltijdmoment.
   - Per maaltijdmoment wordt het subtotaal kcal getoond.

5. **Dagtotaal**
   - Ik zie de som van alle kcal van alle maaltijdmomenten van de geselecteerde dag.

6. **Datum en tijd aanpassen**
   - Bij iedere invoer kan ik datum en tijd handmatig aanpassen (bijv. gisteren om 19:30).

**Buiten scope voor US-001:**
- Dagdoel en voortgangsindicator (US-002)
- Activiteiten (US-003)
- Meldingen (US-004)
- Bewerken of verwijderen van consumptie (volgt later)

---

### US-002 — Dagdashboard met berekend dagdoel

**Status:** Goedgekeurd — klaar voor implementatie

**Verhaal:**
> Als gebruiker wil ik een dagdashboard zien op de home-pagina met mijn voortgang richting een berekend kcal- en macrodoel, zodat ik in één oogopslag zie hoe mijn dag er voedingstechnisch uitziet.

**Verfijningen (vastgelegd na bespreking):**
- Dagdoel wordt berekend op basis van profiel (Mifflin-St Jeor + activiteitsfactor + doelstelling), niet handmatig ingesteld.
- Macroprofiel kiest de gebruiker uit 5 vaste profielen met uitleg (zie onder).
- Eén gebruikersprofiel (single-user).
- Dashboard vervangt de huidige home-pagina (`/`).

**Macropropfielen:**

| Profiel | Koolh. | Vet | Eiwit | Wanneer? |
|---|---|---|---|---|
| Gebalanceerd | 50% | 25% | 25% | Gezonde basis voor de meeste mensen |
| Sportief | 55% | 20% | 25% | Regelmatig sporten, extra koolhydraten als brandstof |
| Hoog eiwit | 30% | 25% | 45% | Krachttraining, spierbehoud bij gewichtsafname |
| Low-carb | 20% | 45% | 35% | Stabiel bloedsuiker, gewichtsafname |
| Keto | 5% | 70% | 25% | Strikt ketogeen, medische/speciale doeleinden |

**Profiel instellen (`/profiel`):**
- Gewicht (kg), lengte (cm), leeftijd, geslacht
- Activiteitsniveau: Zittend / Licht actief / Matig actief / Actief / Zeer actief
- Doelstelling: Afvallen (−500 kcal) / Gewicht houden / Aankomen (+300 kcal)
- Macroprofiel (keuze uit 5 opties met uitleg)

**Dashboard (`/`):**
- Kcal-voortgangsbalk: gegeten / doel / resterend
- Drie macrobalkjes: koolhydraten / vetten / eiwitten (gegeten vs. doel in grammen)
- Opsplitsing per maaltijdmoment (subtotaal kcal + knop "Toevoegen")

**Domein (nieuw):**
- `UserProfile`: gewicht, lengte, leeftijd, geslacht, activiteitsniveau, doelstelling, macroprofiel
- `MacroProfile` (enum): Balanced / Athletic / HighProtein / LowCarb / Keto
- `ActivityLevel` (enum): Sedentary / Light / Moderate / Active / VeryActive
- `GoalType` (enum): Lose / Maintain / Gain
- `DailyGoal`: berekende waarde (niet opgeslagen) via BMR × activiteitsfactor ± doelstelling

**Acceptatiescenario's:**
1. Nieuw profiel: ik vul mijn gegevens in → systeem berekent en toont mijn dagdoel op het dashboard.
2. Dashboard toont voortgangsbalk kcal met correct gegeten/resterend/doel.
3. Macrobalkjes tonen grammen gegeten vs. berekend doel per macro.
4. Per maaltijdmoment zie ik het subtotaal en een knop om direct te kunnen invoeren.
5. Als er geen profiel is ingesteld, word ik doorgestuurd naar `/profiel`.

**Buiten scope voor US-002:**
- Activiteiten (US-003) — activiteitsniveau is statisch in het profiel, geen dagelijkse sportregistratie
- Meldingen (US-004)

---

---

### UX-BUG-001 — Modal sluit ongewenst bij tekst selecteren

**Status:** Gereed — getest en goedgekeurd (2026-05-20)

**Verhaal:**
> Als gebruiker wil ik tekst kunnen selecteren in een invoerveld van een popup door te klikken en te slepen, ook als mijn muis de popup verlaat voordat ik de muisknop loslaat, zodat de popup niet onverwacht sluit.

**Oorzaak:**
De backdrop luisterde op `@onclick="Close"`. De browser vuurt een click-event op de backdrop zodra de `mouseup` daar eindigt, ook als de `mousedown` begon op een input binnen de modal.

**Oplossing:**
Backdrop gebruikt `@onmousedown` + `@onmouseup` met een vlag. De modal stopt propagation van `mousedown` en `mouseup`. De modal sluit alleen als zowel press als release op de backdrop plaatsvonden.

**Scope:** `ConsumptieWizard.razor` en `ActiviteitWizard.razor`.

**Acceptatiescenario's:**

1. Open de popup voor een maaltijdmoment via "Toevoegen".
2. Klik in het zoektekstvak en sleep naar links buiten de popup; laat de muisknop los buiten de popup.
3. **Verwacht:** popup blijft open, tekst is geselecteerd.
4. Klik op de donkere backdrop buiten de popup.
5. **Verwacht:** popup sluit normaal.
6. Herhaal voor de activiteitenpopup.

---

---

### UX-004 — Dashboard: activiteiten bovenaan, maaltijdmomenten inklapbaar

**Status:** Gereed — getest en goedgekeurd (2026-05-20)

**Verhaal:**
> Als gebruiker wil ik op het dashboard de activiteiten bovenaan zien en de maaltijdmomenten standaard ingeklapt, zodat ik in één oogopslag mijn energiebalans zie en zelf kies welk maaltijdmoment ik uitklapt.

**Verfijningen:**
- Activiteitensectie staat boven de maaltijdmomenten.
- Activiteiten zijn altijd volledig zichtbaar (geen collapse).
- Elk maaltijdmoment is standaard ingeklapt.
- Klikken op de koptekst klapt de productenlijst open of dicht (chevron als indicator).
- De knop "Toevoegen" is altijd zichtbaar, ook als het maaltijdmoment ingeklapt is.
- Kcal-subtotaal per maaltijdmoment blijft altijd zichtbaar in de koptekst.

**Scope:** alleen `Home.razor`.

**Acceptatiescenario's:**

1. Ik open het dashboard — activiteiten staan bovenaan, maaltijdmomenten eronder, allemaal ingeklapt.
2. Ik zie bij elk ingeklapt maaltijdmoment het kcal-subtotaal (indien gevuld) en de knop "Toevoegen".
3. Ik klik op "Ontbijt" — de productenlijst klapt open.
4. Ik klik opnieuw op "Ontbijt" — de lijst klapt weer dicht.
5. Meerdere maaltijdmomenten kunnen tegelijk open zijn.
6. De activiteitensectie toont altijd alle activiteiten.

---

---

### UX-005 — Consumptie-items en activiteiten verwijderen

**Status:** In ontwikkeling

**Verhaal:**
> Als gebruiker wil ik een consumptie-item of activiteit kunnen verwijderen via een prullenbak-icoon per rij, zodat ik foute invoer kan corrigeren.

**Verfijningen:**
- Prullenbak-icoon per rij in consumptietabellen en activiteitentabel.
- Klikken opent een bevestigingsdialoog ("Weet je zeker dat je dit wilt verwijderen?").
- Na bevestiging wordt het item verwijderd en herlaadt het dashboard.
- Na annuleren blijft het item staan.

**Scope:** `GcIcon.razor`, `IConsumptionEntryRepository`, `IActivityRepository`, `ConsumptionEntryRepository`, `ActivityRepository`, `BevestigingModal.razor` (nieuw), `Home.razor`.

**Acceptatiescenario's:**

1. Ik klap een maaltijdmoment open — elke rij toont een prullenbak-icoon.
2. Ik klik op het icoon — een bevestigingsdialoog verschijnt.
3. Ik klik "Annuleren" — dialoog sluit, item blijft staan.
4. Ik klik opnieuw op het icoon en klik "Verwijderen" — item verdwijnt, subtotalen en voortgangsbalk worden bijgewerkt.
5. Ik klik op het prullenbak-icoon van een activiteit en bevestig — activiteit verdwijnt, verbrand-totaal wordt bijgewerkt.

---

## Toekomstige scope

- AI-fotoherkenning: gebruiker maakt een foto van zijn maaltijd, het systeem herkent de producten en geschatte hoeveelheden via een AI-model.
