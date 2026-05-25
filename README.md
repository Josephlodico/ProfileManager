# ProfileManager

A simple C# console application for collecting and displaying user profile information.

## Overview

ProfileManager is a .NET 9 console app that prompts the user to enter personal details and then displays them in a formatted profile summary. It's structured around a `Profile` class that holds all user data, keeping the model and the program logic cleanly separated.

## Project Structure

```
ProfileManager/
├── Classes/
│   └── Profile.cs           # Profile data model
├── UserProfileSystem.cs     # Main entry point — input collection & display
└── ProfileManager.csproj
ProfileManager.sln
```

## Features

- Collects the following profile fields:
  - **Personal**: First name, last name, email, phone number, address
  - **Demographics**: Age, gender, country, province, date of birth
  - **Interests**: Hobby, favorite game, favorite anime, pet
  - **Physical**: Weight (kg), height (cm)
- Clears the console after input and displays a clean profile summary

## Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/ProfileManager.git
   cd ProfileManager
   ```

2. **Build the project**
   ```bash
   dotnet build
   ```

3. **Run the application**
   ```bash
   dotnet run --project ProfileManager
   ```

4. Follow the prompts to enter your profile information. Once all fields are filled in, the console will clear and display your completed profile.

## Example Output

```
===== PROFILE =====
Name: John Doe
Email: john.doe@example.com
Phone Number: 555-1234
Address: 123 Main St
Age: 25
Gender: Male
Country: Canada
Province: Ontario
Date of Birth: 2000-01-15
Hobby: Photography
Favorite Game: Elden Ring
Favorite Anime: Fullmetal Alchemist
Pet: Dog
Weight: 75
Height: 180
```

## Future Improvements

- Input validation (e.g. email format, numeric fields)
- Save and load profiles from a file (JSON or CSV)
- Support for multiple profiles
- Unit tests

## License

This project is open source. Feel free to use and modify it.
