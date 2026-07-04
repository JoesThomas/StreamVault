# StreamVault

## Overview

StreamVault is an ASP.NET Core MVC web application developed to manage a digital media catalogue. The system allows administrators to create, view, edit, delete and search different types of media content stored within a SQLite database.

The application demonstrates object-oriented programming principles, Entity Framework Core, Razor Views and the MVC architectural pattern.

---

## Features

- View all catalogue items
- Add new content
- Edit existing content
- Delete content
- Search by title
- Filter by content type
- SQLite database storage
- Seeded sample data
- Responsive Bootstrap interface

---

## Content Types

The application supports four different media types:

- Movie
- TV Series
- Audiobook
- Music Album

Each content type inherits from a common `Content` base class whilst storing its own specific properties.

Examples include:

### Movie
- Title
- Director
- Duration

### Series
- Number of Seasons
- Total Episodes

### Audiobook
- Author
- Narrator
- Duration

### Music Album
- Artist
- Record Label
- Track Count

---

## Technologies Used

- C#
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQLite
- Razor Views
- Bootstrap 5

---

## Design

The project follows the MVC (Model-View-Controller) pattern.

- **Models** represent the media content.
- **Views** display the user interface.
- **Controllers** handle requests between the UI and business logic.
- **Services** provide database operations.
- **Entity Framework Core** manages persistence.
- **SQLite** stores application data.

---

## Running the Application

### Requirements

- Visual Studio 2022
- .NET 8 SDK

### Installation

1. Clone the repository

```
git clone https://github.com/JoesThomas/StreamVault.git
```

2. Open the solution in Visual Studio.

3. Restore NuGet packages.

4. Run the application.

The SQLite database is automatically created on first launch and populated with sample data.

---

## Future Improvements

Potential future enhancements include:

- User authentication and authorisation
- Image upload for media artwork
- Advanced search and filtering
- Sorting options
- Validation improvements
- REST API integration

---

## Author

Joe Thomas
