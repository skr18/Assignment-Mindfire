using FuelManagementsystem.DataAccess;
using FuelManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagementSystem.business
{
    public class TransactionBusiness
    {

        /// <summary>
        /// Return true and Insert valid transaction into database Or Return false for invalid transaction 
        /// </summary>
        /// <param name="transactionDatas"></param>
        /// <returns></returns>
        public static bool Transaction(CoustomModels.TransactionModel transactionDatas)
        {
            return TransactionData.Transaction(transactionDatas);
        }

        /// <summary>
        /// Takes airportName as a parameter and return fuelCapacity of the current Airport
        /// </summary>
        /// <param name="airportName"></param>
        /// <returns></returns>
        public static int GetFuelCapacity(string airportName)
        {
            return TransactionData.GetFuelCapacity(airportName);
        }
    }
}
