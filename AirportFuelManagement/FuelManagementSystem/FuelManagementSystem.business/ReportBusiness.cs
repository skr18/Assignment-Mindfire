using FuelManagementsystem.DataAccess;
using FuelManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FuelManagementSystem.utils.CoustomModels;

namespace FuelManagementSystem.business
{
    public class ReportBusiness
    {
        /// <summary>
        /// Return Sumaary Report of differnt airport's
        /// </summary>
        /// <returns></returns>
        public static List<AirportSummaryModel> GetSummaryReport()
        {
           return ReportData.GetSummaryReport();
        }
        /// <summary>
        /// Takes starting, ending dates as parameter and return Fuel Report of differnt airport's
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<AirportFuelReportModel> GetFuelReport(string startDate, string endDate)
        {
           return ReportData.GetFuelReport(startDate,endDate);
        }
    }
}
