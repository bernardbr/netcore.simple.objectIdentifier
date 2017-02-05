namespace ObjectIdentifier.Test
{
    using ObjectIdentifier.Test.TestObjects.Model;
    using ObjectIdentifier.Test.TestObjects.Provider;
    using ObjectIdentifier.Test.TestObjects.Exceptions;
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
            ICat cat = ObjectIdentifier.Get<ICat>(new { Identifier = 1 });
            Assert.NotNull(cat);
            Assert.IsInstanceOf<ICat>(cat);
            var name = string.Empty;
            Assert.Throws(
                Is.
                InstanceOf<ExpecificException>(),
                () =>
                {
                    name = cat.Name;
                }
            );
        }

        [Test]
        public void ShouldBeGetAnObjectSettedOnGetByIdMethod()
        {
            // TODO: It's not still works. I need store the real object when a different property than Identifiers is called.
            IDog dog = ObjectIdentifier.Get<IDog>(1);
            Assert.NotNull(dog);
            Assert.IsInstanceOf<IDog>(dog);
            Assert.AreEqual("Marley", dog.Name);
        }


        [OneTimeSetUp]
        public void TestFixtureInitializer()
        {
            ObjectIdentifier.Register<ICat>(CatProvider.GetById);
            ObjectIdentifier.Register<IDog>(DogProvider.GetById);
        }
    }
}