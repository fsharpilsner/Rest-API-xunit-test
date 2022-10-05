using System.ComponentModel.DataAnnotations;
using MiniValidation;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPeopleService, PeopleService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//app.MapGet("/eh", () => "Hello World2!");

app.MapPost("/people", (Person person, IPeopleService peopleService) =>
    !MiniValidator.TryValidate(person, out var errors)
        ? Results.ValidationProblem(errors)
        : Results.Ok(peopleService.Create(person)));



app.Run();

/// <summary>
/// To be accessed from outside
/// </summary>
public partial class Program { }


/// <summary>
/// Object for the payload
/// </summary>

public class Person
{
    [Required, MinLength(2)]
    public string? FirstName { get; set; }

    [Required, MinLength(2)]
    public string? LastName { get; set; }

    [Required, DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
}
///
/// Data store interface
///
public interface IPeopleService
{
    string Create(Person person);
}
// talk to database, Entity framework etc..
public class PeopleService: IPeopleService
{
    public string Create(Person person)
        => $"{person.FirstName} {person.LastName} created.";
}