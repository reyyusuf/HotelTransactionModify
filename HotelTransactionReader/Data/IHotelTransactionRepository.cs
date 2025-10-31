using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelTransactionReader.Models;

namespace HotelTransactionReader.Data
{
    public interface IHotelTransactionRepository
    {
        List<HotelTransactionLine> GetAllTransactions();
    }
}
