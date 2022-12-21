using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using MOEIRCNet.API.ExceptionExtensions;
using MOEIRCNet.API.Request;
using MOEIRCNet.API.Responses;
using MOEIRCNet.API.Responses.Accounts;
using MOEIRCNet.API.Responses.Counters;
using MOEIRCNet.Classes;
using MOEIRCNet.Classes.Credentials;
using MOEIRCNet.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MOEIRCNet.API
{

    public class Api : IApi
    {
        private readonly IRest _rest;
        private Account _account;

        public Api(IRest rest)
        {
            _rest = rest;
        }

        public async Task<Session> Login(string login, string password)
        {
            var responseJson = await _rest.LoginAsync(URLs.API_URL, login, password);

            var auth = JsonConvert.DeserializeObject<AuthenticationResponse>(responseJson) as IAuth ?? throw new Exception("Authentication error");

            return new Session(_rest)
            {
                SessionId = auth.Session
            };
        }

        public async Task<Account> GetAccountAsync(Session session)
        {
            if (!session.IsValid) throw new Exception("Session Invalid");

            var accountsJson = await _rest.GetAccountsAsync(URLs.API_URL, session.SessionId);
            var accountsObject = JsonConvert.DeserializeObject<GetAccountsResponse>(accountsJson);
            _account = accountsObject?.Accounts
                .Where(type => type.nm_type == "ЕПД")
                .Select(acc => new Account(_rest, session)
                {
                    Number = acc.nn_ls,
                    AccountType = acc.nm_type,
                    Address = acc.nm_ls_group_full,
                    ServiceProvider = acc.nm_provider,
                    Abonent = JsonConvert.DeserializeObject<Abonent>(acc.vl_provider)

                }).FirstOrDefault() ?? throw new BadServerProviderException("Не верный ответ сервера");

            return _account;
        }

        public async Task Send(Counter counter, Session session)
        {
            var request = new SendCounterValueRequest
            {
                id_counter = counter.CounterId,
                id_source = counter.ProviderId,
                id_counter_zn = "1",
                vl_indication = counter.OldCounterValue.ToString(CultureInfo.GetCultureInfo("en-US")),
                vl_provider = _account.Abonent.ToJson()
            };
            await _rest.SendCurrentValueAsync(request, session.SessionId);
        }

    }
}
