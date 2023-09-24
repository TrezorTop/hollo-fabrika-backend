namespace HolloFabrika.Feature.Entities;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }
}

public static class ProductConstants
{
    public const int NameMaxLength = 128;
}