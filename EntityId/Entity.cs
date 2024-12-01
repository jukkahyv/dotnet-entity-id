namespace EntityId;

public interface IEntity
{

}

public class Entity<TSelf> : IEntity
{
    public required Id<TSelf> Id { get; init; }
}
