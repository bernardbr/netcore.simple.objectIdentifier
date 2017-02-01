namespace ObjectIdentifier.Test
{
    using ObjectIdentifier.Test.TestObjects;
    using NetCore.Simple.ObjectIdentifier;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ObjectIdentifierTest
    {
        [Test]
        public void ShoudBeCreatedAnObjectThroughObjectIdentifier()
        {
            IPerson person = ObjectIdentifier.Get<IPerson>(new { Id = 1 });
            Assert.NotNull(person);
            Assert.IsInstanceOf<IPerson>(person);
            var name = string.Empty;
            Assert.Throws(
                Is.
                InstanceOf<NotImplementedException>().
                And.
                Message.
                EqualTo("Temporary exception."),
                () =>
                {
                    name = person.Name;
                }
            );
        }
    }
}