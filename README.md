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

Slightly inspired by [StronglyTypedId](https://github.com/andrewlock/StronglyTypedId), but this example is based on global usings (type aliases) instead of fully generated type.