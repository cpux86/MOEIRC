using MOEIRCNet.Constants;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.API
{
    public abstract class RestBase
    {
        private RestClient _client;

        public RestClient Client
        {
            get
            {
                // implementation pattern singleton 
                _client = _client ?? new RestClient(URLs.API_URL)
                {
                    UserAgent = AppDate.USER_AGENT,
                    CookieContainer = new System.Net.CookieContainer()
                };
                return _client;
            }
        }
    }
}
