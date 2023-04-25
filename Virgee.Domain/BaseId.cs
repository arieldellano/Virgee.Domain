namespace Virgee.Domain;

/// <summary>
/// Base class for identifiers.
/// </summary>
/// <typeparam name="T">
/// The type of the identifier's value.
/// </typeparam>
public abstract class BaseId<T> : IEquatable<BaseId<T>> where T: IEquatable<T>
{
    protected BaseId(T value)
    {
        Value = value;
    }

    public T Value { get; }

    /// <summary>
    /// Implicitly converts an identifier to its value.
    /// </summary>
    /// <param name="id">
    /// The identifier to convert.
    /// </param>
    /// <returns>
    /// The identifier's value.
    /// </returns>
    public static implicit operator T(BaseId<T> id) => id.Value;
    
    /// <summary>
    /// Determines whether two identifiers are equal.
    /// </summary>
    /// <param name="left">
    /// The first identifier to compare.
    /// </param>
    /// <param name="right">
    /// The second identifier to compare.
    /// </param>
    /// <returns>
    /// <c>true</c> if the identifiers are equal; otherwise, <c>false</c>.
    /// </returns>
    public static bool operator ==(BaseId<T>? left, BaseId<T>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Determines whether two identifiers are not equal.
    /// </summary>
    /// <param name="left">
    /// The first identifier to compare.
    /// </param>
    /// <param name="right">
    /// The second identifier to compare.
    /// </param>
    /// <returns>
    /// <c>true</c> if the identifiers are not equal; otherwise, <c>false</c>.
    /// </returns>
    public static bool operator !=(BaseId<T>? left, BaseId<T>? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="other">
    /// The object to compare with the current object.
    /// </param>
    /// <returns>
    /// <c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.
    /// </returns>
    public bool Equals(BaseId<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<T>.Default.Equals(Value, other.Value);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">
    /// The object to compare with the current object.
    /// </param>
    /// <returns>
    /// <c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj is BaseId<T> other && Equals(other);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>
    /// A hash code for the current object.
    /// </returns>
    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Value);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A string that represents the current object.
    /// </returns>
    public override string? ToString()
    {
        return Value.ToString();
    }
}
