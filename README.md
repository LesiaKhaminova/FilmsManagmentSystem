# FilmsManagmentSystem

Before you begin, ensure you have the following installed on your system:

.NET 8 SDK (for the ASP.NET API)
Node.js (for the React app)
Git (for cloning the repository)

Step 1: Clone the Repository. 
- You can use any convenient tool like git bush or Visual Studio for cloning this repo.

Step 2: Run the ASP.NET API
- Navigate to the API project folder (Film_API);
- Restore dependencies and build the project:
  You can do this in two ways:
  1. open terminal or command prompt inside this directory and run folowning commands:
     - dotnet restore (restore dependencies);
     - dotnet build (build the project);
     - dotnet run (start API).
  2. Open this project in Visual Studio
     -  right-click on the solution -> Select "Restore NuGet Packages";
     -  right-click on the solution -> Select "Build Solution;
     -  run the API.
  
  The database will be created and seeded automatically with mocked data

Step 3: Run the React App
- Navigate to the React project folder (film-app);
- Open terminal or command prompt inside this directory and run folowing commands:
   - npm instal (restor dependencies);
   - npm start (start React app).
