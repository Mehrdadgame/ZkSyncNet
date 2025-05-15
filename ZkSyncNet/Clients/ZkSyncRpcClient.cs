using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Numerics;
using ZkSyncNet.Interfaces;
using ZkSyncNet.Models;
using ZkSyncNet.Utils;

namespace ZkSyncNet.Clients
{
    public class ZkSyncRpcClient : IZkSyncRpcClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _rpcUrl;

        public ZkSyncRpcClient(string rpcUrl)
        {
            _rpcUrl = rpcUrl;
            _httpClient = new HttpClient();
        }

        public async Task<decimal> GetBalanceAsync(string address)
        {
            var result = await SendRpcAsync("eth_getBalance", new[] { address, "latest" });
            return Convert.ToUInt64(result.GetString(), 16) / 1e18m;
        }

        public async Task<TransactionDetails> GetTransactionAsync(string txHash)
        {
            var result = await SendRpcAsync("eth_getTransactionByHash", new[] { txHash });
            var txJson = result.GetRawText();
            var tx = JsonSerializer.Deserialize<Transaction>(txJson);

            return new TransactionDetails
            {
                Hash = tx.Hash,
                From = tx.From,
                To = tx.To,
                Value = HexUtils.FromHex(tx.ValueHex),
                Input = tx.Input,
                BlockHash = tx.BlockHash,
                BlockNumber = long.Parse(tx.BlockNumber?.Replace("0x", "") ?? "0", System.Globalization.NumberStyles.HexNumber),
                Status = DetermineTransactionStatus(tx)
            };
        }

        private TransactionStatus DetermineTransactionStatus(Transaction tx)
        {
            // This is a simplified status determination
            // In a real-world scenario, you'd need to check the transaction receipt
            if (string.IsNullOrEmpty(tx.BlockHash))
                return TransactionStatus.Pending;

            // Assuming success if block hash exists
            return TransactionStatus.Successful;
        }

        public async Task<string> SendRawTransactionAsync(string signedTx)
        {
            var result = await SendRpcAsync("eth_sendRawTransaction", new[] { signedTx });
            return result.GetString();
        }

        public async Task<FeeEstimation> EstimateFeeAsync(TransactionRequest request)
        {
            // Implement fee estimation logic
            throw new NotImplementedException("Fee estimation not yet implemented");
        }

        public async Task<L1BatchDetails> GetL1BatchDetailsAsync(long batchNumber)
        {
            // Implement L1 batch details retrieval
            throw new NotImplementedException("L1 batch details retrieval not yet implemented");
        }

        private async Task<JsonElement> SendRpcAsync(string method, object[] parameters)
        {
            var payload = new
            {
                jsonrpc = "2.0",
                method,
                @params = parameters,
                id = 1
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_rpcUrl, content);
            var json = await response.Content.ReadAsStringAsync();

            var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("error", out var err))
                throw new Exception($"RPC Error: {err}");

            return doc.RootElement.GetProperty("result");
        }
    }
}