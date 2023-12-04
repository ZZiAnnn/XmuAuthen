
namespace NetCourse.Framework.Security
{
    public interface IUserStore:ISingletonDependency
    {
        IUserPrincipal? GetUser(string userName, string pwd);
        List<IUserPrincipal?> GetUsers(int page, int size, string name = "", Guid? id = null);
        (bool success, string msg, IUserPrincipal? user) AddUser(string name, string pwd,string StudentNo);
        public (bool success, string msg, Guid? id) RemoveUser(string userName);
    }
}
