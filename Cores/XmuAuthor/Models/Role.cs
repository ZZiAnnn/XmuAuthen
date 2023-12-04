namespace XmuAuthor.Models
{
    public class Role
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Resource> Resources { get; set; }
        public Role(string name)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this.Resources = new List<Resource>();
        }
    }
}