using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Text;
using ZkSyncNet.Models;

namespace ZkSyncNet.Clients
{
    class ZkSyncAccountAbstractionClient
    {
        private readonly Web3 _web3;
        private readonly NetworkConfig _networkConfig;

        public ZkSyncAccountAbstractionClient(
            NetworkConfig networkConfig,
            string providerUrl = null)
        {
            _networkConfig = networkConfig;
            _web3 = new Web3(providerUrl ?? networkConfig.RpcUrl);
        }
    }
}
