using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using MOEIRCNet.API.ExceptionExtensions;
using MOEIRCNet.API.Responses.Counters;

namespace MOEIRCNet.Classes
{
    public class Counter
    {
        public Counter(CounterDto dto)
        {
            CounterId = dto.CounterId;
            CounterNumber = dto.CounterNumber;
            OldCounterValue = dto.OldCounterValue;
            DateOldCounterValue = dto.DateOldCounterValue;
            LastCounterValue = dto.LastCounterValue;
            DateLastCounterValue = dto.DateLastCounterValue;
            ServiceName = dto.ServiceName;
            ServiceProvider = dto.ServiceProvider;
            ProviderId = dto.ProviderId;
            NextVerificationData = dto.NextVerificationData;
        }


        public int CounterId { get; }
        /// <summary>
        /// Номер счетчика
        /// </summary>
        public string CounterNumber { get; }
        /// <summary>
        /// Учтенные показания счетчика за предыдущий месяц
        /// </summary>
        public float OldCounterValue { get; private set; }
        /// <summary>
        /// Дата и время передачи показаний счетчика в прошлом месяце
        /// </summary>
        public DateTime DateOldCounterValue { get; }
        /// <summary>
        /// Последние переданные показания
        /// </summary>
        public float LastCounterValue { get; set; }
        /// <summary>
        /// Дата и время передачи последних показаний счетчика
        /// </summary>
        public DateTime DateLastCounterValue { get; }
        /// <summary>
        /// Наименование услуги
        /// </summary>
        public string ServiceName { get; }
        /// <summary>
        /// Наименование поставщика услуг
        /// </summary>
        public string ServiceProvider { get; }
        /// <summary>
        /// Идентификатор поставщика
        /// </summary>
        public int ProviderId { get; }
        /// <summary>
        /// Дата следующей поверки счетчика
        /// </summary>
        public string NextVerificationData { get; }

        public float AddValue(float value)
        {
            if (value < OldCounterValue)
                throw new BadRequestException("Argument exception");
            if (DateTime.Now < DateLastCounterValue.AddDays(1))
                throw new Exception($"Следующая передача показаний через: {(DateLastCounterValue.AddDays(1) - DateTime.Now)}"); 

            var expenses = value - OldCounterValue; 
            OldCounterValue = value;
            return expenses;
        }

    }
}
