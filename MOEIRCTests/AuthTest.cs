using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using System.Threading.Tasks;
using MOEIRCNet;
using MOEIRCNet.API;
using MOEIRCNet.Constants;
using Moq;
using MOEIRCNet.Classes.Credentials;
using MOEIRCNet.API.Request;
using MOEIRCNet.Classes;
using MOEIRCNet.Classes.Extensions;
using MOEIRCTests.SampleData;

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
            var request = new SendCounterValueRequest
            {
                id_counter = 18129329,
                id_counter_zn = "1",
                id_source = 76377,
                vl_indication = 131.111F,
                vl_provider = "{\"id_abonent\": 8171373}",
            };
            var rest = new Rest();
            await rest.SendCurrentValueAsync(request, "LGIZIIUY0UJZ_G2QFGCKATINE7EJZMYWS24JLIB9");
        }
        [Theory]
        [InlineData(URLs.API_URL, "cpux86@mail.ru", "J8aS_8AD*fRp$e3")]
        public async Task GetAccountsTest(string url, string login, string password)
        {

            #region IRest

            var mock = new Mock<IRest>();


            // тест без запроса к серверу
            IRest rest = mock.Object;


            // тест с запросом на сервер провайдера 
            //IRest rest = new Rest();

            var api = new Api(rest);


            mock.Setup(a =>
                    a.LoginAsync(url, login, password))
                .Returns(Sample.Auth);

            Session session = await api.Login(login, password);

            mock.Setup(a => a.GetAccountsAsync(url, session.SessionId))
                .Returns(Sample.Accounts);

            var account = await api.GetAccountAsync(session.SessionId);


            mock.Setup(a => a.GetCountersAsync(account.Abonent, session.SessionId)).Returns(Sample.Counters);


            IEnumerable<Counter> counters = await account.GetCounters();

            Assert.Equal(4, counters.Count());

            var counter = counters.GetCounterById("59234864");
 
            Assert.NotNull(counter);

            #endregion

        }


    }
}
