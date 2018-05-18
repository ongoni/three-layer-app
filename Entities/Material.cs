namespace Entities
{
    public class Material : Entity
    {
        public string Name { get; set; }
        
        public override string ToString() => $"{Id} - {Name}";
    }
}