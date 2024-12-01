namespace EntityId;

public readonly record struct Id<TEntity>(int Value)
{
    public static readonly Id<TEntity> Empty = new(0);
}
