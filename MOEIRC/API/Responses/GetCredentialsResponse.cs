using System;
using System.Collections.Generic;
using System.Text;
using MOEIRCNet.Classes.Credentials;
using Newtonsoft.Json;

namespace MOEIRCNet.API.Responses
{
    public class GetCredentialsResponse
    {
        public bool success { get; set; }
        public int total { get; set; }
        public Credentials[] data { get; set; }
        public Metadata metaData { get; set; }
    }

    public class Metadata
    {
        public float responseTime { get; set; }
    }

}
