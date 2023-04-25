namespace Virgee.Domain.Tests;

public sealed class EntityTests
{
    private sealed class DummyEntity : Entity<Guid>
    {
        public DummyEntity(Guid id) : base(id)
        {
        }
    }

    [SetUp]
    public void Setup()
    {    
    }
    
    [Test]
    public void ConstructorShouldAssignCorrectId()
    {
        // Given
        var id = Guid.NewGuid();

        // When
        var dummyEntity = new DummyEntity(id);

        // Then   
        Assert.That(dummyEntity.Id, Is.EqualTo(id));
    }
}