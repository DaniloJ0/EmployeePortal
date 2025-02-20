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
dotnet ef database update -p Infrastructure -s Presentation.WPF
```
## Views

Login
![image](https://github.com/user-attachments/assets/b8be403c-87e3-4d26-a6c8-d465aca6bb81)

Register
![image](https://github.com/user-attachments/assets/a28a0502-0535-44b0-850d-d8bafd144cbe)

Employee Portal
![image](https://github.com/user-attachments/assets/c0d1a0ef-af98-4dab-aaf3-878bb081cb76)

Excel 
![image](https://github.com/user-attachments/assets/50a993b2-6446-4fd4-861e-fbc1f08a9318)





