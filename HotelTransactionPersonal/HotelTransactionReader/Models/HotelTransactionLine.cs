using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransactionReader.Models
{
	public class HotelTransactionLine
	{
		public int Id { get; set; }
        public string HotelName { get; set; }
        public string Provider { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsGuaranteed { get; set; }
        public decimal Price { get; set; }
	}
}
