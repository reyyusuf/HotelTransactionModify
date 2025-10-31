using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelTransactionReader.Models;

namespace HotelTransactionReader.Services
{
    public interface IHotelTransactionService
    {
        int GetTotalTransactionCount();
        int GetZeroBookingCount();
        decimal GetAverageHotelPrice();
        Dictionary<string, int> GetPopularCities(int topCount = 10);
        int GetStayDurationInDays(HotelTransactionLine transaction);
        decimal GetTotalRevenue();
        int GetGuaranteedBookingCount();
        Dictionary<string, int> GetPopularProviders(int topCount = 5);
        Dictionary<string, int> GetAllCities();
        Dictionary<string, int> GetAllProviders();
    }
}
