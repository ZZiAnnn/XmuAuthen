using XmuAuthor.Models;
using NetCourse.Framework.Security;

namespace XmuAuthor.Services
{
    public class AuthorizationService
    {
        ResourceManager ResourceManager;
        RoleManager RoleManager;
        public bool Authorize(IUserPrincipal user, string resourceName)
        {
            Resource resource = ResourceManager.GetResource(resourceName);
            if (resource == null)
            {
                return false;
            }
            List<Role> roles = RoleManager.GetRolesByUser(user);
            foreach (Role role in roles)
            {
                if (role.Resources.Contains(resource))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Role> GetRolesByUser(IUserPrincipal user)
        {
            return RoleManager.GetRolesByUser(user);
        }

        public List<string> GetResourseByUser(IUserPrincipal user)
        {
            List<string> resources = new List<string>();
            List<Role> roles = RoleManager.GetRolesByUser(user);
            foreach (Role role in roles)
            {
                foreach (Resource resource in role.Resources)
                {
                    if (!resources.Contains(resource.Name))
                    {
                        resources.Add(resource.Name);
                    }
                }
            }
            return resources;
        }

        public AuthorizationService()
        {
            ResourceManager = new ResourceManager();
            RoleManager = new RoleManager();
        }
    }
}