namespace EntityId;

public interface IEntity
{

}

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public class EntityAttribute : Attribute;

public abstract class Entity<TSelf> : IEntity
{
    public required Id<TSelf> Id { get; init; }
}
