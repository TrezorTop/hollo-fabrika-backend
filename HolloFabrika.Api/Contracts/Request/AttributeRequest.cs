namespace HolloFabrika.Api.Contracts.Request;

public class CreateAttributeRequest
{
    public required string Name { get; set; }

    public required Guid CategoryId { get; set; }
}

public class UpdateAttributeRequest
{
    public required string Name { get; set; }

    public required Guid CategoryId { get; set; }
}