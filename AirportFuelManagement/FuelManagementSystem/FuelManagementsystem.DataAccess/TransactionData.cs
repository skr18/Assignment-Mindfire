using FuelManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagementsystem.DataAccess
{
    public class TransactionData
    {

        /// <summary>
        ///  Return true and Insert valid transaction into database Or Return false for invalid transaction 
        /// </summary>
        /// <param name="transactionDatas"></param>
        /// <returns></returns>
        public static bool Transaction(CoustomModels.TransactionModel transactionDatas)
        {
            using (var dbcontext = new AirportFuelManagementSystemEntities())
            {
                Airport currentAirport = dbcontext.Airport.Where(i => i.airportName == transactionDatas.AirportName).FirstOrDefault();
                
                FuelTransaction newtransaction = new FuelTransaction();
                newtransaction.transactionDataTime = DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
                newtransaction.airportId = currentAirport.airportId;
                newtransaction.transactionType = transactionDatas.TransactionType;
                newtransaction.quantity = transactionDatas.Quantity;


                if (transactionDatas.AircraftName != "")
                {
                    newtransaction.aircraftId = dbcontext.Aircraft.Where(i => i.aircraftNo == transactionDatas.AircraftName).Select(r => r.aircraftId).FirstOrDefault();
                }


                if (transactionDatas.TransactionType == "In")
                {
                    currentAirport.fuelAvailability += transactionDatas.Quantity;
                }
                else
                {
                    if (currentAirport != null)
                    {
                        if(currentAirport.fuelAvailability - transactionDatas.Quantity >=0)
                        {
                            currentAirport.fuelAvailability -= transactionDatas.Quantity;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
                dbcontext.FuelTransaction.Add(newtransaction);
                dbcontext.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Takes airportName as a parameter and return fuelCapacity of the current Airport
        /// </summary>
        /// <param name="airportName"></param>
        /// <returns></returns>
        public static int GetFuelCapacity(string airportName)
        {
            int capacity;
            using (var dbcontext = new AirportFuelManagementSystemEntities())
            {
                capacity = dbcontext.Airport.Where(i=>i.airportName == airportName).Select(r=> r.fuelCapacity - r.fuelAvailability ).FirstOrDefault();
            }
            return capacity;
        }
    }
}
