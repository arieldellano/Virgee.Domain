namespace Virgee.Domain;

/// <summary>
/// Base class for aggregate roots.
/// </summary>
/// <typeparam name="T">
/// The type of the aggregate root's identifier.
/// </typeparam>
public abstract class AggregateRoot<T> : Entity<T>
{
    protected AggregateRoot(T id) : base(id)
    {
    }
}