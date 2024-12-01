namespace EntityId;

public interface IEntity
{

}

public class Entity<TSelf> : IEntity
{
    public Id<TSelf> Id { get; }
}
