# ProfileManager

A C# .NET 9 console application for collecting, validating, displaying, and editing user profile information. What started as a simple data-entry program has been refactored into a properly structured application with separated concerns, a validation system built on an interface, a color-coded menu system, masked input for dates and phone numbers, support for managing multiple profiles, and the ability to save all profiles to a text file.

---

## Project Structure

```
ProfileManager/
├── Helpers/
│   └── ConsoleHelper.cs          # All console I/O: validated input, masked input, colored menus, titles, spacing, double input
│
├── Interfaces/
│   └── IValidator.cs             # IValidator interface — every validator implements this
│
├── Models/
│   ├── Profile.cs                # The Profile data model (all fields)
│   └── ProfileValidators.cs      # Groups all validator instances into one object passed around the app
│
├── Services/
│   ├── MenuService.cs            # Main menu loop: Create, View, Search/Filter, Edit, Delete, Find Duplicates, Save (JSON), Exit — operates on a List<Profile>
│   └── ProfileService.cs         # CreateProfile, DisplayProfile, EditProfile, Confirm (y/n prompt), profile picker (SelectProfileIndex/ListProfiles), SearchProfiles (filter by field or age range), FindMatchesForNewProfile/FindDuplicateGroups/FindAndDisplayDuplicates (duplicate detection), SaveProfilesToJson/LoadProfilesFromJson, OpenFile
│
├── Validators/                   # One class per field, each implementing IValidator
│   ├── NameValidator.cs          # Letters only, max 20 chars
│   ├── GenderValidator.cs
│   ├── AgeValidator.cs           # Must be a number between 0–120
│   ├── DateOfBirthValidator.cs   # Format yyyy-MM-dd, cannot be in the future
│   ├── EmailValidator.cs         # Must contain @, valid local part and domain
│   ├── PhoneValidator.cs         # Exactly 10 digits
│   ├── AddressValidator.cs       # Max 100 chars, allows letters/digits/spaces/, . - #
│   ├── CountryValidator.cs
│   ├── ProvinceValidator.cs
│   └── TextValidator.cs          # Non-empty only (used for free-text fields)
│
└── UserProfileSystem.cs          # Entry point — wires up validators, collects input, launches menu
```

---

## How It Works

### 1. Startup & Input Collection
`UserProfileSystem.cs` is the entry point. It:
- Instantiates all validators and groups them into a `ProfileValidators` object
- Shows the main title banner via `ConsoleHelper.MainTitle()`
- Tries to load existing profiles via `ProfileService.LoadProfilesFromJson()` (reads `Profiles.json` from the working directory, if present)
- If none were loaded, builds a `List<Profile>` seeded with one profile from `ProfileService.CreateProfile(validators)`, which steps through each field section by section (Profile Info → Contact → Location → Interests → Entertainment → Physical), prompting the user and validating every input before moving on, and displays it
- If profiles were loaded, skips profile creation and prints how many were restored
- Either way, hands off to `MenuService.ShowMenu(profiles, validators)`, which manages the full list for the rest of the session

### 2. Validation System
Every field (except Weight and Height, which use `GetDoubleInput`) goes through `ConsoleHelper.GetValidInput(prompt, validator)` or, for Date of Birth and Phone Number, `ConsoleHelper.GetValidMaskedInput(prompt, validator, mask)`. Both loop until the user provides input that passes the validator's `IsValid()` check, printing a specific error message on each failure. The masked variant auto-inserts dashes as the user types, using masks `####-##-##` (date) and `###-###-####` (phone), so those two fields never need to be typed manually.

All validators implement `IValidator`:
```csharp
public interface IValidator
{
    bool IsValid(string input);
}
```

Each validator in the `Validators/` folder has its own rules and error messages tailored to the field.

### 3. Display
`ProfileService.DisplayProfile(p)` prints a single profile in a formatted summary (built by the shared `FormatProfile(p)`).

### 4. Main Menu
`MenuService.ShowMenu(profiles, validators)` gives the user a persistent, color-coded menu that also shows a live count of stored profiles:

```
===== MENU =====
You have {n} profile(s).
1. Create New Profile
2. View a Profile
3. Search/Filter Profiles
4. Edit a Profile
5. Delete a Profile
6. Find Duplicate Profiles
7. Save Profiles (JSON)
8. Exit
```

- **Create New Profile** — runs the same field-by-field entry flow as startup, then checks the new entry against existing profiles (`ProfileService.FindMatchesForNewProfile`); if a likely duplicate is found (same Email, same Phone Number, or same First+Last Name and Date of Birth), it warns the user and asks for `y/n` confirmation before adding it to the list
- **View / Edit / Delete a Profile** — each first calls `ProfileService.SelectProfileIndex`, which lists all profiles by number (`ListProfiles`) and prompts for a pick (`0` cancels; non-numeric or out-of-range input prints "Invalid selection.")
  - **View** — reprints the chosen profile
  - **Edit** — opens a sub-menu (also color-coded) listing all 22 editable fields by number; each edit re-runs validation
  - **Delete** — prompts `y/n` confirmation, then removes that profile from the list (`profiles.RemoveAt(index)`)
- **Search/Filter Profiles** — `ProfileService.SearchProfiles` presents a field menu (First Name, Last Name, Email, Phone Number, Country, Province, or Age Range). Text fields match by case-insensitive substring; Age Range takes a min/max and matches profiles within that inclusive range. Matches are listed by number, and picking one reprints the full profile.
- **Find Duplicate Profiles** — `ProfileService.FindAndDisplayDuplicates` scans the whole list and groups profiles that share an Email, a Phone Number, or a First+Last Name and Date of Birth, then prints each group so the user can decide which entries to edit or delete
- **Save Profiles (JSON)** — writes every profile to `Profiles.json` in the working directory (`ProfileService.SaveProfilesToJson`) and, on confirmation, opens it via `ProfileService.OpenFile`. On the next run, `Profiles.json` is auto-loaded on startup, so saved profiles persist across sessions.
- **Exit** — closes the app

---

## Profile Fields

| Section | Field | Type | Validation |
|---------|-------|------|-----------|
| Personal | First Name | `string` | Letters only, max 20 chars |
| Personal | Last Name | `string` | Letters only, max 20 chars |
| Personal | Gender | `string` | GenderValidator |
| Personal | Relationship Status | `string` | Non-empty |
| Personal | Age | `int` | Number, 0–120 |
| Personal | Date of Birth | `DateTime` | Format `yyyy-MM-dd` (dashes auto-inserted while typing), not in future |
| Contact | Email | `string` | Must have `@`, valid local/domain |
| Contact | Phone Number | `string` | Exactly 10 digits, entered/stored as `###-###-####` (dashes auto-inserted) |
| Contact | Address | `string` | Max 100 chars, limited special chars |
| Location | Country | `string` | CountryValidator |
| Location | Province | `string` | ProvinceValidator |
| Interests | Hobby | `string` | Non-empty |
| Interests | Favorite Game | `string` | Non-empty |
| Interests | Favorite Anime | `string` | Non-empty |
| Interests | Pet | `string` | Non-empty |
| Entertainment | Favorite Music Artist | `string` | Non-empty |
| Entertainment | Favorite Movie | `string` | Non-empty |
| Entertainment | Favorite TV Show | `string` | Non-empty |
| Entertainment | Favorite Song | `string` | Non-empty |
| Entertainment | Favorite Sport | `string` | Non-empty |
| Physical | Weight (kg) | `double` | Must be a valid number |
| Physical | Height (cm) | `double` | Must be a valid number |

---

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Run
```bash
git clone https://github.com/Josephlodico/ProfileManager.git
cd ProfileManager
dotnet run --project ProfileManager
```

---

## What Changed From v1

The original version was a single-file script that collected input with no validation and printed a summary. The project has since been refactored into:

- A proper folder structure with separated concerns
- An `IValidator` interface with 10 individual validator classes
- `ConsoleHelper` centralizing all console I/O, including masked/auto-dashed input for Date of Birth and Phone Number
- `ProfileService` handling profile creation, display, edit, confirmation, profile selection, and file save/open logic
- `MenuService` providing a persistent, color-coded main menu with Create / View / Edit / Delete / Save to File / Exit
- Support for multiple profiles (`List<Profile>`), with pick-by-number selection for View/Edit/Delete and a live profile count on the menu
- Per-field edit support — any of the 22 fields can be updated individually after initial entry
- Invalid profile-selection input now shows an explicit error message instead of failing silently
- "Save Profiles (JSON)" writes all profiles to `Profiles.json`, and that file is auto-loaded on the next startup, so profiles now persist across sessions instead of being write-only
- "Search/Filter Profiles" — a new menu option to find profiles by First Name, Last Name, Email, Phone Number, Country, Province (substring match), or Age Range, with matches selectable to view in full
- Filled in the remaining `Profile` fields — Relationship Status is now collected alongside Personal info, and a new Entertainment section collects Favorite Music Artist, Movie, TV Show, Song, and Sport during creation and editing
- Duplicate detection — creating a new profile now warns if it matches an existing one on Email, Phone Number, or First+Last Name and Date of Birth, and a new "Find Duplicate Profiles" menu option scans the whole list and reports every duplicate group

---

## Future Ideas

- Unit tests for each validator
- Sort profiles
- Export to CSV
- Undo delete
- Profile stats/summary view
