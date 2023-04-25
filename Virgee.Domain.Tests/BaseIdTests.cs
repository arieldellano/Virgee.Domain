namespace Virgee.Domain.Tests;

public sealed class BaseIdTests
{
    private sealed class DummyIdentifier : BaseId<Guid>
    {
        public DummyIdentifier(Guid value) : base(value)
        {
        }
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConstructorShouldAssignCorrectValue()
    {
        // Given
        var value = Guid.NewGuid();

        // When
        var dummyEntity = new DummyIdentifier(value);

        // Then   
        Assert.That(dummyEntity.Value, Is.EqualTo(value));
    }

    [Test]
    public void AssignmentShouldImplicitlyConvertAnIdentifierToItsValue()
    {
        // Given
        var value = Guid.NewGuid();
        var dummyEntity = new DummyIdentifier(value);

        // When
        Guid actualValue = dummyEntity;

        // Then   
        Assert.That(actualValue, Is.EqualTo(value));
    }

    [Test]
    public void EqualOperatorShouldDetermineWhetherTwoIdentifiersAreEqual()
    {
        // Given
        var value = Guid.NewGuid();
        var value2 = Guid.NewGuid();
        var dummyEntity = new DummyIdentifier(value);
        var dummyEntity2 = new DummyIdentifier(value);
        var dummyEntity3 = new DummyIdentifier(value2);

        // When
        var result = dummyEntity == dummyEntity2;
        var result2 = dummyEntity == dummyEntity3;

        // Then   
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(result2, Is.False);
        });
    }
    
    [Test]
    public void NotEqualOperatorShouldDetermineWhetherTwoIdentifiersAreEqual()
    {
        // Given
        var value = Guid.NewGuid();
        var value2 = Guid.NewGuid();
        var dummyEntity = new DummyIdentifier(value);
        var dummyEntity2 = new DummyIdentifier(value);
        var dummyEntity3 = new DummyIdentifier(value2);

        // When
        var result = dummyEntity != dummyEntity2;
        var result2 = dummyEntity != dummyEntity3;

        // Then   
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(result2, Is.True);
        });
    }
    
    [Test]
    public void IEquatable_EqualsShouldDetermineWhetherTheSpecifiedObjectIsEqualToTheCurrentObject()
    {
        // Given
        var value = Guid.NewGuid();
        var value2 = Guid.NewGuid();
        var dummyEntity = new DummyIdentifier(value);
        var dummyEntity2 = new DummyIdentifier(value);
        var dummyEntity3 = new DummyIdentifier(value2);

        // When
        var result = dummyEntity.Equals(dummyEntity2);
        var result2 = dummyEntity.Equals(dummyEntity3);

        // Then   
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(result2, Is.False);
        });
    }
    
    [Test]
    public void Object_EqualsShouldDetermineWhetherTheSpecifiedObjectIsEqualToTheCurrentObject()
    {
        // Given
        var value = Guid.NewGuid();
        var value2 = Guid.NewGuid();
        var dummyEntity = new DummyIdentifier(value);
        var dummyEntity2 = new DummyIdentifier(value);
        var dummyEntity3 = new DummyIdentifier(value2);
        var notADummyIdentifier = new object();

        // When
        var result = dummyEntity.Equals(dummyEntity2);
        var result2 = dummyEntity.Equals(dummyEntity3);
        var result3 = dummyEntity.Equals(notADummyIdentifier);

        // Then   
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(result2, Is.False);
            Assert.That(result3, Is.False);
        });
    }
    
    [Test]
    public void GetHashCodeShouldServeAsTheDefaultHashFunction()
    {
        // Given
        var value = Guid.NewGuid();
        var dummyEntity = new DummyIdentifier(value);

        // When
        var result = dummyEntity.GetHashCode();

        // Then   
        Assert.That(result, Is.EqualTo(EqualityComparer<Guid>.Default.GetHashCode(value)));
    }
    
    [Test]
    public void ToStringShouldReturnAStringThatRepresentsTheCurrentObject()
    {
        // Given
        var value = Guid.NewGuid();
        var dummyEntity = new DummyIdentifier(value);

        // When
        var result = dummyEntity.ToString();

        // Then   
        Assert.That(result, Is.EqualTo(value.ToString()));
    }
}