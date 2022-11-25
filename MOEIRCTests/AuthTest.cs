using System;
using System.IO;
using Xunit;
using System.Threading.Tasks;
using MOEIRCNet;
using MOEIRCNet.API;
using MOEIRCNet.Constants;
using Moq;
using MOEIRCNet.Classes.Credentials;
using MOEIRCNet.API.Request;

namespace MOEIRCTests
{
    public class AuthTest
    {
        [Fact]
        public async Task Test1()
        {
            //var api = new Rest();
            //var moeirc = new MOEIRC("cpux86@mail.ru", "J8aS_8AD*fRp$e3", api);
            //var res = await moeirc.GetCredentials();
            var request = new SendCounterValueRequest();
            var dt = request.dt_indication;
            var rest = new Rest();
            await rest.SendCurrentValueAsync(request, "LGIZIIUY0UJZ_G2QFGCKATINE7EJZMYWS24JLIB9");
        }
        [Theory]
        [InlineData(URLs.API_URL, "cpux86@mail.ru", "J8aS_8AD*fRp$e3")]
        public async Task GetAccountsTest(string url, string login, string password)
        {

            var accounts = File.ReadAllTextAsync(@"C:\C#\MOEIRC\MOEIRCTests\SampleData\accounts.json");
            var auth = File.ReadAllTextAsync(@"C:\C#\MOEIRC\MOEIRCTests\SampleData\auth.json");
            var counters = File.ReadAllTextAsync(@"C:\C#\MOEIRC\MOEIRCTests\SampleData\counters.json");

            var mock = new Mock<IRest>();

            
            mock.Setup(a =>
                a.GetCredentialsAsync(url, login , password))
                .Returns(auth);

            mock.Setup(a => a.GetAccountsAsync(url, "LGIZIIUY0UJZ_G2QFGCKATINE7EJZMYWS24JLIB9"))
                .Returns(accounts);


            // тест без запроса к серверу
            //IRest api = mock.Object;

            // тест с запросом на сервер провайдера 
            IRest api = new Rest();

            var moeirc = new MOEIRC("cpux86@mail.ru", "J8aS_8AD*fRp$e3", api);

            //await moeirc.GetCredentials();
            //await moeirc.GetAccounts();

            mock.Setup(a => a.GetCountersAsync(moeirc.UserInfo, "LGIZIIUY0UJZ_G2QFGCKATINE7EJZMYWS24JLIB9"))
                .Returns(counters);


            await moeirc.GetCountersList();
            var counter = await moeirc.GetCounterByNumber("59234864");
            
            
        }

        
    }
}
