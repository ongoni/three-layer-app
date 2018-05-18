namespace Entities
{
    public class Medal : Entity
    {
        public string Name { get; set; }
        public Material Material { get; set; }
        
        public override string ToString() => $"{Id} - {Name}, {Material.Name}";
    }
}