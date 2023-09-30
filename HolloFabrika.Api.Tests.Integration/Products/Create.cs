using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Endpoints.Products;
using HolloFabrika.Feature.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HolloFabrika.Api.Tests.Integration.Products;

public class Create : IClassFixture<WebApplicationFactory<IApiMarker>>, IAsyncLifetime
{
    private readonly HttpClient _httpClient;
    private List<Guid> _createdIds = new List<Guid>();

    private readonly Faker<CreateProductRequest> _productFaker = new Faker<CreateProductRequest>()
        .RuleFor(x => x.Name, faker => faker.Commerce.ProductName());

    public Create(WebApplicationFactory<IApiMarker> applicationFactory)
    {
        _httpClient = applicationFactory.CreateClient();
    }

    [Fact]
    public async Task Create_ReturnsOk_WhenProductCreated()
    {
        // Arrange
        var product = _productFaker.Generate();

        // Act
        var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Products.Create, product);

        // Assert
        var content = await response.Content.ReadFromJsonAsync<Product>();
        content.Should().BeEquivalentTo(product);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        _createdIds.Add(content!.Id);
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public async Task DisposeAsync()
    {
        foreach (var createdId in _createdIds)
        {
            await _httpClient.DeleteAsync($"{ApiRoutes.Products.Base}/{createdId}");
        }
    }
}