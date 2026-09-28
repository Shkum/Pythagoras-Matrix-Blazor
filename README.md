# Pythagoras Matrix — Blazor

Blazor Web App (.NET 8) with two interchangeable content providers.

## Switching the data source

Edit one setting in `appsettings.json`:

```json
"ContentProvider": "Json"
```

or:

```json
"ContentProvider": "Database"
```

No UI or business-logic code changes are required. Both implementations implement `IContentService` and are selected through ASP.NET Core Dependency Injection in `Program.cs`.

### JSON provider
`JsonContentService` reads `wwwroot/data/content.json`.

### Database provider
`DatabaseContentService` uses EF Core + SQLite and reads `Data/pythagoras-content.db` through `ContentDbContext`.

The included SQLite database contains the same content as the JSON file, so switching providers should not change the user-visible result.

## Architecture

`Home.razor -> IContentService -> JsonContentService | DatabaseContentService`

The UI depends on the abstraction (`IContentService`), not on a storage technology. This keeps the presentation layer decoupled from persistence and demonstrates Dependency Inversion / Strategy-style provider selection.
