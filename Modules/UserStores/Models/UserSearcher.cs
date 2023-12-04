using NetCourse.Framework.Database;
using NetCourse.Framework.Security;
namespace UserStores.Models
{
    public class UserSearcher
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string UserName { get; set; } = string.Empty;
        public Guid? Id { get; set; } = null;
    }
}
