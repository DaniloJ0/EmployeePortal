# EmployeePortal
## Information
* SDK version: .NET 8
* Database: SQL Server 
* Database Nuggets version: 8.0.10

## Run

Set the database connection string to:

```
appsettings.json

 "ConnectionStrings": {
   "DefaultConnection": "Your_Database_Connection"
 },
```

Later, you must do the migrations to your database, enter the 'src' folder and then use this command:

```
dotnet ef migrations add initMigration -p Infrastructure  -s Presentation.WPF -o Persistance\Migrations
```

and after use this:

```
dotnet ef database update -p ContactManagement.Infrastructure -s ContactManagement.API
```



