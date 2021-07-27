using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.API.Payload
{
    class CredentialsPayload
    {
        public string login { get; internal set; }
        public string password { get; internal set; }

        public CredentialsPayload(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        
    }
}
