using System;
using System.Globalization;

namespace ZkSyncNet.Utils
{
    public static class HexUtils
    {
        public static ulong FromHex(string hex)
        {
            if (string.IsNullOrEmpty(hex)) return 0;
            if (hex.StartsWith("0x")) hex = hex[2..];
            return ulong.TryParse(hex, NumberStyles.HexNumber, null, out var result) ? result : 0;
        }

        public static decimal FromHexToEth(string hex)
        {
            var wei = FromHex(hex);
            return wei / 1_000_000_000_000_000_000m; // 1 ETH = 10^18 Wei
        }

        public static string ToHex(ulong value)
        {
            return $"0x{value:x}";
        }
    }
}
