using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZkSyncNet.Models;

namespace ZkSyncNet.Interfaces
{
    public interface IAccountAbstractionService
    {
        /// <summary>
        /// Deploy a smart contract wallet
        /// </summary>
        Task<string> DeploySmartContractWalletAsync(
            string ownerAddress,
            AccountAbstractionOptions options);

        /// <summary>
        /// Execute a gasless transaction
        /// </summary>
        Task<string> ExecuteGaslessTransactionAsync(
            string smartWalletAddress,
            string targetContract,
            string methodSignature,
            object[] parameters);
    }
