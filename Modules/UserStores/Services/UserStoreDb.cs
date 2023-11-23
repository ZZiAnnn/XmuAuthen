using NetCourse.Framework.Database;
using NetCourse.Framework.Security;
using UserStores.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserStores.Services
{
    public class UserStoreDb : IUserStore
    {
        private IServiceProvider provider;
        public UserStoreDb(IServiceProvider sP)
        {
            provider = sP;
        }

        public bool IsPasswordValid(string password)
        {
            if (password.Length < 6 || password.Length > 16)
            {
                return false;
            }

            int count = 0;
            if (password.Any(char.IsUpper))
            {
                count++;
            }
            if (password.Any(char.IsLower))
            {
                count++;
            }
            if (password.Any(char.IsDigit))
            {
                count++;
            }
            if (password.Any(c => !char.IsLetterOrDigit(c)))
            {
                count++;
            }

            return count >= 3;
        }

        public (bool success, string msg, IUserPrincipal? user) AddUser(string name, string pwd, string StudentNo)
        {
            using var scope = provider.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<NetContext>();
            if (name.Length < 6 || name.Length > 12)
            {
                return (false, "用户名应在6到12位之间", null);
            }

            if (!IsPasswordValid(pwd))
            {
                return (false, "密码应当在6-16位之间，且至少包含大写字母、小写字母、数字、特殊符号之中至少三种", null);
            }

            List<User> UserList = repo.Set<User>().ToList();

            if (StudentNo.Length != 14)
            {
                return (false, "学号应为14位", null);
            }

            if (UserList.Any(e => e.UserName == name))
            {
                return (false, $"已经存在用户名为{name}的用户", null);
            }

            if (UserList.Any(e => e.StudentNo == StudentNo))
            {
                return (false, $"已经存在学号为{StudentNo}的用户", null);
            }

            User u = new User()
            {
                ID = Guid.NewGuid(),
                UserName = name,
                Password = pwd,
                StudentNo = StudentNo
            };

            repo.Add(u);
            repo.SaveChanges();
            return (true, "添加成功", u);

        }

        public IUserPrincipal? GetUser(string userName, string pwd)
        {
            using var scope = provider.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<NetContext>();
            var query = from u in repo.Set<User>()
                        where u.UserName == userName && u.Password == pwd
                        select u;
            return query?.FirstOrDefault();
        }

        public (bool success, string msg, Guid? id) RemoveUser(string userName)
        {
            User user = new User()
            {
                UserName = userName,
            };
            using var scope = provider.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<NetContext>();
            var query = from u in repo.Set<User>()
                        where u.UserName == userName
                        select user;
            if (user == null)
            {
                return (false, "用户不存在", null);
            }
            repo.Remove(user);
            repo.SaveChanges();
            return (true, "", user.ID);
        }
    }
}
