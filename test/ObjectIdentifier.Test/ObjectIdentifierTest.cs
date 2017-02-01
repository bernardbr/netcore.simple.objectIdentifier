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
        public void ShouldBeCreatedAnObjectThroughObjectIdentifier()
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

        [Test]
        public void ShouldBeThrowAnExpecificExceptionSettedOnGetByIdMethod()
        {
            IDog dog = ObjectIdentifier.Get<IDog>(new { Identifier = 1 });
            Assert.NotNull(dog);
            Assert.IsInstanceOf<IDog>(dog);
            var name = string.Empty;            
            Assert.Throws(
                Is.
                InstanceOf<ExpecificException>(),
                () =>
                {
                    name = dog.Name;
                }
            );
        }

        [OneTimeSetUp]
        public void TestFixtureInitializer()
        {
            ObjectIdentifier.Register<IDog>(DogGetter.GetById);
        }
    }
}