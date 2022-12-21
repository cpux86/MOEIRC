using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOEIRCNet.Classes;
using Newtonsoft.Json;

namespace MOEIRCNet.API.Responses.Counters
{
    public class GetCountersResponse
    {
        public bool success { get; set; }
        public int total { get; set; }
        public IList<CounterResponse> data { get; set; }
        //public IList<Counter> data { get; set; }

        //public Metadata metaData { get; set; }
    }
}
