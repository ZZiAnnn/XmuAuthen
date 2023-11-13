namespace NetCourse.Framework.Security
{
    public interface IUserStore : ISingletonDependency
    {
        (bool success, string msg, IUserPrincipal? user) AddUser(string name, string pwd, string number);
        (bool success, string msg, IUserPrincipal? user) GetUser(string userName, string pwd);
        (bool success, string msg, IUserPrincipal? user) RemoveUser(string userName);

    }
}
