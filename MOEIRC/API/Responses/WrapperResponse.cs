using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MOEIRCNet.API.Responses
{
    public abstract class WrapperResponse
    {
        //public bool success { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
        //public int total { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
