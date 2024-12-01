namespace EntityId;

public class Repository
{
    private readonly Dictionary<Type, List<IEntity>> _entities = [];

    public void Add<TEntity>(TEntity entity) where TEntity: Entity<TEntity>
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
    public TEntity Get<TEntity>(Id<TEntity> id) where TEntity : Entity<TEntity> => 
        _entities[typeof(TEntity)].OfType<TEntity>().First(e => e.Id == id);
}
