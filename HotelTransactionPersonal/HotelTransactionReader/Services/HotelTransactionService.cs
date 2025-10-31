using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelTransactionReader.Data;
using HotelTransactionReader.Models;

namespace HotelTransactionReader.Services
{
    public class HotelTransactionService : IHotelTransactionService
    {
        private readonly IHotelTransactionRepository _repository;
        private readonly List<HotelTransactionLine> _transactions;

        public HotelTransactionService(IHotelTransactionRepository repository)
        {
            _repository = repository;
            _transactions = _repository.GetAllTransactions();
        }

        public int GetTotalTransactionCount() => _transactions.Count;

        public int GetZeroBookingCount() => _transactions.Count(t => t.Price == 0);

        public decimal GetAverageHotelPrice()
        {
            var validTransactions = _transactions.Where(t => t.Price != 0).ToList();
            return validTransactions.Any() ? validTransactions.Average(t => t.Price) : 0m;
        }

        public Dictionary<string, int> GetPopularCities(int topCount = 5)
        {
            return _transactions
                .GroupBy(t => t.CityName)
                .OrderByDescending(g => g.Count())
                .Take(topCount)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public int GetStayDurationInDays(HotelTransactionLine transaction)
        {
            return (transaction.CheckOutDate - transaction.CheckInDate).Days;
        }

        public decimal GetTotalRevenue()
        {
            return _transactions.Where(t => t.Price > 0).Sum(t => t.Price);
        }

        // Bisa ditambah method lain sesuai kebutuhan bisnis
        public int GetGuaranteedBookingCount()
        {
            return _transactions.Count(t => t.IsGuaranteed);
        }

        public Dictionary<string, int> GetPopularProviders(int topCount = 3)
        {
            return _transactions
                .GroupBy(t => t.Provider)
                .OrderByDescending(g => g.Count())
                .Take(topCount)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        public Dictionary<string, int> GetAllCities()
        {
            return _transactions
                .GroupBy(t => t.CityName)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        
        public Dictionary<string, int> GetAllProviders()
        {
            return _transactions
                .GroupBy(t => t.Provider)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}