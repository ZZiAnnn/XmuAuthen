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
            var (success, msg, user) = userStore.AddUser(name, pwd);
            return Ok(new
            {
                success,
                msg,
                data = user
            });
        }
    }
}
