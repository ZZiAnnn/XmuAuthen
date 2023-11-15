using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NetCourse.Framework.Security;
using UserStores.Models;

namespace UserStores.Controllers
{
    [Route("/api/user/{action}")]
    public class UserController : Controller
    {
        private IUserStore userStore;
        public UserController(IUserStore userStore)
        {
            this.userStore = userStore;
        }

        [HttpPut]
        public ActionResult AddUser([FromBody] User u)
        {
            var (success, msg, user) = userStore.AddUser(u.UserName,u.Password,u.StudentNo);
            return Ok(new
            {
                success,
                msg,
                data = user
            });
        }

        [HttpGet]
        public ActionResult GetUser()
        {
            string name = Request.Query[nameof(name)].ToString();
            string pwd = Request.Query[nameof(pwd)].ToString();
            var (success, msg, user) = userStore.GetUser(name, pwd);
            return Ok(new
            {
                success,
                msg,
                data = user
            });
        }

        [HttpDelete]
        public ActionResult RemoveUser()
        {
            string name = Request.Query[nameof(name)].ToString();
            var (success, msg, user) = userStore.RemoveUser(name);
            return Ok(new
            {
                success,
                msg,
                data = user
            });
        }
    }
}
