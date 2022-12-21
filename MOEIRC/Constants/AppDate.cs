using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MOEIRCNet.Constants
{
    public  class AppDate
    {
        internal const string APP_VERSION = "1.25.0";
        internal const string DEVICE_TYPE = "browser";
        internal const string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.106 Safari/537.36";

        public string appver;
        public string type;
        public string userAgent;

        public AppDate()
        {
            this.appver = APP_VERSION;
            this.type = DEVICE_TYPE;
            this.userAgent = USER_AGENT;
        }
    }
}
