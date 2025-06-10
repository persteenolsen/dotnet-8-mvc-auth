ASP.NET Core MVC Web Application by .NET 8 with Individual Accounts towards a SQLite Database

Last updated:

- 10-06-2025

# Tech used for creating the Web App

- A .NET 8 MVC Web Application
- User Accounts
- SQLite 
- A traditional Webhotel for hosting
- VS Code

# Create a global json if needed

dotnet new globaljson --sdk-version 8.0.203 --force

# Create the MVC Web Application by type in Powershell:

dotnet new mvc --auth Individual -o WebAppAuth

# Install the codegenerator tool global and run: 

dotnet tool install --global dotnet-aspnet-codegenerator --version 8.0.0

# Add the Package to the .csproj of the Web Application

<PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="8.0.3" />

# Scarffold files Register, Login, Logout and RegisterConfirmation for the Account

dotnet aspnet-codegenerator identity -dc WebAppAuth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout;Account.RegisterConfirmation" --useSqLite

# Scarffold files ResendEmailConfirmation and ForgotPassword for the Account

dotnet aspnet-codegenerator identity -dc WebAppAuth.Data.ApplicationDbContext --files "Account.ResendEmailConfirmation;Account.ForgotPassword" --useSqLite

Now take a look in the generated files in the folder areas 

# Run and Test the Web Application

dotnet run

# Deployment

Create a self contained build for production at the remote server / traditionel web hotel

dotnet publish webappauth.csproj --configuration Release --runtime win-x86 --self-contained

Upload the build to remote server

At my remote servers the web.config needs to be without the folowing:

hostingModel="inprocess"

# Other usefull commands

If no Migrations exits run: 

dotnet ef migrations add FirstCreate --output-dir Data/Migrations

If Migration exits run:

dotnet ef database update





