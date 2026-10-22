# Layout smoke check

Run from the repository root on Windows:

```powershell
dotnet run --project tools/LayoutSmoke/LayoutSmoke.csproj
```

Opens 11 screens inside the real MDI shell and 3 dialogs offscreen, resizes the shell,
visits each tab, and reapplies light/dark themes. Checks that buttons and
input controls fit within their ancestors or scrollable content. Also verifies
ingredient display names in the inventory receipt and recipe ComboBoxes.
Checks scroll containers at three sizes, down to 640 × 420, and verifies that
payment confirmation stays visible when scrolling cash and bank-transfer details.

Load handlers are removed so the check does not require SQL Server or modify
business data. It does not test database-backed interactions. Final screen
renders are saved under `artifacts/` (ignored by Git) for visual inspection.
