# QuickbaseDemo

An ASP Core Web API .NET 5.0 project.
The application uses Swagger for interactive testing.

## Projects Structure

* QB.DataAccess - Contains ORM related functionality like:
  * QDbContext - the main EF database context used for database interactions
  * DomainConfigurations - EF FluentAPI model configurations for configuring the DB Snapshot responsible for representing the database schema
* QB.Domain - Contains all the domain models used to load DB data into.
* QB.Services - Contains all the business layer services.
* QB.WebApi - Web API functionality - hosting, configurations, controllers, routing etc.
