using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOEIRCNet.API;
using MOEIRCNet.API.Responses.Counters;
using MOEIRCNet.Classes.Extensions;
using Newtonsoft.Json;

namespace MOEIRCNet.Classes
{
    public class Account
    {
        private readonly IRest _rest;
        private readonly string _session;
        public Account(IRest rest, string session)
        {
            _rest = rest;
            _session = session;
        }

        /// <summary>
        /// Номер лицевого счета
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// поставщик услуг
        /// </summary>
        public string ServiceProvider { get; set; }
        public Abonent Abonent { get; set; }
        public string Address { get; set; }
        public string AccountType { get; set; }

        public async Task<List<Counter>> GetCounters()
        {
            var countersJson = await _rest.GetCountersAsync(Abonent, _session);

            var countersObject = JsonConvert.DeserializeObject<GetCountersResponse>(countersJson);

            var countersList = countersObject?.data
                .Where(c => c.nm_measure_unit == "м3")
                .Select(e => new Counter
                {
                    CounterNumber = e.CounterNumber,
                    CounterValue = e.CounterValue,
                    LastIndication = e.LastIndication,
                    ServiceName = e.ServiceName,
                    ServiceProvider = e.ServiceProvider,
                    NextVerificationData = e.NextVerificationData
                })
                .ToList();
            return countersList;
        }

    }
}
