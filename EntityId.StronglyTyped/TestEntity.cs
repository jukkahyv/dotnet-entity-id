using StronglyTypedIds;

namespace EntityId.StronglyTyped;

[StronglyTypedId(Template.Int)]
public readonly partial struct TestEntityId { }

public class TestEntity : Entity<TestEntity, TestEntityId>
{
}
