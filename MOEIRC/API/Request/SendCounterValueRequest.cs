using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MOEIRCNet.API.Request
{
    public class SendCounterValueRequest
    {
        public string dt_indication => DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
        public int id_counter { get; set; }
        public string id_counter_zn { get; set; }

        //id_pu -> id_source
        public int id_source { get; set; }
        public float vl_indication { get; set; }
        public string vl_provider { get; set; }
    }

}
