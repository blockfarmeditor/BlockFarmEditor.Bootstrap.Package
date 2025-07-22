# BlockFarmEditor.Bootstrap.Package

This project is an Umbraco CMS package that provides a set of Bootstrap-based block definitions for use in Umbraco's Block Editor. It enables editors to easily create rich, responsive layouts using Bootstrap components within the Umbraco backoffice.

## Features
- Predefined Bootstrap block definitions (accordion, alert, badge, button, card, carousel, collapse, list group, modal, offcanvas, rich text editor, tabs, etc.)
- Easy integration with Umbraco Block Editor
- Extensible configuration via JSON definition files

## Project Structure
- `Definitions/` — Contains JSON files for each Bootstrap block definition
- `BlockFarmEditor.Bootstrap.Package.csproj` — Project file
- `DefinitionsConfigurations.cs`, `DefinitionsPackageAction.cs`, `DefinitionsPackageMigrationPlan.cs` — C# source files for package logic
- `package.xml` — Umbraco package manifest
- `umbraco-package-schema.json`, `appsettings-schema.json` — Schema files for configuration
- `bin/` — Compiled binaries

## Getting Started
1. Clone the repository:
   ```pwsh
   git clone <repo-url>
   ```
2. Build the project:
   ```pwsh
   dotnet build
   ```
3. Install the package in your Umbraco site:
   - Copy the compiled DLLs and definition files to your Umbraco project's appropriate folders.
   - Register the package in Umbraco using the `package.xml` manifest.

## Usage
- After installation, the Bootstrap blocks will be available in the Umbraco Block Editor.
- Editors can use these blocks to build responsive layouts using familiar Bootstrap components.

## Extending
- To add or modify block definitions, edit or add JSON files in the `Definitions/` folder.
- Update C# source files if you need custom logic or migrations.

## Contributing
Contributions are welcome! Please submit issues or pull requests for improvements or new block definitions.

## License
This project is licensed under the MIT License.
