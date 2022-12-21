using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MOEIRCNet.API.Request;
using MOEIRCNet.API.Responses;
using MOEIRCNet.Classes;
using MOEIRCNet.Constants;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;
using System.Net;
using System.Net.Mime;
using ContentType = RestSharp.Serializers.ContentType;

namespace MOEIRCNet.API
{
    public class Rest : RestBase, IRest
    {
        public async Task<string> LoginAsync(string url, string login, string password)
        {
            //var body = new Payload.CredentialsPayload(login, password);
            var payLoad = JsonConvert.SerializeObject(new AppDate());

            var Request = new RestRequest()
            {
                Timeout = 1000
            };
            
            //request.AddParameter("login", login);
            //request.AddParameter("psw", password);

            Request.AddObject(new { login = login, psw = password });
            Request.AddParameter("vl_device_info", payLoad);
            //Request.AddCookie("session-cookie", "1695e9c2b31f6ecaa28964d4beb261f5288e30a1b633d252854f28b99959934dd03e8a59ddbb61a04c3d7010b2bb292b");

            Request.AddQueryParameter("action", "auth");
            Request.AddHeader("Referer", URLs.AUTH_ENDPOINT);
            
            var cancellationTokenSource = new CancellationTokenSource();

            var response = await Client.PostAsync(Request, cancellationTokenSource.Token);

            // если сервер вернул ошибку
            if (response.ResponseStatus == ResponseStatus.Error) throw new Exception("Resource not fount");
            if (response.ContentType != ContentType.Json) throw new Exception("Bad request");

            return response.Content;

        }
        // получить лицевой счет
        // здесь нужно получить id_abonent
        public async Task<string> GetAccountsAsync(string url, string accessToken)
        {
            var request = new RestRequest();
            request.AddParameter("action", "sql", ParameterType.QueryString);
            request.AddParameter("query", "LSList", ParameterType.QueryString);
            request.AddParameter("session", accessToken, ParameterType.QueryString);
            
            var cancellationTokenSource = new CancellationTokenSource();
            var response = await Client.PostAsync(request, cancellationTokenSource.Token);

            return response.Content;
        }

        public async Task<string> GetCountersAsync(Abonent clientId, string accessToken)
        {
            var request = new RestRequest();
            request.AddParameter("plugin", "smorodinaTransProxy");
            request.AddParameter("proxyquery", "AbonentEquipment");
            request.AddParameter("vl_provider", clientId.ToJson());

            request.AddParameter("action", "sql", ParameterType.QueryString);
            request.AddParameter("query", "smorodinaTransProxy", ParameterType.QueryString);
            request.AddParameter("session", accessToken, ParameterType.QueryString);

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await Client.ExecuteAsync(request, cancellationTokenSource.Token);

            return response.Content;
        }

        public async Task SendCurrentValueAsync(SendCounterValueRequest payload, string accessToken)
        {
            var request = new RestRequest();
            request.AddQueryParameter("action", "sql");
            request.AddQueryParameter("query", "AbonentSaveIndication");
            request.AddQueryParameter("session", accessToken);

            request.AddParameter("plugin", "propagateMoeInd");
            request.AddParameter("pr_skip_anomaly", 0);
            request.AddParameter("pr_skip_err", 0);

            request.AddObject(payload);

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await Client.PostAsync(request, cancellationTokenSource.Token);
        }

        public async Task LogOutAsync(string accessToken)
        {
            var request = new RestRequest();
            request.AddQueryParameter("action", "invalidate");
            request.AddQueryParameter("query", "ProfileExit");
            request.AddQueryParameter("session", accessToken);

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await Client.PostAsync(request, cancellationTokenSource.Token);
        }

    }
}
