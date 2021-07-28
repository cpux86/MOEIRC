using System;
using System.Threading.Tasks;
using MOEIRCNet.Classes;
using MOEIRCNet.Constants;
using Newtonsoft.Json;

namespace MOEIRCNet
{
    public class MOEIRC
    {

        public string Login { get; set; }
        public string Password { get; set; }


        [JsonIgnore]
        internal Credentials Credentials { get; private set; }

        public MOEIRC(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public async Task<Credentials> GetCredentials()
        {
            var response = await API.Rest.GetCredentials(URLs.GetApiUrl(),Login, Password);
            dynamic test = JsonConvert.DeserializeObject(response);
            var i = test.data[0];
            i = i.ToString();
            Credentials = JsonConvert.DeserializeObject<Credentials>(i);
            return Credentials;
        }
    }
}
