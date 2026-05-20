# AGENTS.md

Deze repository gebruikt AI-codeagents zoals GitHub Copilot, Codex CLI, Claude, ChatGPT, Cursor, Windsurf of vergelijkbare tools.

Dit bestand is de compacte, tool-onafhankelijke ingang voor AI-agents. De volledige richtlijnen staan in:

```text
.docs/development-guidelines.md
```

## Lees eerst

Voordat je iets analyseert, wijzigt, genereert of commit, lees of controleer je minimaal:

```text
.docs/development-guidelines.md
.docs/architecture.md
.docs/decisions.md
.docs/progress.md
.docs/specification.md
.docs/DefaultTemplate.zip, wanneer aanwezig
.docs/flow.md, wanneer aanwezig
.docs/deployment.md, wanneer relevant
.docs/troubleshooting.md, wanneer aanwezig
README.md, wanneer aanwezig
```

## Harde fasepoort

Volg deze volgorde zonder stappen over te slaan:

```text
1. Documentatie en repositorybasis
2. main pushen
3. development aanmaken
4. Technische Clean Architecture-basis op development
5. Blazor .Web UI/designbaseline op development
6. Push naar origin/development
7. STOP: vraag of US-001 voorgesteld en verfijnd mag worden
8. US-001 voorstellen en verfijnen
9. Na akkoord featurebranch maken
10. US-001 implementeren
```

Na de initiële setup mag je niet automatisch een user story bouwen.

## Verboden tijdens initiële setup

Tijdens de initiële setup mag je niet bouwen:

```text
- functionele user stories
- feature-specifieke domeinentities
- echte applicatieflows
- businesslogica voor echte use cases
- feature-specifieke UI-pagina's
- US-001 implementatie
```

De initiële setup bevat alleen:

```text
- documentatie
- Clean Architecture-baseline
- technische basis
- Blazor .Web shell
- DefaultTemplate UI/designbaseline
- GitHub remote
- main en development
```

## Branchregels

- Werk nooit rechtstreeks aan een user story op `development`.
- Maak pas een featurebranch nadat de user story en het plan zijn goedgekeurd.
- Featurebranches starten altijd vanaf `development`.
- Gebruik branchnamen zoals:

```text
feature/US-001-korte-omschrijving
bugfix/US-001-korte-omschrijving
```

- Pull requests voor user stories gaan naar `development`.
- Releases/deployments gaan via pull request van `development` naar `main`.
- Deployment gebeurt alleen vanaf `main`.

## Designregels

Als `.docs/DefaultTemplate.zip` aanwezig is:

- Gebruik dit direct als verplichte designbaseline voor de initiële Blazor `.Web` shell.
- Eindig niet met een neutrale of standaard Blazor-shell.
- Vertaal React/JSX naar native Blazor/Razor.
- Gebruik geen React, Babel, npm, Vite of Webpack.
- Gebruik gewone CSS binnen het Blazor-project.
- Zorg dat de shell interactief rendert.
- Controleer dat hamburgermenu/drawer werkt.

## Clean Architecture

- Gebruik C#.
- Gebruik `.slnx` wanneer de tooling dit ondersteunt.
- Gebruik Core, Application, Infrastructure, Web en testprojecten.
- `.Web` is server-side Blazor.
- WebAPI-functionaliteit komt in een apart `.Api`-project.
- Core/domain types lekken niet naar UI/API.
- Core/domain-enums worden niet rechtstreeks gebruikt in DTO’s, Razor components of API-contracten.
- DTO/API/UI-enums staan in Application en worden expliciet gemapt via extension methods.
- DI-registraties staan per project in een static `DependencyInjection` extension class.
- `Program.cs` blijft dun.

## Testen en fouten

- Lever bij iedere user story concrete acceptatiescenario’s op.
- Bij testfouten of bugs: maak eerst een analyse- en herstelplan.
- Pas code pas aan na expliciet akkoord.
- Leg testbevindingen vast in `.docs/progress.md`.
- Leg structurele oplossingen vast in `.docs/troubleshooting.md`.

## Documentatie

Werk documentatie bij bij iedere betekenisvolle wijziging:

```text
.docs/architecture.md
.docs/decisions.md
.docs/progress.md
.docs/specification.md
.docs/flow.md, wanneer relevant
.docs/deployment.md, wanneer relevant
.docs/troubleshooting.md, wanneer relevant
```

Als documenten elkaar tegenspreken, stop dan met bouwen en herstel eerst de documentatieconsistentie.
