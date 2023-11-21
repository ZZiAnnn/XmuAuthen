using NetCourse.Framework.Database;
using NetCourse.Framework.Security;
namespace UserStores.Models
{
    public class User :EntityBase,IUserPrincipal
    {
        #region Fields
        public Guid ID { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string StudentNo {  get; set; } = string.Empty;
        public string LastLoginTime { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        #endregion
        #region Constructors
        public User() { }

        public User(string userName, string password, string avatar)
        {
            UserName = userName;
            Password = password;
            Avatar = avatar;
        }
        #endregion
    }
}
