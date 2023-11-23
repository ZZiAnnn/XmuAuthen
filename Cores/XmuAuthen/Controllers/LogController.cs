using System.Text.Json.Serialization;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCourse.Framework.Security;
using XmuAuthen.Services;
using Newtonsoft.Json.Linq;
using XmuAuthen.Models;

namespace UserStores.Controllers
{
    [Route("/api/{action}")]
    public class LogController : Controller
    {
        public record LoginForm(string username,string password);
        private AuthenService authenService;
        public LogController(AuthenService authenService) 
        {
            this.authenService = authenService; 
        }

        [HttpPost]
        public ActionResult Login([FromBody]LoginForm form)
        {
            var token=authenService.SignOn(form.username,form.password);
            if(token==null)
            {
                return Ok(new
                {
                    success = "failed",
                    msg = "用户名或密码错误",
                    data = ""
                });
            }
            return Ok(new
            {
                success = "success",
                msg = "登录成功",
                data = token
            });
        }

        [HttpDelete]
        public ActionResult Logout([FromHeader] string token)
        {
            var msg=authenService.SignOff(token);
            return Ok(new
            {
                success = "success",
                msg,
                data = ""
            });
        }
    }



}
