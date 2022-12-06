using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOEIRCNet.Classes.Credentials;
using Newtonsoft.Json;

namespace MOEIRCNet.API.Responses
{
    public class AuthenticationResponse : WrapperResponse, IAuth
    {
        public Credentials[] data { get; set; }
        public Metadata metaData { get; set; }

        public string Session => this.data.FirstOrDefault(e => e.nm_result == "Ошибок нет")?.Session ?? throw new Exception("Api Not Fount");
    }


    public interface IAuth
    {
        public string Session { get;}
    }

}
