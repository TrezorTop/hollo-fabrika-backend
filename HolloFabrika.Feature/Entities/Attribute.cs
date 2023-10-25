namespace HolloFabrika.Feature.Entities;

public class Attribute
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}

public static class AttributeConstants
{
    public const int NameMaxLength = 128;
}