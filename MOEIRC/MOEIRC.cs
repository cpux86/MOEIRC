using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MOEIRCNet.Constants;
using Newtonsoft.Json;
using System.Linq;
using MOEIRCNet.API;
using MOEIRCNet.API.Request;
using MOEIRCNet.Classes.Credentials;
using MOEIRCNet.API.Responses;
using MOEIRCNet.Classes;

namespace MOEIRCNet
{
    public class MOEIRC
    {

        private readonly string _login;
        private readonly string _password;
        private readonly IRest api;



        [JsonIgnore]
        internal Credentials Credentials { get; private set; }

        public UserInfo UserInfo { get; private set; }

        public IEnumerable<Counter> Counters { get; private set; }

        

        public MOEIRC(string login, string password, IRest rest)
        {
            this._login = login;
            this._password = password;
            api = rest;
            Credentials = GetCredentials().Result;
            UserInfo = GetAccounts().Result;
            //Counters = GetCountersList().Result;

        }

        public async Task<Credentials> GetCredentials()
        {
            

            var response = await api.GetCredentialsAsync(URLs.GetApiUrl(), _login, _password);

            GetCredentialsResponse res = JsonConvert.DeserializeObject<GetCredentialsResponse>(response);

            //dynamic test = JsonConvert.DeserializeObject(response);
            //var i = test.data[0];
            //dynamic i = JsonConvert.DeserializeObject<GetCredentialsResponse>(test);

            //i = i.ToString();
            //Credentials = JsonConvert.DeserializeObject<Credentials>(res.data);
            //Credentials = res?.data.FirstOrDefault() as Credentials;
            //var session = res?.data.Select(e => new { e.Session }).FirstOrDefault();
            var session = res?.data.Select(e => e.Session)
                .FirstOrDefault() ?? throw new Exception("Api Not Fount");
            Credentials = res?.data.First(e => e.Session != null);
                



            return Credentials;
        }

        public async Task<IEnumerable<Counter>> GetCountersList()
        {
            //await this.GetCredentials();
            //await this.GetAccounts();
            var res = await api.GetCountersAsync(this.UserInfo, this.Credentials.Session);
            var countersResponse = JsonConvert.DeserializeObject<GetCountersResponse>(res);
            //test
            
            Counters = countersResponse.data.Where(c => c.nm_measure_unit == "м3").ToList<Counter>();
           
            
            return Counters;
        }

        public async Task<Counter> GetCounterByNumber(string id)
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

        public async Task<UserInfo> GetAccounts()
        {
            //await this.GetCredentials();
            var response = await api.GetAccountsAsync(URLs.GetApiUrl(), Credentials.Session);
            var getAccounts = JsonConvert.DeserializeObject<GetAccountsResponse>(response);
            //dynamic res = getAccounts?.data.Where(type => type.nm_type == "ЕПД").FirstOrDefault();
            dynamic res = getAccounts?.data.FirstOrDefault(type => type.nm_type == "ЕПД");
            return JsonConvert.DeserializeObject<UserInfo>(res?.vl_provider);
        }
    }
}
