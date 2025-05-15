using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using ZkSyncNet.Models;

namespace ZkSyncNet.Interfaces
{
    /// <summary>
    /// Primary interface for ZkSync RPC interactions
    /// </summary>
    public interface IZkSyncRpcClient
    {
        /// <summary>
        /// Get balance for a specific address
        /// </summary>
        Task<decimal> GetBalanceAsync(string address);

        /// <summary>
        /// Get transaction details by hash
        /// </summary>
        Task<TransactionDetails> GetTransactionAsync(string txHash);

        /// <summary>
        /// Send a raw signed transaction
        /// </summary>
        Task<string> SendRawTransactionAsync(string signedTx);

        /// <summary>
        /// Estimate transaction fee
        /// </summary>
        Task<FeeEstimation> EstimateFeeAsync(TransactionRequest request);

        /// <summary>
        /// Get L1 Batch details
        /// </summary>
        Task<L1BatchDetails> GetL1BatchDetailsAsync(long batchNumber);
    }

    public interface IPaymasterService
    {
        /// <summary>
        /// Get approved paymaster address
        /// </summary>
        Task<string> GetApprovedPaymasterAsync();

        /// <summary>
        /// Prepare a transaction with paymaster support
        /// </summary>
        Task<PaymasterTransactionRequest> PreparePaymasterTransactionAsync(
            TransactionRequest originalTx,
            PaymasterParams paymasterParams);
    }
}


    /// <summary>
    /// Transaction request model
    /// </summary>
    public class TransactionRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public BigInteger Value { get; set; }
        public string Data { get; set; }
        public BigInteger? GasLimit { get; set; }
        public BigInteger? GasPrice { get; set; }
    }

    /// <summary>
    /// Detailed transaction information
    /// </summary>
    public class TransactionDetails
    {
        public string Hash { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public BigInteger Value { get; set; }
        public string Input { get; set; }
        public string BlockHash { get; set; }
        public long BlockNumber { get; set; }
        public TransactionStatus Status { get; set; }
    }

    /// <summary>
    /// Transaction status enumeration
    /// </summary>
    public enum TransactionStatus
    {
        Pending,
        Successful,
        Failed
    }



    /// <summary>
    /// Bridge transaction options
    /// </summary>
    public class BridgeOptions
    {
        public bool AllowMessagePassing { get; set; }
        public string MessageData { get; set; }
        public BigInteger MaxRefundAmount { get; set; }
    }

    /// <summary>
    /// Paymaster transaction parameters
    /// </summary>
    public class PaymasterParams
    {
        public string PaymasterAddress { get; set; }
        public string PaymasterInput { get; set; }
        public BigInteger MaxGasPrice { get; set; }
    }

    /// <summary>
    /// Paymaster transaction request
    /// </summary>
    public class PaymasterTransactionRequest
    {
        public TransactionRequest OriginalTransaction { get; set; }
        public string PaymasterAddress { get; set; }
        public string PaymasterInput { get; set; }
        public BigInteger MaxGasPrice { get; set; }
    }

    /// <summary>
    /// Bridge contract addresses
    /// </summary>
    public class BridgeAddresses
    {
        public string L1SharedBridge { get; set; }
        public string L2SharedBridge { get; set; }
    }

    /// <summary>
    /// Fee estimation model
    /// </summary>
    public class FeeEstimation
    {
        public BigInteger GasLimit { get; set; }
        public BigInteger GasPrice { get; set; }
        public BigInteger TotalCost { get; set; }
    }

    /// <summary>
    /// L1 Batch details
    /// </summary>
    public class L1BatchDetails
    {
        public long BatchNumber { get; set; }
        public string BatchHash { get; set; }
        public DateTime Timestamp { get; set; }
        public long L1TxCount { get; set; }
        public long L2TxCount { get; set; }
    }
