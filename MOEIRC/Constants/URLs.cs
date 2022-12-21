using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.Constants
{
    public static class URLs
    {
        public const string API_URL =  "https://my.mosenergosbyt.ru/gate_lkcomu";

        public const string AUTH_ENDPOINT = "https://my.mosenergosbyt.ru/auth";
        public static string GetApiUrl()
        {
            return $"https://my.mosenergosbyt.ru/gate_lkcomu";
        }
    }
}
