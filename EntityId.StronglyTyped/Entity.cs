namespace EntityId.StronglyTyped;

public interface IEntity
{

}

public abstract class Entity<TSelf, TId> : IEntity where TId : notnull
{
    public required TId Id { get; init; } = default!;
}