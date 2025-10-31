using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransactionReader.Presenters
{
    public interface IReportPresenter
    {
        void DisplayReport();
        void DisplayDetailedReport();
    }
}