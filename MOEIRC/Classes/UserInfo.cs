using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.Classes
{
    public class UserInfo
    {
        [JsonProperty("id_abonent")]
        public int AbonentId { get; set; }
        public string ToJson() => JsonConvert.SerializeObject(this);
    }

}
