# MVC 5 Blog Demo Application

```markdown
## Introduction
This is a demonstration of an **ASP.NET MVC 5** application built using:
- **Entity Framework** for database interaction.
- **Bootstrap** for responsive UI design.
- **Font Awesome** for icons.
- **SimpleMDE (Markdown Editor)** for post content formatting.

The application features a basic blog system where users can read posts, and authorized users can manage posts.
```

---

```csharp
// Setting Up the Database
// This application uses SQL Server LocalDB for convenience.
// To generate the database using Entity Framework, follow these steps:

// 1. Configure the Connection String
// Open appsettings.json and add the following entry under ConnectionStrings:
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=(LocalDb)\\MSSQLLocalDB;Database=BlogDemoDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

// 2. Run EF Migrations to Set Up the Database
// Open the Package Manager Console in Visual Studio and run:
Add-Migration InitialCreate
Update-Database
```

---

```csharp
// Authentication
// The application uses cookie authentication for demo purposes.
// Normally, a proper OAuth implementation (e.g., Google, Microsoft Identity) should be used in production.

// The Username and Password for authentication are stored in AuthService.cs under the Service folder.
// Users must log in to access administrative functions.
```

---

```csharp
// Application Structure
// The application consists of three controllers:

// 1. HomeController
// - Displays all published posts from the administrator.
// - The homepage lists all posts.
// - Clicking a post title navigates to the post details page.
// - Post content is rendered in Markdown format.

// 2. PostController (Authorized Users Only)
// - Allows users to Add, Edit, and Delete blog posts.
// - Uses SimpleMDE JavaScript Markdown Editor for post content.
// - Users must be logged in to access these features.

// 3. AccountController
// - Handles user authentication (Sign-in & Logout).
// - Ensures only authorized users can manage blog posts.
```

---

```sh
# Running the Application
1. Clone or download the project.
2. Ensure you have .NET Framework 4.7+ and SQL Server LocalDB installed.
3. Update the connection string in appsettings.json.
4. Open the solution in Visual Studio.
5. Run the following EF commands to set up the database:
   Update-Database
6. Start the application and navigate to http://localhost:port/ in your browser.
```

---

```csharp
// Notes
// - This is a demo application with simple authentication for testing purposes.
// - Posts are stored and displayed in Markdown format, making it easy to format text.
// - Only authenticated users can manage posts.
```

```markdown
Happy Coding! 🚀
```

