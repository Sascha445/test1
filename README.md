# Portfolio Backend - Opdracht 3 WPFW

Dit is de backend van mijn portfoliosite. Je kunt er projecten en blogposts mee aanmaken, bekijken, wijzigen en verwijderen. De gegevens staan in een SQL database.

## Wat heb ik gebruikt?

- .NET 10
- Minimal API (dus geen controllers)
- Swagger UI om de API te testen
- Entity Framework Core met SQL Server (LocalDB)
- Migraties om de database aan te maken
- DTO's: de API stuurt en ontvangt nooit direct database-objecten

## Waarom Minimal API?

Minimal API is minder code waardoor ik het zelf overzichtelijker vind, ook hebben we veel informatie vanuit de lessen gekregen over minimal API waardoor deze keuze het meest comfortabele leek om mee te werken.

## Hoe is de code opgebouwd?

- Program.cs: instellingen en opstarten van de applicatie
- Endpoints: de routes van projecten en blogposts
- Services: de logica, zoals gegevens ophalen en opslaan en omzetten naar DTO's
- Data: AppDbContext, de verbinding met de database
- Models: de database-objecten (Project en Blogpost)
- DTOs: de objecten die de API ontvangt en terugstuurt
- Migrations: de database-migraties

Een verzoek loopt zo: Endpoints > Services > AppDbContext > SQL Server.

## Hoe start ik de applicatie?

1. Open Opdracht3WPFW/appsettings.json en controleer de connection string. Die gebruikt LocalDB:
   Server=(localdb)\\mssqllocaldb;Database=Opdracht3WPFW;Trusted_Connection=True;TrustServerCertificate=True;
2. Maak de database aan. Open in Visual Studio de Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) en voer Update-Database in.
3. Start de applicatie in de map Opdracht3WPFW met: dotnet run
4. Ga naar http://localhost:5281/swagger (zie port in uitvoer van dotnet run)

## Welke endpoints zijn er?

Voor projecten (/projecten) en blogposts (/blogposts) zijn er dezelfde vijf endpoints:

- GET /projecten : alle projecten ophalen
- GET /projecten/{id} : een project ophalen
- POST /projecten : een project aanmaken
- PUT /projecten/{id} : een project wijzigen
- DELETE /projecten/{id} : een project verwijderen

Voor blogposts vervang je /projecten door /blogposts. Als een ID niet bestaad dan krijg je een 404 Not Found.

## Architectuurdiagram

[INVULLEN: voeg hier het diagram toe]
