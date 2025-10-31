using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransactionReader.Helpers
{
    public static class DateHelper
    {
        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd-MM-yyyy");
        }

        public static string FormatDateRange(DateTime startDate, DateTime endDate)
        {
            return $"{FormatDate(startDate)} to {FormatDate(endDate)}";
        }
    }
}