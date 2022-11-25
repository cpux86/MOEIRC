using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.API.Responses
{
    //public class GetAccountsResponse
    //{
    //}



    public class GetAccountsResponse
    {
        public bool success { get; set; }
        public int total { get; set; }
        public Datum[] data { get; set; }
        public Metadata metaData { get; set; }
    }

    //public class Metadata
    //{
    //    public float responseTime { get; set; }
    //}

    public class Datum
    {
        public string nn_ls { get; set; }
        public string nm_ls_group_full { get; set; }
        public string nm_type { get; set; }
        public string nm_provider { get; set; }
        public int kd_provider { get; set; }
        public string vl_provider { get; set; }
        public int id_service { get; set; }
        public string nm_ls_group { get; set; }
        public Data data { get; set; }
        public bool pr_ls_group_edit { get; set; }
        public object nm_lock_msg { get; set; }
        public int kd_status { get; set; }
        public int kd_service_type { get; set; }
        public object nm_ls_description { get; set; }
    }

    public class Data
    {
        public int id_tu { get; set; }
        public string NN_SNILS { get; set; }
        public string nm_street { get; set; }
        public string nn_ls_disp { get; set; }
        public int KD_LS_OWNER_TYPE { get; set; }
        public int kd_reg { get; set; }
    }


}
