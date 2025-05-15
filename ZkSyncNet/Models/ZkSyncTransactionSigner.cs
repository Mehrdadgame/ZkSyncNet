using System.Numerics;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts.TransactionHandlers;

public static class ZkSyncRawTxSigner
{
    public static string SignLegacyTransaction(
        string privateKey,
        string to,
        BigInteger value,
        BigInteger nonce,
        BigInteger gasPrice,
        BigInteger gasLimit,
        BigInteger chainId,
        string data = "")
    {
        var signer = new Nethereum.Signer.LegacyTransactionSigner();
        if (!string.IsNullOrEmpty(data) && !data.StartsWith("0x"))
        {
            data = "0x" + data;
        }

        var signedTx = signer.SignTransaction(
            privateKey,
            chainId,
            to,
            value,
            nonce,
            gasPrice,
            gasLimit,
             data

        );
        return signedTx;
    }
}
