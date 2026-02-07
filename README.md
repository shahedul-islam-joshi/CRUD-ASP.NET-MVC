#  Student Management System (ASP.NET Core MVC)

A beginner-friendly **ASP.NET Core MVC** application to manage student records.  
This project demonstrates **CRUD operations** using **Entity Framework Core** and **SQL Server**.

---

##  Features

-  Add new students
-  View student list
-  Edit student information
-  Delete students with confirmation
-  MVC architecture (Controller, ViewModel, Domain Model)
-  Entity Framework Core (Code First)

---

##  Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5
- Razor Views
- C#

---

##  How to Run
1. Clone the repo: `git clone https://github.com/shahedul-islam-joshi/CRUD-ASP.NET-MVC.git`
2. Update the Connection String in `appsettings.json`.
3. Run migrations: `Update-Database` in Package Manager Console.
4. Press `F5` or run `dotnet run`.
## Project Structure

```text
test_apps-3/
├── Controllers/
│   ├── AdminStudentController.cs    # Logic for student administration
│   └── HomeController.cs            # Default landing page logic
├── Data/
│   └── AppsDbContext.cs             # Entity Framework database context
├── Migrations/                      # Database schema version history
├── Models/
│   ├── DomainModel/
│   │   └── StudentClass.cs          # Core data entity
│   ├── ViewModel/
│   │   ├── AddStudentRequest.cs     # Data transfer for creation
│   │   └── EditStudentRequest.cs    # Data transfer for updates
│   └── ErrorViewModel.cs            # Error handling model
├── Views/
│   ├── AdminStudent/                # Student management views
│   │   ├── Add.cshtml
│   │   ├── Edit.cshtml
│   │   └── List.cshtml
│   ├── Home/                        # Default site views
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   ├── Shared/                      # Reusable UI components
│   │   ├── _Layout.cshtml
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   └── Error.cshtml
│   ├── _ViewImports.cshtml          # Global Tag Helpers/Namespaces
│   └── _ViewStart.cshtml            # Default layout configuration
├── wwwroot/                         # Static assets (CSS, JS, Images)
├── appsettings.json                 # Configuration and Connection Strings
├── Dockerfile                       # Containerization instructions
├── Program.cs                       # Application entry point and services
└── README.md                        # Project documentation