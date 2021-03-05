using System;
using System.Globalization;

namespace ProfitDistribution.Api.App.Adapters
{
    public static class MoneyAdapter
    {
        public static string FormatToReal(long money)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Convert.ToDouble(money) / 100);
        }
    }
}
