using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Configuration for ZkSync Era network environments
/// </summary>
namespace ZkSyncNet.Models
{
  public  class NetworkConfig
    {

        public const long MainnetChainId = 324;
        public const long TestnetChainId = 280;

        public static NetworkConfig Mainnet => new NetworkConfig
        {
            ChainId = MainnetChainId,
            RpcUrl = "https://mainnet.era.zksync.io",
            ExplorerUrl = "https://explorer.zksync.io"
        };

        public static NetworkConfig Testnet => new NetworkConfig
        {
            ChainId = TestnetChainId,
            RpcUrl = "https://testnet.era.zksync.dev",
            ExplorerUrl = "https://goerli.explorer.zksync.io"
        };

        public long ChainId { get; set; }
        public string RpcUrl { get; set; }
        public string ExplorerUrl { get; set; }
    }
}
