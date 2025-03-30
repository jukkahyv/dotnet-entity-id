using System;

namespace EntityId
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class EntityAttribute : Attribute;
}
