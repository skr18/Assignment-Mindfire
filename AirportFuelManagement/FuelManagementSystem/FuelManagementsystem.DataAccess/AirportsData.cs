using FuelManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagementsystem.DataAccess
{
    public class AirportsData
    {
        /// <summary>
        /// Returns List of Airport's
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllAirports()
        {
            List<string> allAirports = new List<string>();

            
            using(var dbcontext = new AirportFuelManagementSystemEntities())
            {
                var airports = dbcontext.Airport;
                if(airports != null)
                {

                    foreach(var airport in airports)
                    {
                        allAirports.Add(airport.airportName);
                    }
                }
                else
                {
                    return null;
                }
            }
            return allAirports;

        }

        /// <summary>
        /// Takes AirportName as parameter and return List Of Aircraft's of that airport
        /// </summary>
        /// <param name="airportName"></param>
        /// <returns></returns>
        public static List<CoustomModels.AircraftModel> GetAllAircraft(string airportName)
        {
            List<CoustomModels.AircraftModel> AllAircraft = new List<CoustomModels.AircraftModel>();
            using (var dbcontext = new AirportFuelManagementSystemEntities())
            {
                var aircrafts = dbcontext.Aircraft.Where(i=> i.source==airportName || i.destination==airportName).ToList();
                if(aircrafts != null)
                {

                    foreach (var aircraft in aircrafts)
                    {
                        CoustomModels.AircraftModel newAircraft = new CoustomModels.AircraftModel();
                        newAircraft.Airline = aircraft.airline;
                        newAircraft.Source = aircraft.source;
                        newAircraft.Destination = aircraft.destination;
                        newAircraft.AircraftName = aircraft.aircraftNo;

                        AllAircraft.Add(newAircraft);
                    }
                }
                else
                {
                    return null;
                }
            }
            return AllAircraft;
        }

        /// <summary>
        /// Insert New Airport into DataBase
        /// </summary>
        /// <param name="airportData"></param>
        public static void InsertNewAirport(CoustomModels.AirportModel airportData)
        {
            using (var dbcontext = new AirportFuelManagementSystemEntities())
            {
                Airport newAirport = new Airport();
                newAirport.airportName = airportData.AirplaneName;
                newAirport.fuelCapacity = airportData.FuelCapacity;
                newAirport.fuelAvailability = airportData.FuelCapacity;

                dbcontext.Airport.Add(newAirport);
                dbcontext.SaveChanges();
            }
        }

        /// <summary>
        /// Insert New Aircraft into DataBase
        /// </summary>
        /// <param name="aircraftData"></param>
        public static void InsertNewAircraft(CoustomModels.AircraftModel aircraftData)
        {
            using (var dbcontext = new AirportFuelManagementSystemEntities())
            {
                Aircraft newAircraft = new Aircraft();
                newAircraft.aircraftNo = aircraftData.AircraftName;
                newAircraft.airline = aircraftData.Airline;
                newAircraft.source = aircraftData.Source;
                newAircraft.destination = aircraftData.Destination;

                dbcontext.Aircraft.Add(newAircraft);
                dbcontext.SaveChanges();
            }
        }
    }
   
}
