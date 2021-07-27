using System;
using System.Threading.Tasks;
using MOEIRCNet.Constants;

namespace MOEIRCNet
{
    public class MOEIRC
    {

        public string Login { get; set; }
        public string Password { get; set; }

        public MOEIRC(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public async Task<string> GetCredentials()
        {
            return await API.Rest.GetCredentials(URLs.GetApiUrl(),Login, Password);
        }
    }
}
