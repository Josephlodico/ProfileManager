# ProfileManager

A C# .NET 9 console application for collecting, validating, displaying, and editing user profile information. What started as a simple data-entry program has been refactored into a properly structured application with separated concerns, a validation system built on an interface, a post-entry menu, and an edit screen.

---

## Project Structure

```
ProfileManager/
├── Helpers/
│   └── ConsoleHelper.cs          # All console I/O: validated input, titles, spacing, double input
│
├── Interfaces/
│   └── IValidator.cs             # IValidator interface — every validator implements this
│
├── Models/
│   ├── Profile.cs                # The Profile data model (all fields)
│   └── ProfileValidators.cs      # Groups all validator instances into one object passed around the app
│
├── Services/
│   ├── MenuService.cs            # Post-entry menu loop: View, Edit, Delete, Exit
│   └── ProfileService.cs         # DisplayProfile, EditProfile, and Confirm (y/n prompt)
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
- Steps through each profile field section by section (Profile Info → Contact → Location → Interests → Physical), prompting the user and validating every input before moving on

### 2. Validation System
Every field (except Weight and Height which use `GetDoubleInput`) goes through `ConsoleHelper.GetValidInput(prompt, validator)`. This loops until the user provides input that passes the validator's `IsValid()` check — printing a specific error message on each failure.

All validators implement `IValidator`:
```csharp
public interface IValidator
{
    bool IsValid(string input);
}
```

Each validator in the `Validators/` folder has its own rules and error messages tailored to the field.

### 3. Display
After all fields are filled, the console is cleared and `ProfileService.DisplayProfile(p)` prints the completed profile in a formatted summary.

### 4. Post-Entry Menu
After displaying the profile, `MenuService.ShowMenu()` gives the user a persistent menu:

```
===== MENU =====
1. View Profile
2. Edit Profile
3. Delete Profile
4. Exit
```

- **View** — reprints the full profile
- **Edit** — opens a sub-menu listing all 16 editable fields by number; each edit re-runs validation
- **Delete** — prompts `y/n` confirmation, then resets the profile to a blank `new Profile()`
- **Exit** — closes the app

---

## Profile Fields

| Section | Field | Type | Validation |
|---------|-------|------|-----------|
| Personal | First Name | `string` | Letters only, max 20 chars |
| Personal | Last Name | `string` | Letters only, max 20 chars |
| Personal | Gender | `string` | GenderValidator |
| Personal | Age | `int` | Number, 0–120 |
| Personal | Date of Birth | `DateTime` | Format `yyyy-MM-dd`, not in future |
| Contact | Email | `string` | Must have `@`, valid local/domain |
| Contact | Phone Number | `string` | Exactly 10 digits |
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
- `ConsoleHelper` centralizing all console I/O
- `ProfileService` handling display, edit, and confirmation logic
- `MenuService` providing a persistent post-entry menu with View / Edit / Delete / Exit
- Per-field edit support — any of the 16 fields can be updated individually after initial entry

---

## Future Ideas

- Save profiles to a JSON file and reload on startup
- Support for multiple profiles
- Fill in the remaining `Profile` fields (Music, Movie, TV Show, Sport, Relationship Status)
- Unit tests for each validator
