using System;
using Xunit;
using System.Threading.Tasks;
using MOEIRCNet;

namespace MOEIRCTests
{
    public class AuthTest
    {
        [Fact]
        public async Task Test1()
        {
            var moeirc = new MOEIRCNet.MOEIRC("cpux86@mail.ru", "J8aS_8AD*fRp$e3");
            var res = await moeirc.GetCredentials();

        }
    }
}
