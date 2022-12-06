using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOEIRCNet.API;
using MOEIRCNet.API.Responses;
using MOEIRCNet.Constants;
using Newtonsoft.Json;

namespace MOEIRCNet.Classes
{
    public class Session
    {
        private string _login;
        private string _password;

        private readonly IRest _rest;
        public string SessionId { get; set; }
        public DateTimeOffset CreatedBy { get; set; } = DateTimeOffset.Now;
        public long UnixTimeStamp { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();

        //public Session(string login, string password, IRest rest )
        //{
        //    _login = login;
        //    _password = password;
        //    _rest = rest;
        //}

        public Session(IRest rest)
        {
            _rest = rest;
        }

        //public static async Task<Credentials.Credentials> New(string login, string password, IRest rest)
        //{
        //    var response = await rest.GetCredentialsAsync(URLs.GetApiUrl(), login, password);

        //    var result = JsonConvert.DeserializeObject<GetCredentialsResponse>(response);
        //    Credentials.Credentials credentials = result?.data.FirstOrDefault(e => e.nm_result == "Ошибок нет");

        //    return credentials;
        //}

        public async Task LogOff()
        {
            await _rest.LogOutAsync(SessionId);
        }


    }
}
