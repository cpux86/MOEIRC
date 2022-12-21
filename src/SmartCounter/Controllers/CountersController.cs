using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOEIRCNet.API;
using MOEIRCNet.Classes;
using MOEIRCNet.Classes.Extensions;

namespace SmartCounter.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CountersController : ControllerBase
    {
        private readonly IApi _api;
        //private readonly 

        public CountersController(IApi api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<List<Counter>> List()
        {
            var session = await _api.Login("cpux86@mail.ru", "J8aS_8AD*fRp$e3");
            var account = await _api.GetAccountAsync(session);
            var counters = await account.GetCounters();
            //await session.LogOff();
            return counters;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<string> Indication(string id, float value)
        {
            var session = await _api.Login("cpux86@mail.ru", "J8aS_8AD*fRp$e3");
            var account = await _api.GetAccountAsync(session);
            var counters = await account.GetCounters();
            var counter = counters.GetCounterById(id);
            var expenses = counter.AddValue(value);
            await _api.Send(counter, session);
            return expenses.ToString();
        }
    }
}
