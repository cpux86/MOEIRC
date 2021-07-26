using System;
using Xunit;
using MOEIRC.API;

namespace MOEIRCTests
{
    public class AuthTest
    {
        [Fact]
        public void Test1()
        {
            var moeirc = Rest.GetCredentials("https://my.mosenergosbyt.ru","cpux86@mail.ru","");
        }
    }
}
