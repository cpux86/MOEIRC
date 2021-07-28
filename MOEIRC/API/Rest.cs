using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MOEIRCNet.Constants;
using Newtonsoft.Json;

namespace MOEIRCNet.API
{
    public static class Rest
    {
        public static async Task<string> GetCredentials(string url, string login, string password)
        {
            var client = new RestClient(url);
            client.UserAgent = AppDate.USER_AGENT;
            client.CookieContainer = new System.Net.CookieContainer();
            

            var body = new Payload.CredentialsPayload(login, password);
            var payLoad = JsonConvert.SerializeObject(new AppDate());
            
            var request = new RestRequest("gate_lkcomu", Method.POST);

            request.AddParameter("login", login);
            request.AddParameter("psw", password);
            request.AddParameter("vl_device_info", payLoad);
            request.AddCookie("session-cookie", "1695e9c2b31f6ecaa28964d4beb261f5288e30a1b633d252854f28b99959934dd03e8a59ddbb61a04c3d7010b2bb292b");
            request.AddParameter("action", "auth",ParameterType.QueryString);
            request.AddHeader("Referer", "https://my.mosenergosbyt.ru/auth");

            var cancellationTokenSource = new CancellationTokenSource();
            var responce = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            
            return responce.Content;
        }
    }
}
