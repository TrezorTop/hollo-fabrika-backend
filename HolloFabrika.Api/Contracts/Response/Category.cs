namespace HolloFabrika.Api.Contracts.Response;

public class CategoryResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required ICollection<CategoryAttributeResponse> Attributes { get; set; }
}

public class CategoryAttributeResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}