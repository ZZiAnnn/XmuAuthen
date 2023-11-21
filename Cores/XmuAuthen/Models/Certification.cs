using NetCourse.Framework.Security;

namespace XmuAuthen.Models
{
    public class Certification
    {
        public IUserPrincipal UserPrincipal { get; set; }
        public DateTime ExpiredOn { get; set; }
        public Certification(IUserPrincipal user,DateTime ExpriredOn) 
        {
            UserPrincipal = user;
            ExpiredOn = ExpiredOn;
        }
    }
}
