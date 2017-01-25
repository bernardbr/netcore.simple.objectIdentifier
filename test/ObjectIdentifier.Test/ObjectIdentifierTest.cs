namespace ObjectIdentifier.Test
{
    using ObjectIdentifier.Test.TestObjects;
    using NetCore.Simple.ObjectIdentifier;
    using Xunit;

    public class ObjectIdentifierTest
    {
        [Fact]
        public void ShoudBeCreatedAnObjectThroughObjectIdentifier()
        {
            IPerson person = ObjectIdentifier.Get<IPerson>(new { Id = 1 });
            Assert.NotNull(person);
            Assert.IsType<IPerson>(person);
        }
    }
}