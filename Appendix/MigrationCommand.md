# Migrations

## 1. Using the CLI

### Add a migration
```bash
dotnet ef migrations add AddBaseEntityModel --project QuizApp.API --startup-project QuizApp.API --context QuizAppDbContext --output-dir Migrations
dotnet ef migrations add [MigrationName] --project QuizApp.API --startup-project QuizApp.API --context QuizAppDbContext --output-dir Migrations
dotnet ef migrations add [MigrationName] --project QuizApp.Data --startup-project QuizApp.API --context StorageDbContext --output-dir Migrations/Storage
```

### Update the database
```bash
dotnet ef database update --project QuizApp.API --startup-project QuizApp.API --context QuizAppDbContext
dotnet ef database update --project QuizApp.Data --startup-project QuizApp.API --context StorageDbContext
```

### Roll back a migration
```bash
dotnet ef database update [MigrationName] --project QuizApp.Data --startup-project QuizApp.API --context QuizAppDbContext
dotnet ef database update [MigrationName] --project QuizApp.Data --startup-project QuizApp.API --context StorageDbContext
```

### Drop the database
```bash
dotnet ef database drop --project QuizApp.API --startup-project QuizApp.API --context QuizAppDbContext
dotnet ef database drop --project QuizApp.Data --startup-project QuizApp.API --context StorageDbContext
```

### Remove a migration
```bash
dotnet ef migrations remove --project QuizApp.Data --startup-project QuizApp.API --context QuizAppDbContext
dotnet ef migrations remove --project QuizApp.Data --startup-project QuizApp.API --context StorageDbContext
```

## 2. Using the Package Manager Console
### Add a migration
```bash
Add-Migration [MigrationName] -Project QuizApp.Data -StartupProject QuizApp.API -Context QuizAppDbContext -OutputDir QuizApp.Data/Migrations
```

### Update the database
```bash
Update-Database -Project QuizApp.Data -StartupProject QuizApp.API -Context QuizAppDbContext
```

### Roll back a migration
```bash
Update-Database [MigrationName] -Project QuizApp.Data -StartupProject QuizApp.API -Context QuizAppDbContext
```

### Remove a migration
```bash
Remove-Migration -Project QuizApp.Data -StartupProject QuizApp.API -Context QuizAppDbContext
```

[]: # Path: README.md
