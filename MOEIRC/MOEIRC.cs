using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MOEIRCNet.Constants;
using Newtonsoft.Json;
using System.Linq;
using System.Xml;
using MOEIRCNet.API;
using MOEIRCNet.API.Request;
using MOEIRCNet.Classes.Credentials;
using MOEIRCNet.API.Responses;
using MOEIRCNet.Classes;
using MOEIRCNet.API.Responses.Accounts;
using MOEIRCNet.API.Responses.Counters;

namespace MOEIRCNet
{
    public class MOEIRC
    {

        private readonly string _login;
        private readonly string _password;
        private readonly IRest api;



        [JsonIgnore]
        internal Credentials Credentials { get; private set; }

        private string _session;
        public string Session => _session;

        public Abonent UserInfo { get; private set; }

        public IEnumerable<CounterResponse> Counters { get; private set; }



        public MOEIRC(string login, string password, IRest rest)
        {
            this._login = login;
            this._password = password;
            api = rest;
            Credentials = GetCredentials().Result;
            UserInfo = GetAccounts().Result;
            Counters = GetCountersList().Result;

        }

        private void Init()
        {
            // Login();
            // GetAccounts();
            //GetCountersList();
        }
        //private string Login(string login, string password)
        //{

        //}

        public async Task<Credentials> GetCredentials()
        {
            
            var response = await api.LoginAsync(URLs.GetApiUrl(), _login, _password);

            var res = JsonConvert.DeserializeObject<AuthenticationResponse>(response);
            
            //_session = res?.data.FirstOrDefault(e => e.nm_result == "Ошибок нет")?.Session ?? throw new Exception("Api Not Fount");

            //_session = res?.Session;
             //_session = res?.data?.Select(e => e.Session)
             //   .FirstOrDefault(e=>e != String.Empty) ?? throw new Exception("Api Not Fount");
            
            //_session = res?.data.First(e => e.Session != null).Session; // ?? throw new Exception();
            Credentials = res?.data.FirstOrDefault(e => e.nm_result == "Ошибок нет");

            return Credentials;
        }

        public async Task<IEnumerable<CounterResponse>> GetCountersList()
        {
            //await this.GetCredentials();
            //await this.GetAccounts();
            var res = await api.GetCountersAsync(this.UserInfo, this.Credentials.Session);
            var countersResponse = JsonConvert.DeserializeObject<GetCountersResponse>(res);
            //test
            
            Counters = countersResponse.data.Where(c => c.nm_measure_unit == "м3").ToList<CounterResponse>();
           
            
            return Counters;
        }

        public async Task<CounterResponse> GetCounterByNumber(string id)
        {
            //var counters = await GetCountersList() ?? throw new Exception("Counters Not Fount");
            return Counters?.FirstOrDefault(c => c.CounterNumber == id) ?? throw new Exception("Counter Not Fount");
        }

        /// <summary>
        /// Отправить текущие показания счетчика
        /// </summary>
        /// <param name="value">показания счетчика</param>
        /// <param name="counterId">номер счетчика</param>
        /// <returns></returns>
        public async Task SendCurrentValue(string value, string counterId)
        {
            var dto = new SendCounterValueRequest
            {
                vl_provider = UserInfo.ToJson()
            };
        }

        public async Task<Abonent> GetAccounts()
        {
            //await this.GetCredentials();
            var response = await api.GetAccountsAsync(URLs.GetApiUrl(), Credentials.Session);
            var getAccounts = JsonConvert.DeserializeObject<GetAccountsResponse>(response);
            //dynamic res = getAccounts?.data.Where(type => type.nm_type == "ЕПД").FirstOrDefault();
            dynamic res = getAccounts?.Accounts.FirstOrDefault(type => type.nm_type == "ЕПД");
            return JsonConvert.DeserializeObject<Abonent>(res?.vl_provider);
        }
    }
}
