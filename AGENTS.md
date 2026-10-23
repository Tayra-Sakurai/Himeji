# Instructions for AI Coding Agents

This document defines the operational rules, constraints, and instructions for AI agents working on this codebase. All generated code, refactoring, and architectural decisions must strictly adhere to these guidelines as well as the specifications in [`ACCESSIBILITY.md`](./ACCESSIBILITY.md) and [`CONTRIBUTING.md`](./CONTRIBUTING.md).

---

## 1. Core Mandate & Design Philosophy

- **Preserve WinUI Defaults**: Do not create custom control templates (`ControlTemplate`) or override standard control appearances unless explicitly requested. Rely on standard WinUI 3 controls and the Fluent Design System.
- **Accessibility First**: Ensure all UI implementations support high contrast themes, keyboard navigation, system text scaling, and screen readers. Refer to `ACCESSIBILITY.md` for detailed rules.
- **MVVM Architecture**: Strictly enforce the Model-View-ViewModel (MVVM) pattern. Maintain absolute separation between UI logic (Views/XAML) and domain/business logic (ViewModels/Services).
- **Internationalization Mandatory**: Never hardcode user-facing strings in XAML or C#.

---

## 2. Localization & UI Text (i18n)

When adding or modifying UI elements:
1. **Use `x:Uid`**: Assign an `x:Uid` attribute to UI controls in XAML (e.g., `<Button x:Uid="SaveButton" />`).
2. **Resource Files (`.resw`)**: Add corresponding string resources to string resource files (`Strings/en-US/Resources.resw`, etc.).
3. **Accessibility Labels**: Ensure screen reader properties like `AutomationProperties.Name` are assigned via resource keys (e.g., `SaveButton.AutomationProperties.Name`).
4. **Code-Behind Strings**: For dynamic strings generated in C#, retrieve localized resources using `ResourceLoader` instead of string literals.

---

## 3. Styling & Theme Rules

- **Theme Resources Only**: Never use hardcoded HEX or RGB colors (e.g., `#FFFFFFFF`). Always use `{ThemeResource ...}` (e.g., `{ThemeResource SystemControlForegroundBaseHighBrush}`) or `{StaticResource ...}` where appropriate.
- **Typography Styles**: Use standard WinUI text styles (e.g., `SubtitleTextBlockStyle`, `BodyTextBlockStyle`) instead of inline `FontSize` or `FontFamily` properties to ensure compatibility with OS-level text scaling.
- **Focus Rings**: Do not modify or disable default keyboard focus visuals (`FocusVisuals`).

---

## 4. Coding Conventions & Code Quality

### C# / .NET Standards
- Follow official Microsoft [.NET Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).
- **Naming**: `PascalCase` for classes, methods, properties, and events; `camelCase` or `_camelCase` for private fields and local variables.
- **Nullable Context**: Respect `#nullable enable`. Treat nullable warnings as errors.
- **Warnings & Diagnostics**: Eliminate all compiler warnings and analyzer diagnostics introduced by your changes.

### File & Project Management
- **Solution File**: Note that the project uses Visual Studio 2026 solution files (`.slnx`).
- **Dependencies**: Restrict changes to existing project targets specified in `.csproj` / `global.json`. Do not introduce new NuGet dependencies without approval.

---

## 5. Git Commit & PR Output Guidelines

When generating commit messages, PR descriptions, or suggested Git commands, follow these conventions:

- **Format**: `<type>: <short description in present tense>`
- **Allowed Types**: `feat`, `fix`, `docs`, `style`, `refactor`, `test`, `chore`
- **Scope Restriction**: Keep proposed changes small, modular, and tightly focused on a single issue. Avoid bundling unrelated code formatting or stylistic updates into functional changes.

---

## 6. Pre-Flight Checklist for Agent Proposals

Before presenting code changes or PRs, verify:

- [ ] Are all UI strings externalized into `.resw` files and referenced via `x:Uid`?
- [ ] Are all color properties bound using `ThemeResource` instead of hardcoded hex values?
- [ ] Is business logic strictly contained in ViewModels or Services (no heavy code-behind in XAML views)?
- [ ] Does the solution build cleanly with zero compiler warnings?
- [ ] Are WinUI standard controls used without unnecessary custom templates?