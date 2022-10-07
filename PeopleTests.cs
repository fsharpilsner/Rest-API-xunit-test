using Microsoft.VisualBasic.CompilerServices;
using System.Transactions;
using System.Threading;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MyMinimalApi.Tests
{
    public class PeopleTests
    {
        
        [Fact]
        public async Task CreatePerson()
        {

            //create an in-memory HTTP client 
            await using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();

            var result = await client.PostAsJsonAsync("/people", new Person
                    {
                    FirstName = "Kalle",
                    LastName = "Pelle",
                    Email = "kalle.p@host.nu"
                    }
                
                                                    );
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("\"Maarten Balliauw created.\"", await result.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task CreatePersonValidatesObject()
        {
            await using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var result = await client.PostAsJsonAsync("/people", new Person());
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var validationResult= await result.Content.ReadFromJsonAsync<HttpValidationProblemDetails>();
            Assert.NotNull(validationResult);
            Assert.Equal("The FirstName field is required.", validationResult!.Errors["FirstName"][0]);


        }


    }
    
}    
