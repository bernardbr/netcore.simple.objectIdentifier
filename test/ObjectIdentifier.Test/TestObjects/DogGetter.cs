namespace ObjectIdentifier.Test.TestObjects
{
    public static class DogGetter
    {
        public static IDog GetById(dynamic identifiers)
        {
            throw new ExpecificException();
        }
    }
}