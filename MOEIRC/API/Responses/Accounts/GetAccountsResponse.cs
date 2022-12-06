using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MOEIRCNet.API.Responses.Accounts
{

    public class GetAccountsResponse : WrapperResponse
    {
        [JsonProperty("data")]
        public AccountResponse[] Accounts { get; set; }
        public Metadata metaData { get; set; }
    }
}
