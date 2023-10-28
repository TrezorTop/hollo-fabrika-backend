using System.Net;
using FluentAssertions;
using HolloFabrika.Api.Contracts;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HolloFabrika.Api.Tests.Integration.Products;

public class GetById : IClassFixture<WebApplicationFactory<IApiMarker>>
{
    private readonly HttpClient _httpClient;

    public GetById(WebApplicationFactory<IApiMarker> applicationFactory)
    {
        _httpClient = applicationFactory.CreateClient();
    }

    // [Fact]
    // public async Task Get_ReturnsNotFound_WhenProductDoesNotExist()
    // {
    //     // Act
    //     // var response = await _httpClient.GetAsync($"{ApiRoutes.Products.Base}/{Guid.NewGuid()}");
    //
    //     // Assert
    //     // response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    // }
}