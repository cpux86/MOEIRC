using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.API.Responses.Counters
{
    public class CounterResponse
    {
        public int id_counter { get; set; }
        public int id_pu { get; set; }
        /// <summary>
        /// Номер счетчика
        /// </summary>
        [JsonProperty("nm_counter")]
        public string CounterNumber { get; set; }
        //public object id_indication { get; set; }

        /// <summary>
        /// Показания счетчика
        /// </summary>
        [JsonProperty("vl_indication")]
        public float CounterValue { get; private set; }

        /// <summary>
        /// Дата и время передачи показаний счетчика 
        /// </summary>
        [JsonProperty("dt_indication")]
        public DateTime DateTimeIndication { get; set; }

        public string id_counter_zn { get; set; }

        /// <summary>
        /// Заводской номер счетчика
        /// </summary>
        [JsonProperty("nm_factory")]
        public string FactoryNumber { get; set; }

        public int id_service { get; set; }

        /// <summary>
        /// Наименование услуги
        /// </summary>
        [JsonProperty("nm_service")]
        public string ServiceName { get; set; }

        //[JsonProperty("nn_pu")]
        //public int ServiceProvider { get; set; }

        /// <summary>
        /// Наименование поставщика услуг
        /// </summary>
        [JsonProperty("nm_pu")]
        public string ServiceProvider { get; set; }

        public string nm_measure_unit { get; set; }
        /// <summary>
        /// Последние показания счетчика
        /// </summary>
        [JsonProperty("vl_last_indication")]
        public float LastCounterValue { get; set; }

        /// <summary>
        /// дата последней передачи показаний
        /// </summary>
        [JsonProperty("dt_last_indication")]
        public DateTime LastIndication { get; set; }

        public int nn_ind_receive_start { get; set; }
        public int nn_ind_receive_end { get; set; }
        //public long id_billing_counter { get; set; }
        public float vl_sh_znk { get; set; }
        //public object nm_no_access_reason { get; set; }

        /// <summary>
        /// Дата следующей поверки счетчика
        /// </summary>
        [JsonProperty("dt_mpi")]
        public string NextVerificationData { get; set; }

        //public object vl_tarif { get; set; }
        //public int pr_state { get; set; }
        //public int pr_remotely { get; set; }
    }
}
