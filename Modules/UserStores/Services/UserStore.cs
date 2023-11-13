using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using NetCourse.Framework.Security;
using UserStores.Models;
namespace UserStores.Services
{
    public class UserStore : IUserStore
    {
        private const string path = "./users.json";
        public List<User> UserList { get; set; } = new List<User>();

        public UserStore()
        {
            try
            {
                string json = string.Empty;
                json = File.ReadAllText(path);
                UserList = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch
            {

            }

        }

        public (bool success, string msg, IUserPrincipal? user) AddUser(string name, string pwd)
        {


            if (UserList.Any(e => e.UserName == name))
            {
                return (false, $"用户名{name}重复！", null);
            }

            var user = new User
            {
                ID = Guid.NewGuid(),
                UserName = name,
                Password = pwd,
            };

            UserList.Add(user);
            Save();

            return (true, string.Empty, user);
        }

        public IUserPrincipal? GetUser(string userName, string pwd) => UserList.FirstOrDefault(e => e.UserName == userName && e.Password == pwd);

        public IUserPrincipal? RemoveUser(string userName)
        {
            var user = UserList.FirstOrDefault(e => e.UserName == userName);
            if (user == null)
            {
                return null;
            }

            UserList.Remove(user);
            Save();
            return user;
        }

        private void Save()
        {
            string json = JsonSerializer.Serialize(UserList);
            File.WriteAllText(path, json);
        }
    }
}
