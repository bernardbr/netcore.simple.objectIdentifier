namespace ObjectIdentifier.Test.TestObjects.Provider
{
    using ObjectIdentifier.Test.TestObjects.Exceptions;
    using ObjectIdentifier.Test.TestObjects.Model;

    public class CatProvider
    {
        public static ICat GetById(dynamic identifiers)
        {
            throw new ExpecificException();
        }
    }
}