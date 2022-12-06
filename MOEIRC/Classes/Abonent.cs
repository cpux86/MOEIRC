using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.Classes
{
    public class Abonent
    {
        [JsonProperty("id_abonent")]
        public int Id { get; private set; }
        public string ToJson() => JsonConvert.SerializeObject(this);
    }

}
