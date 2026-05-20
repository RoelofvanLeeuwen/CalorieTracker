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

### US-002 t/m US-004

_Volgen na akkoord en implementatie van US-001._

## Toekomstige scope

- AI-fotoherkenning: gebruiker maakt een foto van zijn maaltijd, het systeem herkent de producten en geschatte hoeveelheden via een AI-model.
