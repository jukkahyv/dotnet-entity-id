using Xunit;

namespace EntityId.StronglyTyped;

public class RepositoryTests
{
    [Fact]
    public void AddAndGet()
    {
        var repository = new Repository();
        var id = new TestEntityId(123);
        var entity = new TestEntity { Id = id };
        repository.Add(entity);

        Assert.Equal(entity, repository.Get<TestEntity, TestEntityId>(id));
        Assert.Null(repository.Get<TestEntity, TestEntityId>(new TestEntityId(456)));
        Assert.Null(repository.Get<TestEntity, TestEntityId>(TestEntityId.Empty));
    }
}
