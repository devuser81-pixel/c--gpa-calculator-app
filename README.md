# Single-Semester C# GPA Calculator

A modular, auditable C# console application designed to compute single-semester GPAs on a standard 5.0 grading scale with programmatic self-check assertions.

## 5.0 Grading Scale Thresholds
- **Score >= 70.0**: Grade A (5 Quality Points)
- **Score >= 60.0**: Grade B (4 Quality Points)
- **Score >= 50.0**: Grade C (3 Quality Points)
- **Score >= 45.0**: Grade D (2 Quality Points)
- **Score >= 40.0**: Grade E (1 Quality Point)
- **Score < 40.0**: Grade F (0 Quality Points)

## Features
- **Modular Architecture**: Separates domain models (`Course.cs`), core calculation logic (`GpaCalculator.cs`), and presentation (`Program.cs`).
- **Embedded Assertion Suite**: Executes `Calculator.RunSelfChecks()` at runtime prior to UI rendering to verify mathematical formula integrity.
- **Auditable Tabular Output**: Displays course codes, registered units, scores, assigned grades, unit points, and quality points in a clean ASCII console layout.

## How to Build and Run
1. Ensure the .NET 8.0 SDK is installed on your machine.
2. Open terminal in the project directory.
3. Run the application:
   ```zsh
   dotnet run