using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using NetCourse.Framework.Security;
using UserStores.Models;
namespace UserStores.Services
{
    public class UserStore
    {
        private const string path = "./userlist.json";
        public List<User> UserList { get; set; } = new List<User>();

        public UserStore()
        {
            try
            {
                string json = string.Empty;
                json = File.ReadAllText(path);
                UserList = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch{ }

        }

        public bool IsPasswordValid(string password)
        {
            if (password.Length < 6 || password.Length > 16){
                return false;
            }

            int count = 0;
            if (password.Any(char.IsUpper)){
                count++;
            }
            if (password.Any(char.IsLower)){
                count++;
            }
            if (password.Any(char.IsDigit)){
                count++;
            }
            if (password.Any(c => !char.IsLetterOrDigit(c))){
                count++;
            }

            return count >= 3;
        }

        public (bool success, string msg, IUserPrincipal? user) AddUser(string name, string pwd, string number)
        {
            if (name.Length is < 6 || name.Length is > 12)
            {
                return (false, "用户名应在6到12位之间", null);
            }

            if (!IsPasswordValid(pwd))
            {
                return (false, "密码应当在6-16位之间，且至少包含大写字母、小写字母、数字、特殊符号之中至少三种", null);
            }

            if (number.Length is not 14)
            {
                return (false, "学号应为14位", null);
            }

            if (UserList.Any(e => e.UserName == name))
            {
                return (false, $"已经存在用户名为{name}的用户", null);
            }

            if (UserList.Any(e => e.StudentNo == number))
            {
                return (false, $"已经存在学号为{number}的用户", null);
            }

            var user = new User
            {
                ID = Guid.NewGuid(),
                UserName = name,
                Password = pwd,
                StudentNo = number
            };

            UserList.Add(user);
            SaveUser();

            return (true, string.Empty, user);
        }

        public IUserPrincipal? GetUser(string userName,string pwd)
            => UserList.FirstOrDefault(e => e.UserName == userName && e.Password == pwd);
        //public (bool success, string msg, IUserPrincipal? user) GetUser(string userName, string pwd)
        //{
        //    var user = UserList.FirstOrDefault(e => e.UserName == userName && e.Password == pwd);
        //    if (user == null)
        //    {
        //        return (false, "用户名或密码错误", user);
        //    }
        //    return (true, string.Empty, user);
        //}

        public (bool success, string msg, Guid? id) RemoveUser(string userName)
        {
            var user = UserList.FirstOrDefault(e => e.UserName == userName);
            if (user == null)
            {
                return (false, "用户不存在", null);
            }

            UserList.Remove(user);
            SaveUser();
            return (true, string.Empty, user.ID);
        }

        private void SaveUser()
        {
            string json = JsonSerializer.Serialize(UserList);
            File.WriteAllText(path, json);
        }
    }
}
