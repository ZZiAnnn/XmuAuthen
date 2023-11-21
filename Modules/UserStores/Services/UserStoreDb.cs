using NetCourse.Framework.Database;
using NetCourse.Framework.Security;
using UserStores.Models;

namespace UserStores.Services
{
    public class UserStoreDb
    {
        private IServiceProvider provider;
        public UserStoreDb(IServiceProvider sP) 
        {
            provider = sP;
        }
        public (bool success, string msg, IUserPrincipal? user) AddUser(string name, string pwd, string StudentNo)
        {
            User u = new User()
            {
                UserName = name,
                Password = pwd,
                StudentNo = StudentNo
            };
            using var scope = provider.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<NetContext>();
            repo.Set<User>();//db set的对象
            //var query=from us in repo.Set<User>()
            //          where us.UserName == name && us.Password == pwd
            //          select us; 
            //repo.DbContext.SaveChanges();
            return (true,"s",u);

        }

        public (bool success, string msg, IUserPrincipal? user) GetUser(string userName, string pwd)
        {
            throw new NotImplementedException();
        }

        public (bool success, string msg, Guid? id) RemoveUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
