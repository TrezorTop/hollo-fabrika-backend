namespace HolloFabrika.Feature.Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
}

public class Attribute
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}

public static class CategoryConstants
{
    public const int NameMaxLength = 128;
}