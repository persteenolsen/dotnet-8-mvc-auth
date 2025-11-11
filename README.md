# dotnet-8-mvc-authentication

ASP.NET Core Identity MVC Web Application by .NET 8 with Individual Accounts towards a SQLite Database

Last updated:

- 11-11-2025

# Tech used for creating the Web App

- .NET 8 MVC Web Application
- ASP.NET Core Identity
- SQLite as the Database
- Entity Framework Core as ORM
- MVC design pattern as software architecture pattern
- Bootstrap for making the Web App mobile friendly  
- Traditional Webhotel for hosting
- VS Code

# Create a global json if needed

dotnet new globaljson --sdk-version 8.0.203 --force

# Create the MVC Web Application by type in Powershell:

dotnet new mvc --auth Individual -o WebAppAuth

# Install the codegenerator tool global and run: 

dotnet tool install --global dotnet-aspnet-codegenerator --version 8.0.0

# Add the Package to the .csproj of the Web Application

PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="8.0.3" 

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

# Things to be aware of

At my Webhotel they are using two different SMTP Servers:

- Using one SMTP Server at the Webhotel for production ( local )

- Using another SMTP Server when the Web App is running remote like Azure or my local PC Developing

# Tip and Tricks

When loading Razor files I have had an issue dealing with a popup msg in VS Code:

"Request textDocument/inlayHint failed. Message: Razor source generator is not ... referenced Code: -32000 ... "

To prevent the msg to show up I uninstalled the VS Code extentions:

- C# Dev Kit

- C#

- .NET install Tool

Then closed VS Code and deleted the obj and bin and opened VS Code and installed the extentions again

I changed settings in the C# extention like below:

- Extentions - C# - LSP Server - Dotnet Server - Enabled the "Supress LSP Error Toast" - Restart VS Code

Finally I deleted the extention cache "csdevkit" by the path:

- C: Users \ .vscode \ extensions \ csdevkit

Restart VS Code

Thats it :-)










