using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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

        public ActionResult RemoveUser()
        {   
            string Id= Request.Query[nameof(userId)].ToString();
            var(success,msg,Id)=user
            return Ok(new
            {
                success,
                msg,
                data = Id
            }); 
        }
    }
}
