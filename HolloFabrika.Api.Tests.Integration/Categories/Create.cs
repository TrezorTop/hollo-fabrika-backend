using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Request;
using HolloFabrika.Api.Contracts.Response;
using Xunit;

namespace HolloFabrika.Api.Tests.Integration.Categories;

public class Create : IClassFixture<ApiFactory>
{
    private readonly HttpClient _httpClient;

    private readonly Faker<CreateCategoryRequest> _categoryFaker = new Faker<CreateCategoryRequest>()
        .RuleFor(x => x.Name, faker => faker.Commerce.Categories(1).Single());

    public Create(ApiFactory apiFactory)
    {
        _httpClient = apiFactory.CreateClient();
    }

    [Fact]
    public async Task Create_CreatesCategory_WhenDataIsValid()
    {
        // Arrange
        var category = _categoryFaker.Generate();

        // Act
        var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Categories.Create, category);

        // Assert
        var content = await response.Content.ReadFromJsonAsync<CategoryResponse>();
        content?.Id.Should().NotBeEmpty();
        content?.Name.Should().Be(category.Name);
        content?.Attributes.Should().BeEmpty();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}