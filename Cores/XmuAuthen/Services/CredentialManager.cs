using System.Text;
using NetCourse.Framework;
using NetCourse.Framework.Security;
using XmuAuthen.Models;
using System.Timers;

namespace XmuAuthen.Services
{
    public class CredentialManager:ISingletonDependency
    {
        protected Dictionary<string, Certification> Cache { get; set; }=new Dictionary<string, Certification>();
        private System.Timers.Timer timer;
        public CredentialManager()
        {
            timer = new System.Timers.Timer(300000); // 设置时间间隔为5分钟
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var keysToRemove = new List<string>();
            foreach (var pair in Cache)
            {
                if (pair.Value.ExpiredOn <= DateTime.Now)
                {
                    keysToRemove.Add(pair.Key);
                }
            }

            foreach (var key in keysToRemove)
            {
                Cache.Remove(key);
            }
        }
        
        string GetRandomKey()
        {
            string dict = "abcdefghijklmnopqrstuvwxyz1234567890";
            Random r = new Random();
            int length = r.Next(8,13);
            StringBuilder builder = new();
            int chaLength = dict.Length;
            for (int i = 0; i < length; ++i)
            {
                builder.Append(dict[r.Next(0, chaLength)]);
            }
            return builder.ToString();
        }

        public string GetCredential(IUserPrincipal user)
        {
            string key = GetRandomKey();//随机生成
            Certification certification = new(user, DateTime.Now.AddHours(1));
            Cache.Add(key, certification);
            return key;
        }
        public IUserPrincipal? GetUser(string key)
        {
            if(Cache.ContainsKey(key))
            {
                Certification cer = Cache[key];
                if (cer.ExpiredOn > DateTime.Now)
                {
                    Cache.Remove(key);
                    return null;
                }
                else return cer.UserPrincipal;
            }
            return null;
        }

        internal string RemoveCredential(string token)
        {
            if (Cache.ContainsKey(token))
            {
                Cache.Remove(token);
                return "注销成功";
            }
            else return "当前Token无效";
        }
    }
}
