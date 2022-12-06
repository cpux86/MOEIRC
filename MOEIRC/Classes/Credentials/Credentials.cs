using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MOEIRCNet.API;
using Newtonsoft.Json;

namespace MOEIRCNet.Classes.Credentials
{
    public class Credentials
    {
        private IRest _rest;

        //public Credentials(IRest rest)
        //{
        //    _rest = rest;
        //}
        public int kd_result { get; set; }
        public string nm_result { get; set; }
        //[JsonProperty("id_profile")]
        //public string ProfileId { get; set; }
        //public int cnt_auth { get; set; }
        //public string new_token { get; set; }

        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

        [JsonProperty("session")]
        public string Session { get; private set; }

    }
}
