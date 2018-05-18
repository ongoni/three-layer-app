namespace Entities
{
    public class Address : Entity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public override string ToString() => $"{Id} - {Street}, {HouseNumber}, {City}";
    }
}