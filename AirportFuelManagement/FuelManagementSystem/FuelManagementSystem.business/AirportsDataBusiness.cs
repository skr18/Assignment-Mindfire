using FuelManagementsystem.DataAccess;
using FuelManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagementSystem.business
{
    public class AirportsDataBusiness
    {
        /// <summary>
        /// Returns List of Airport's
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllAirports()
        {
            return AirportsData.GetAllAirports();
        }

        /// <summary>
        /// Takes AirportName as parameter and return List Of Aircraft's of that airport
        /// </summary>
        /// <param name="airportName"></param>
        /// <returns></returns>
        public static List<CoustomModels.AircraftModel> GetAllAircraft(string airportName)
        {
            return AirportsData.GetAllAircraft(airportName);
        }

        /// <summary>
        /// Insert New Airport into DataBase
        /// </summary>
        /// <param name="airportData"></param>
        public static void InsertNewAirport(CoustomModels.AirportModel airportData)
        {
            AirportsData.InsertNewAirport(airportData);
        }

        /// <summary>
        /// Insert New Aircraft into DataBase
        /// </summary>
        /// <param name="aircraftData"></param>
        public static void InsertNewAircraft(CoustomModels.AircraftModel aircraftData)
        {
            AirportsData.InsertNewAircraft(aircraftData);
        }


    }
   
}
