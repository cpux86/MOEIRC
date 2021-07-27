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

            var body = new Payload.CredentialsPayload(login, password);
            var payLoad = JsonConvert.SerializeObject(new AppDate());
            
            var request = new RestRequest("gate_lkcomu", Method.POST);

            request.AddParameter("login", login);
            request.AddParameter("psw", password);
            request.AddParameter("vl_device_info", payLoad);

            request.AddParameter("action", "auth",ParameterType.QueryString);


            var cancellationTokenSource = new CancellationTokenSource();
            var responce = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            return responce.Content;
        }
    }
}
