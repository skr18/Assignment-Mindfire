using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagementSystem.utils
{
    public class CoustomModels
    {
        public class AircraftModel
        {
            public string AircraftName { get; set; }
            public string Airline { get; set; }
            public string Source { get; set; }
            public string Destination { get; set; }
        }
        public class AirportModel
        {
            public string AirplaneName { get; set; }
            public int FuelCapacity { get; set; }
        }

        public class TransactionModel
        {
            public string AircraftName { get; set; }
            public string AirportName { get; set; }
            public string TransactionType { get; set; }
            public int Quantity { get; set; }
        }

        public class AirportSummaryModel
        {
            public string AirportName { get; set; }
            public int FuelAvailability { get; set; }
        }

        public class AirportFuelReportModel
        {
            public string AirportName { get; set; }
            public int AirportId { get; set; }
           
            public string TransactionDate { get; set; }
            public string AircraftName { get; set; }
            
            public string TransactionType { get; set; }
            public int Quantity { get; set; }

            public int FuelAvailability { get; set; }
        }
    }
}
