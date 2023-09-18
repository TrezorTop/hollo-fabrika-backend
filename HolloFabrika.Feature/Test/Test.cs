using FluentResults;

namespace HolloFabrika.Feature.Test;

public class Test
{
    public static Result<TestModel> GetTest()
    {
        var model = new TestModel(1, "Message");

        if (Random.Shared.Next(1, 3) > 1)
            return new Error("Error")
                .WithMetadata("item", model);

        return model;
    }
}