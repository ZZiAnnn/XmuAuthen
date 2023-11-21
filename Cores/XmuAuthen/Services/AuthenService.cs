using NetCourse.Framework;
using NetCourse.Framework.Security;

namespace XmuAuthen.Services
{
    public class AuthenService:ISingletonDependency
    {
        protected CredentialManager credentialManager;
        protected IUserStore userStore;

        public AuthenService(CredentialManager cM,IUserStore uS)
        {
            this.credentialManager = cM;
            this.userStore = uS;
        }

        public string? SignOn(string username,string pwd)
        {
            IUserPrincipal? up = userStore.GetUser(username, pwd);
            if (up == null)
            {
                return null;
            }
            return credentialManager.GetCredential(up);
        }

        public string SignOff(string token)
        {
            return credentialManager.RemoveCredential(token);
        }
    }
}
