using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOEIRCNet.API;
using MOEIRCNet.API.Responses;
using MOEIRCNet.API.Responses.Counters;
using MOEIRCNet.Classes.Extensions;
using MOEIRCNet.Constants;
using Newtonsoft.Json;

namespace MOEIRCNet.Classes
{
    public class Account
    {
        private readonly IRest _rest;
        private readonly Session _session;

        public Account(IRest rest, Session session)
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
            // session validate 
            if (!_session.IsValid) throw new Exception("Session Invalid");

            var countersJson = await _rest.GetCountersAsync(Abonent, _session.SessionId);

            var countersObject = JsonConvert.DeserializeObject<GetCountersResponse>(countersJson);

            var countersList = countersObject?.data?
                .Where(c => c.nm_measure_unit == "м3")
                .Select(e => new Counter(new CounterDto
                {
                    CounterId = e.CounterId,
                    CounterNumber = e.CounterNumber,
                    LastCounterValue = e.LastCounterValue,
                    DateLastCounterValue = e.DateLastCounterValue,
                    OldCounterValue = e.OldCounterValue,
                    DateOldCounterValue = e.DateOldCounterValue,
                    ServiceName = e.ServiceName,
                    ServiceProvider = e.ServiceProvider,
                    ProviderId = e.ProviderId,
                    NextVerificationData = e.NextVerificationData,

                }))
                .ToList() ?? throw new Exception("ошибка выполнения запроса");

            return countersList;
        }


    }

    public class CounterDto
    {
        public int CounterId { get; set; }
        /// <summary>
        /// Номер счетчика
        /// </summary>
        public string CounterNumber { get; set; }

        /// <summary>
        /// Последние переданные показания
        /// </summary>
        public float LastCounterValue { get; set; }

        /// <summary>
        /// Дата и время передачи последних показаний счетчика
        /// </summary>
        public DateTime DateLastCounterValue { get; set; }

        /// <summary>
        /// Учтенные показания счетчика за предыдущий месяц
        /// </summary>
        public float OldCounterValue { get; set; }

        /// <summary>
        /// Дата и время передачи показаний счетчика в прошлом месяце
        /// </summary>
        public DateTime DateOldCounterValue { get; set; }



        /// <summary>
        /// Наименование услуги
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Наименование поставщика услуг
        /// </summary>
        public string ServiceProvider { get; set; }
        /// <summary>
        /// Идентификатор поставщика
        /// </summary>
        public int ProviderId { get; set; }
        /// <summary>
        /// Дата следующей поверки счетчика
        /// </summary>
        public string NextVerificationData { get; set; }
    }
}
