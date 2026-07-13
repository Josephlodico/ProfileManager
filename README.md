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
│   ├── MenuService.cs            # Main menu loop: Create, View, Edit, Delete, Save to File, Exit — operates on a List<Profile>
│   └── ProfileService.cs         # CreateProfile, DisplayProfile, EditProfile, Confirm (y/n prompt), profile picker (SelectProfileIndex/ListProfiles), SaveProfilesToFile, OpenFile
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
- Builds a `List<Profile>`, seeded with one profile from `ProfileService.CreateProfile(validators)`, which steps through each field section by section (Profile Info → Contact → Location → Interests → Physical), prompting the user and validating every input before moving on
- Displays that first profile, then hands off to `MenuService.ShowMenu(profiles, validators)`, which manages the full list for the rest of the session

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
3. Edit a Profile
4. Delete a Profile
5. Save Profiles to File
6. Exit
```

- **Create New Profile** — runs the same field-by-field entry flow as startup and appends the result to the list
- **View / Edit / Delete a Profile** — each first calls `ProfileService.SelectProfileIndex`, which lists all profiles by number (`ListProfiles`) and prompts for a pick (`0` cancels; non-numeric or out-of-range input prints "Invalid selection.")
  - **View** — reprints the chosen profile
  - **Edit** — opens a sub-menu (also color-coded) listing all 16 editable fields by number; each edit re-runs validation
  - **Delete** — prompts `y/n` confirmation, then removes that profile from the list (`profiles.RemoveAt(index)`)
- **Save Profiles to File** — writes every profile to `Profiles.txt` in the working directory (`ProfileService.SaveProfilesToFile`) and, on confirmation, opens it in the default text editor via `ProfileService.OpenFile`
- **Exit** — closes the app

---

## Profile Fields

| Section | Field | Type | Validation |
|---------|-------|------|-----------|
| Personal | First Name | `string` | Letters only, max 20 chars |
| Personal | Last Name | `string` | Letters only, max 20 chars |
| Personal | Gender | `string` | GenderValidator |
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
| Physical | Weight (kg) | `double` | Must be a valid number |
| Physical | Height (cm) | `double` | Must be a valid number |

> The `Profile` model also contains fields for `RelationshipStatus`, `MusicArtist`, `Movie`, `TVShow`, `Song`, and `Sport` — these are defined but not yet wired into the input flow.

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
- "Save Profiles to File" writes all profiles to `Profiles.txt` and offers to open it in the default text editor
- Per-field edit support — any of the 16 fields can be updated individually after initial entry
- Invalid profile-selection input now shows an explicit error message instead of failing silently

---

## Future Ideas

- Save profiles in a structured format (e.g. JSON) and reload them on startup, instead of the current write-only `Profiles.txt`
- Fill in the remaining `Profile` fields (Music, Movie, TV Show, Sport, Relationship Status)
- Unit tests for each validator
