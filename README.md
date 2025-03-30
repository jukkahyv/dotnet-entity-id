# Strongly typed entity ID based on generic base type

Based on entity
```csharp
class Order : Entity<Order> {}
```

generates a global using for an ID
```csharp
global using OrderId = EntityId.Id<EntityId.Entities.Order>;
```
using Roslyn code generator.

[Blog post with background](https://blog.snellman.online/2025/03/03/using-value-types-and-aliases-for-ids/).

Slightly inspired by [StronglyTypedId](https://github.com/andrewlock/StronglyTypedId), but this example is based on global usings (type aliases) instead of fully generated type.