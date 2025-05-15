using System;
using System.Text.Json.Serialization;
using ZkSyncNet.Utils;

namespace ZkSyncNet.Models
{
    public class Transaction
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("nonce")]
        public string NonceHex { get; set; }

        [JsonPropertyName("blockHash")]
        public string BlockHash { get; set; }

        [JsonPropertyName("blockNumber")]
        public string BlockNumber { get; set; }

        [JsonPropertyName("transactionIndex")]
        public string TransactionIndex { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("value")]
        public string ValueHex { get; set; }

        [JsonPropertyName("gas")]
        public string GasHex { get; set; }

        [JsonPropertyName("gasPrice")]
        public string GasPriceHex { get; set; }

        [JsonPropertyName("input")]
        public string Input { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("chainId")]
        public string ChainId { get; set; }

        [JsonPropertyName("v")]
        public string V { get; set; }

        [JsonPropertyName("r")]
        public string R { get; set; }

        [JsonPropertyName("s")]
        public string S { get; set; }

        // Computed properties
        public ulong Nonce => HexUtils.FromHex(NonceHex);
        public ulong Gas => HexUtils.FromHex(GasHex);
        public ulong GasPrice => HexUtils.FromHex(GasPriceHex);
        public decimal ValueInEth => HexUtils.FromHexToEth(ValueHex);
    }
}
