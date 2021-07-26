using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MOEIRC.API
{
    public static class Rest
    {
        public static async Task<string> GetCredentials(string url, string login, string password)
        {
            var client = new RestClient(url);
            var body = new Payload.CredentialsPayload(login, password);

            var request = new RestRequest("gate_lkcomu", Method.POST);
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.QueryStringWithoutEncode);
            request.RequestFormat = DataFormat.None;

            var cancellationTokenSource = new CancellationTokenSource();
            var responce = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            return responce.Content;
        }
    }
}
