namespace HolloFabrika.Api.Contracts;

public class CategoryDto
{
    public class CategoryRequest
    {
        public required string Name { get; set; }
        public required ICollection<CategoryAttributeRequest> Attributes { get; set; } = new List<CategoryAttributeRequest>();
    }

    public class CategoryAttributeRequest
    {
        public required string Name { get; set; }
        public required string Value { get; set; }
    }

    public class CategoryResponse
    {
        public required Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required ICollection<CategoryAttributeResponse> Attributes { get; set; }
    }

    public class CategoryAttributeResponse
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Value { get; set; }
    }
}