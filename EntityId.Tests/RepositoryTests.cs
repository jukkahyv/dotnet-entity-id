namespace EntityId.Tests;

using TestEntityId = Id<TestEntity>;

public class RepositoryTests
{
    [Fact]
    public void AddAndGet()
    {
        var repository = new Repository();
        var id = new TestEntityId(123);
        var entity = new TestEntity { Id = id };
        repository.Add(entity);
        Assert.Equal(entity, repository.Get(id));
    }
}

class TestEntity : Entity<TestEntity>;
