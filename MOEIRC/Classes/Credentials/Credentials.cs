using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MOEIRCNet.Classes.Credentials
{
    public class Credentials
    {
        //public int kd_result { get; set; }
        //public string nm_result { get; set; }
        [JsonProperty("id_profile")]
        public string ProfileId { get; set; }
        //public int cnt_auth { get; set; }
        //public string new_token { get; set; }
        [JsonProperty("session")] public string Session { get; set; }
    }
}
