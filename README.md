## blog-api-dotnet-core2

Be sure that you have .Net Core SDK version 2.1.302 or higher.
The initial boilerplate for this project was created using the following commands:

- dotnet new aspnet
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- dotnet add package Swashbuckle.AspNetCore

After that, please check the configuration for *Entity Framework* and *Swagger* in the "Startup.cs" class.
Also, add the connection string for your Sql Server database inside "appsettings.Development.json" (it can be in Azure).

Run these commands:
- dotnet ef migrations add InitialCreate
- dotnet ef database update

Finally, you can launch the application and navigate to the url http://localhost:5000/swagger to inspect the API.