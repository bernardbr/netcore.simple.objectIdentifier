namespace ObjectIdentifier.Test.TestObjects.Provider
{
    using ObjectIdentifier.Test.TestObjects.Model;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using ObjectIdentifier.Test.TestObjects.Model.Impl;

    public static class DogProvider
    {
        private static readonly IDictionary<int, IDog> fakeDatabase;

        static DogProvider()
        {
            fakeDatabase = new ConcurrentDictionary<int, IDog>();
            fakeDatabase.Add(1, new Dog(1, "Marley"));
            fakeDatabase.Add(2, new Dog(2, "Dillon"));
        }

        public static IDog GetById(dynamic identifiers)
        {
            IDog located;
            if (fakeDatabase.TryGetValue(identifiers, out located))
            {
                return located;
            }

            return null;
        }
    }
}