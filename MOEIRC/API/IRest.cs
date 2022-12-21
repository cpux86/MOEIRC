using MOEIRCNet.API.Request;
using MOEIRCNet.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MOEIRCNet.API
{
    public interface IRest
    {
        public Task<string> GetAccountsAsync(string url, string accessToken);
        public Task<string> LoginAsync(string url, string login, string password);
        public Task<string> GetCountersAsync(Abonent clientId, string accessToken);
        public Task LogOutAsync(string accessToken);

        public Task SendCurrentValueAsync(SendCounterValueRequest payload, string accessToken);
    }
}
