using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FuelManagementSystem.utils.CoustomModels;

namespace FuelManagementsystem.DataAccess
{
    public class ReportData
    {
        /// <summary>
        /// Return Sumaary Report of differnt airport's
        /// </summary>
        /// <returns></returns>
        public static List<AirportSummaryModel> GetSummaryReport()
        {
            List<AirportSummaryModel> summaryReport = new List<AirportSummaryModel>();

            using(var dbcontext = new AirportFuelManagementSystemEntities())
            {
                var allAirports = dbcontext.Airport.ToList();
                foreach(var airport in allAirports)
                {
                    AirportSummaryModel airportModel = new AirportSummaryModel();
                    airportModel.AirportName = airport.airportName;
                    airportModel.FuelAvailability = airport.fuelAvailability;

                    summaryReport.Add(airportModel);
                }
            }
            return summaryReport;
        }

        /// <summary>
        /// Takes starting, ending dates as parameter and return Fuel Report of differnt airport's
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<AirportFuelReportModel> GetFuelReport(string startDate, string endDate)
        {
            List<AirportFuelReportModel> fuelReport = new List<AirportFuelReportModel>();



            using(var dbcontext = new AirportFuelManagementSystemEntities())
            {
                var allTransaction = dbcontext.FuelTransaction.OrderBy(i=> i.airportId).ToList();
                foreach(var transaction in allTransaction)
                {
                    var date = transaction.transactionDataTime.Split(' ')[0];
                    var newdate = DateTime.Parse(date);
                    var newStartDate = DateTime.Parse(startDate);
                    var newendDate = DateTime.Parse(endDate);
                    if (newdate >= newStartDate && newdate <= newendDate)
                    {
                        AirportFuelReportModel newFuelReport = new AirportFuelReportModel();
                        Airport currentAirport = dbcontext.Airport.Where(i => i.airportId == transaction.airportId).FirstOrDefault();

                        newFuelReport.AirportId = transaction.airportId;
                        newFuelReport.AirportName = currentAirport.airportName;
                        newFuelReport.TransactionDate = transaction.transactionDataTime;
                        newFuelReport.Quantity = transaction.quantity;
                        newFuelReport.TransactionType = transaction.transactionType;
                        if (transaction.aircraftId != null)
                        {
                            newFuelReport.AircraftName = dbcontext.Aircraft.Where(i => i.aircraftId == transaction.aircraftId).Select(r => r.aircraftNo).FirstOrDefault();
                        }
                        newFuelReport.FuelAvailability = currentAirport.fuelAvailability;

                        fuelReport.Add(newFuelReport);
                    }
                   


                }

            }
            return fuelReport;
        }
    }
}
