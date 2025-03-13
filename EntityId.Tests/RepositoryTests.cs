using EntityId.Entities;

namespace EntityId.Tests;

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
        Assert.Null(repository.Get(new TestEntityId(456)));
        Assert.Null(repository.Get(TestEntityId.Empty));
    }
}
