using XmuAuthor.Models;

namespace XmuAuthor.Services
{
    public class ResourceManager
    {
        public Dictionary<string, Resource> Resources { get; set; } = new Dictionary<string, Resource>();

        public Resource GetResource(string name)
        {
            if (Resources.ContainsKey(name))
            {
                return Resources[name];
            }
            else
            {
                return null;
            }
        }

        public ResourceManager()
        {
            
        }
    }
}