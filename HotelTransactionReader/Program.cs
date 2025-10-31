using System.Globalization;
using CsvHelper;
using HotelTransactionReader.Models;
using HotelTransactionReader.Data;
using HotelTransactionReader.Presenters;
using HotelTransactionReader.Services;

namespace HotelTransactionReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Setup dependencies
                var filePath = @"Data\hotel_transaction.csv";
                var repository = new HotelTransactionRepository(filePath);
                var service = new HotelTransactionService(repository);
                var presenter = new ConsoleReportPresenter(service);

                // Display report
                presenter.DisplayReport();

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Please make sure the data file exists in the Data.");
            }
        }
    }
}