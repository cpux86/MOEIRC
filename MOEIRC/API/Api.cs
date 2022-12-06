using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOEIRCNet.API.ExceptionExtensions;
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

        public async Task<Account> GetAccountAsync(string session)
        {
            var accountsJson = await _rest.GetAccountsAsync(URLs.API_URL, session);
            var accountsObject = JsonConvert.DeserializeObject<GetAccountsResponse>(accountsJson);
            var account = accountsObject?.Accounts
                .Where(type => type.nm_type == "ЕПД")
                .Select(acc => new Account(_rest, session)
                {
                    Number = acc.nn_ls,
                    AccountType = acc.nm_type,
                    Address = acc.nm_ls_group_full,
                    ServiceProvider = acc.nm_provider,
                    Abonent = JsonConvert.DeserializeObject<Abonent>(acc.vl_provider)

                }).FirstOrDefault() ?? throw new BadServerProviderException("Не верный ответ сервера");

            return account;
        }

        public async Task GetCountersAsync(Abonent abonent, string session)
        {
            //var countersJson = await _rest.GetCountersAsync(abonent, session);
            //var countersObject = JsonConvert.DeserializeObject<GetCountersResponse>(countersJson);
        }

    }
}
