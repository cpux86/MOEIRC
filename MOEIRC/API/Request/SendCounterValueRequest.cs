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
        //[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ssK")]

        public string dt_indication => DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
        public string vl_provider { get; set; }
    }







    //public class DateFormatConverter : IsoDateTimeConverter
    //{
    //    public DateFormatConverter(string format)
    //    {
    //        DateTimeFormat = format;
    //    }
    //}
}
