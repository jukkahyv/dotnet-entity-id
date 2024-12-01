using StronglyTypedIds;

namespace EntityId.StronglyTyped;

public interface IId<TEntity> where TEntity : IEntity {
}

[StronglyTypedId(Template.Int)]
public readonly partial struct TestEntityId : IId<TestEntity> { }

public class TestEntity : Entity<TestEntity, TestEntityId>
{
}
