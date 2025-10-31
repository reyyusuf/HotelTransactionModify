using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelTransactionReader.Helpers;
using HotelTransactionReader.Services;

namespace HotelTransactionReader.Presenters
{
    public class ConsoleReportPresenter : IReportPresenter
    {
        private readonly IHotelTransactionService _service;

        public ConsoleReportPresenter(IHotelTransactionService service)
        {
            _service = service;
        }

        public void DisplayReport()
        {
            Console.WriteLine("=== HOTEL TRANSACTION SUMMARY REPORT ===\n");

            var totalTransaction = _service.GetTotalTransactionCount();
            var zeroBookingCount = _service.GetZeroBookingCount();
            var averagePrice = _service.GetAverageHotelPrice();
            var totalRevenue = _service.GetTotalRevenue();
            var popularCities = _service.GetPopularCities();
            var popularProviders = _service.GetPopularProviders();
            var guaranteedCount = _service.GetGuaranteedBookingCount();

            Console.WriteLine($"Total Transactions: {totalTransaction} bookings");
            Console.WriteLine($"Zero Price Bookings: {zeroBookingCount} bookings");
            Console.WriteLine($"Guaranteed Bookings: {guaranteedCount} bookings");
            Console.WriteLine($"Average Hotel Price: {CurrencyFormatter.FormatToRupiah(averagePrice)}");
            Console.WriteLine($"Total Revenue: {CurrencyFormatter.FormatToRupiah(totalRevenue)}");

            DisplayPopularCities(popularCities);
            DisplayPopularProviders(popularProviders);
        }

        public void DisplayDetailedReport()
        {
            DisplayReport();
            // Bisa ditambah detail lainnya
        }

        private void DisplayPopularCities(Dictionary<string, int> popularCities)
        {
            Console.WriteLine("\nTOP 10 POPULAR CITIES:");
            int rank = 1;
            foreach (var city in popularCities)
            {
                Console.WriteLine($"  {rank}. {city.Key}: {city.Value} bookings");
                rank++;
            }
        }

        private void DisplayPopularProviders(Dictionary<string, int> popularProviders)
        {
            Console.WriteLine("\nTOP 5 POPULAR PROVIDERS:");
            int rank = 1;
            foreach (var provider in popularProviders)
            {
                Console.WriteLine($"  {rank}. {provider.Key}: {provider.Value} bookings");
                rank++;
            }
        }
    }
}