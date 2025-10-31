using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransactionReader.Helpers
{
    public static class CurrencyFormatter
    {
        public static string FormatToRupiah(decimal amount)
        {
            decimal roundedNumber = Math.Floor(amount);
            return $"IDR {roundedNumber:N0}";
        }

        public static string FormatToRupiahWithDecimal(decimal amount)
        {
            return $"IDR {amount:N2}";
        }
    }
}