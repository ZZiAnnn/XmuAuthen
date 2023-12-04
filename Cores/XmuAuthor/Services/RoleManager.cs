using XmuAuthor.Models;
using NetCourse.Framework.Security;

namespace XmuAuthor.Services
{
    public class RoleManager
    {
        private List<Role> AllRoles;
        private List<RoleUserMapping> AllRoleUserMappings;
        public List<Role> GetRolesByUser(IUserPrincipal user)
        {
            List<Role> roles = new List<Role>();
            foreach (RoleUserMapping mapping in AllRoleUserMappings)
            {
                if (mapping.UserID == user.ID)
                {
                    roles.Add(AllRoles.Find(r => r.ID == mapping.RoleID));
                }
            }
            return roles;
        }
        public RoleManager()
        {
            AllRoles = new List<Role>();
            AllRoleUserMappings = new List<RoleUserMapping>();
        }
    }
}