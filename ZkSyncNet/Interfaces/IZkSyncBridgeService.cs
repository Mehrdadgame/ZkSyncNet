using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZkSyncNet.Models;

namespace ZkSyncNet.Interfaces
{
    public interface IZkSyncBridgeService
    {
        /// <summary>
        /// Deposit tokens from L1 to L2
        /// </summary>
        Task<string> DepositAsync(
            string l1Token,
            string l2Recipient,
            BigInteger amount,
            BridgeOptions options = null);

        /// <summary>
        /// Withdraw tokens from L2 to L1
        /// </summary>
        Task<string> WithdrawAsync(
            string l2Token,
            string l1Recipient,
            BigInteger amount,
            BridgeOptions options = null);

        /// <summary>
        /// Get bridge contract addresses
        /// </summary>
        Task<BridgeAddresses> GetBridgeContractsAsync();
    }
}
