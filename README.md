# Movie Diary App

## Description
This is a WPF application built in C# that allows users to browse, search, and manage movies using data from the TMDb API.

The application provides an interactive interface where users can explore trending movies, search for specific titles, and organise movies into a watchlist or watched list.

---

## Features
- View trending movies from the TMDb API
- Search for movies by title
- View detailed movie information including:
  - Poster
  - Title
  - Release date
  - Rating
  - Overview
- Add and remove movies from a Watchlist
- Mark movies as Watched
- View Watchlist and Watched lists
- Styled user interface with custom theme and hover effects

---

## Technologies Used
- C#
- WPF / XAML
- TMDb API (JSON data)
- ObservableCollection for dynamic UI updates
- LINQ for filtering and data handling

---

## Structure
- `Movie` – Represents movie data from the API
- `DiscoverViewModel` – Handles application logic and data binding
- `TmdbService` – Handles API calls and JSON deserialization
- `MainWindow` – Main user interface
- `MovieDetailsWindow` – Displays detailed information for a selected movie

---

## How to Run
1. Open the project in Visual Studio
2. Build the solution
3. Run the application

---

## Notes
- The application uses live data from the TMDb API
- Manual testing was carried out to ensure all features work correctly

---
