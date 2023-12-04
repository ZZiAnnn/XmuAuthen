namespace XmuAuthor.Models
{
    public class Resource
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Resource(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}