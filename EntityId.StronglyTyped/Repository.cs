namespace EntityId.StronglyTyped;

public class Repository
{
    private readonly Dictionary<Type, List<IEntity>> _entities = [];

    public void Add<TEntity>(TEntity entity) 
        where TEntity : IEntity
    {
        if (_entities.TryGetValue(entity.GetType(), out var entities))
        {
            entities.Add(entity);
        }
        else
        {
            _entities[entity.GetType()] = [entity];
        }        
    }

    public TEntity? Get<TEntity, TId>(TId id) 
        where TEntity : Entity<TEntity, TId>
        where TId : notnull, IId<TEntity>
        =>
        _entities[typeof(TEntity)].OfType<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
}
