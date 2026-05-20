namespace CalorieTracker.Domain.Common;

public abstract class EntityBase : IEntity<int>
{
    public int Id { get; protected set; }
}
