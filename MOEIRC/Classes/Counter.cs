using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.Classes
{
    public class Counter
    {

        /// <summary>
        /// Номер счетчика
        /// </summary>
        public string CounterNumber { get; set; }
        /// <summary>
        /// Показания счетчика
        /// </summary>
        public float CounterValue { get; set; }
        /// <summary>
        /// дата последней передачи показаний
        /// </summary>
        public DateTime LastIndication { get; set; }
        /// <summary>
        /// Наименование услуги
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Наименование поставщика услуг
        /// </summary>
        public string ServiceProvider { get; set; }

        /// <summary>
        /// Дата следующей поверки счетчика
        /// </summary>
        public string NextVerificationData { get; set; }
    }
}
