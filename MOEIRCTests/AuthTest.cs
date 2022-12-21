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
using MOEIRCNet.API.Responses.Counters;
using MOEIRCNet.Classes;
using MOEIRCNet.Classes.Extensions;
using MOEIRCTests.SampleData;

namespace MOEIRCTests
{
    public class AuthTest
    {

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

            var session = await api.Login(login, password);


            mock.Setup(a => a.GetAccountsAsync(url, session.SessionId))
                .Returns(Sample.Accounts);


            var account = await api.GetAccountAsync(session);

            //await session.LogOff();

            mock.Setup(a => a.GetCountersAsync(account.Abonent, session.SessionId)).Returns(Sample.Counters);


            IEnumerable<Counter> counters = await account.GetCounters();
            
            Assert.Equal(4, counters.Count());

            var counter = counters.GetCounterById("59234864");

            counter.AddValue(175.610f);

            await api.Send(counter, session);


            Assert.NotNull(counter);
  

            #endregion

        }


    }
}
