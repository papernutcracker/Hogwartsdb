Backup your database before running any of these steps.

Purpose: remove duplicate Wizard rows (same Name) and reassign dependent data so a unique constraint on Wizard.Name can be added safely.

Steps:
1. Run the SQL script in this folder on your SQL Server database (run in a transaction on a copy first):
   - Migrations/Dedupe/dedupe_wizards.sql
2. Verify data integrity (HousePoints, Wands) on the target DB.
3. Create and apply an EF Core migration to add the unique index (the model already has IsUnique set for Wizard.Name):
   - dotnet ef migrations add AddUniqueConstraint_WizardName
   - dotnet ef database update

Notes:
- This script targets SQL Server (T-SQL). If your production DB is SQLite or another engine, adapt the queries accordingly.
- Test on a copy before running in production.
