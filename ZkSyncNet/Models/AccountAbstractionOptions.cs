using System;
using System.Collections.Generic;
using System.Text;

namespace ZkSyncNet.Models
{
    public class AccountAbstractionOptions
    {
        public string PaymasterAddress { get; set; }
        public bool EnableGaslessTransactions { get; set; }
        public Dictionary<string, object> CustomSettings { get; set; } = new Dictionary<string, object>();
    }
}
