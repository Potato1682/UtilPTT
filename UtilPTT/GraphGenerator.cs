using System;
using System.Text;

namespace UtilPTT
{
    public static class GraphGenerator
    {
        private static uint CalcGraph(int n, int max)
        {
            var tendNum = 10.0 / max;

            var meta = tendNum * n;

            return Convert.ToUInt32(meta);
        }

        public static string GenGraph(int n, int max, string meterChar, string lowChar, string mediumChar, string highChar)
        {
            var gen = CalcGraph(n, max);

            var builder = new StringBuilder("[");

            for (var i = 1; i < 11; i++)
            {
                if (n >= max && i == 10)
                    builder.Append(meterChar).Append("|");
                else if (n == 0 && i == 1)
                    builder.Append(meterChar).Append("|");
                if (i == gen)
                    builder.Append(meterChar).Append("|");
                else if (i < 5)
                    builder.Append(lowChar).Append("=");
                else if (i < 8)
                    builder.Append(mediumChar).Append("=");
                else
                    builder.Append(highChar).Append("=");
            }

            builder.Append(meterChar).Append("]");
            return builder.ToString();
        }
    }
}
