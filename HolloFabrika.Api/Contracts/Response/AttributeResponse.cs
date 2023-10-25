namespace HolloFabrika.Api.Contracts.Response;

public class AttributeResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Guid CategoryId { get; set; }
}