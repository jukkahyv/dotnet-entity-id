namespace EntityId;

public interface IEntity
{

}

public abstract class Entity<TSelf> : IEntity
{
    public required Id<TSelf> Id { get; init; }
}
