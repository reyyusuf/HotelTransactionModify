using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using HotelTransactionReader.Models;
using System.Globalization;

namespace HotelTransactionReader.Data
{
    public class HotelTransactionRepository : IHotelTransactionRepository
    {
        private readonly string _filePath;

        public HotelTransactionRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<HotelTransactionLine> GetAllTransactions()
        {
            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<HotelTransactionLine>().ToList();
        }
    }
}
