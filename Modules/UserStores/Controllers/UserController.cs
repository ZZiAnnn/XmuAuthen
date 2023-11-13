using Microsoft.AspNetCore.Mvc;
using NetCourse.Framework.Security;
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

        public ActionResult AddUser()
        {
            string name = Request.Query[nameof(name)].ToString();
            string pwd = Request.Query[nameof(pwd)].ToString();
            string number = Request.Query[nameof(number)].ToString();
            var (success, msg, user) = userStore.AddUser(name, pwd, number);
            return Ok(new
            {
                success,
                msg,
                data = user
            });
        }

        public ActionResult GetUser()
        {
            string name = Request.Query[nameof(name)].ToString();
            string pwd = Request.Query[nameof(pwd)].ToString();
            var (success, msg, user) = userStore.GetUser(name, pwd);
            return Ok(new
            {
                success,
                data = user
            });
        }

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
