using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MOEIRCNet.API.Responses.Accounts
{
    public class AccountResponse
    {
        public string nn_ls { get; set; }
        public string nm_ls_group_full { get; set; }
        public string nm_type { get; set; }
        public string nm_provider { get; set; }
        public int kd_provider { get; set; }
        public string vl_provider { get; set; }
        public int id_service { get; set; }
        public string nm_ls_group { get; set; }
        //public Data data { get; set; }
        public bool pr_ls_group_edit { get; set; }
        public object nm_lock_msg { get; set; }
        public int kd_status { get; set; }
        public int kd_service_type { get; set; }
        public object nm_ls_description { get; set; }
    }
}
