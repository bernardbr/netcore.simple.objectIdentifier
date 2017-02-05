namespace ObjectIdentifier.Test.TestObjects.Model.Impl
{
    public class Dog : IDog
    {
        public Dog(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}