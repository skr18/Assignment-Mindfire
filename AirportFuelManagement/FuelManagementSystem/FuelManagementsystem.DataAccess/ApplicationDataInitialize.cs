using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagementsystem.DataAccess
{
    public class ApplicationDataInitialize
    {

        /// <summary>
        /// Initialize the database with default data of airport and aircraft and clear all transaction records
        /// </summary>
        public static void  InitializeData()
       {
            using(var dbcontext = new AirportFuelManagementSystemEntities())
            {
                
                dbcontext.Database.ExecuteSqlCommand("ALTER TABLE  FuelTransaction DROP CONSTRAINT FK_Airport;");
                dbcontext.Database.ExecuteSqlCommand("ALTER TABLE  FuelTransaction DROP CONSTRAINT FK_Aircraft;");

                dbcontext.Database.ExecuteSqlCommand("TRUNCATE TABLE Airport");
                dbcontext.Database.ExecuteSqlCommand("TRUNCATE TABLE Aircraft");

                
                dbcontext.Database.ExecuteSqlCommand("TRUNCATE TABLE FuelTransaction");

                dbcontext.Database.ExecuteSqlCommand("alter table FuelTransaction  ADD  CONSTRAINT FK_Airport FOREIGN KEY (airportId) references Airport(airportId)");
                dbcontext.Database.ExecuteSqlCommand("alter table FuelTransaction  ADD  CONSTRAINT FK_Aircraft FOREIGN KEY (aircraftId) references Aircraft(aircraftId)");

                List<Airport> airports = new List<Airport>();
                airports.Add( new Airport() { airportName = "Indira Gandhi International Airport ,Delhi", fuelAvailability = 18066, fuelCapacity= 25066 }); 
                airports.Add( new Airport() { airportName = "Rajiv Gandhi International Airport ,Hyderabad", fuelAvailability = 270732,fuelCapacity=350732 }); 
                airports.Add( new Airport() { airportName = "Chhatrapati Shivaji International Airport ,Mumbai", fuelAvailability = 218467,fuelCapacity = 288467 }); 
                airports.Add( new Airport() { airportName = "Chennai International Airport ,Chennai", fuelAvailability = 377460, fuelCapacity = 497460 }); 
                airports.Add( new Airport() { airportName = "Kempegowda International Airport ,Bangalore", fuelAvailability = 93456 , fuelCapacity = 123456 }); 
                
                foreach (var airport in airports)
                {
                    dbcontext.Airport.Add(airport);
                }

                List<Aircraft> aircrafts = new List<Aircraft>();
                aircrafts.Add(new Aircraft() { aircraftNo="DH647", source="Delhi" , destination= "Hyderabad", airline= "IndiGo" });
                aircrafts.Add(new Aircraft() { aircraftNo="HM777", source= "Hyderabad", destination= "Mumbai", airline= "Go Air" });
                aircrafts.Add(new Aircraft() { aircraftNo="MC747", source= "Mumbai", destination= "Chennai", airline= "Spice Jet" });
                aircrafts.Add(new Aircraft() { aircraftNo="CB147", source= "Chennai", destination= "Bangalore", airline= "Air India" });
                aircrafts.Add(new Aircraft() { aircraftNo="BH829", source= "Bangalore", destination= "Hyderabad", airline= "kingfisher" });
                foreach (var aircraft in aircrafts)
                {
                    dbcontext.Aircraft.Add(aircraft);
                }
                dbcontext.SaveChanges();
            }
       }
    }
}
