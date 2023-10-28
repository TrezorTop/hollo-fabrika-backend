namespace HolloFabrika.Api.Contracts.Request;

public class CreateCategoryRequest
{
    public required string Name { get; set; }
}

public class UpdateCategoryRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
