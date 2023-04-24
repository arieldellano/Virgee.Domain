namespace Virgee.Domain;

/// <summary>
/// Base class for entities.
/// </summary>
/// <typeparam name="T">
/// The type of the entity's identifier.
/// </typeparam>
public abstract class Entity<T>
{
    protected Entity(T id)
    {
        Id = id;
    }

    /// <summary>
    /// Gets the entity's identifier.
    /// </summary>
    public T Id { get; protected set; }
}