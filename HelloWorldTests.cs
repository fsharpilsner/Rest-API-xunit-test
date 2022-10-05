namespace MyMinimalApi.Tests;

using Microsoft.AspNetCore.Mvc.Testing;

public class HelloWorldTests
{
    [Fact]
    public async void TestRootEndpoint()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient(); //returns HttpClient

        var response = await client.GetStringAsync("/");
  
        Assert.Equal("Hello World!", response);
    }
}