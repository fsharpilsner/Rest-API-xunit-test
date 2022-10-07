# ASP.NET core Minimal api xunit test #
 
 
Create a test project as:

  dotnet new web -o MyMinimalApi
  dotnet new xunit -o MyMinimalApi.Tests
  dotnet add MyMinimalApi.Tests reference MyMinimalApi
  dotnet new sln
  dotnet sln add MyMinimalApi
  dotnet sln add MyMinimalApi.Tests


To run the Minimal API application:

  dotnet run --project MyMinimalApi

To run tests:
 
  dotnet test
