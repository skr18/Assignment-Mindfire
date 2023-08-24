using FuelManagementsystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagementSystem.business
{
    public class ApplicationDataInitializeBusiness
    {

        /// <summary>
        /// Initialize the database with default data of airport and aircraft and clear all transaction records
        /// </summary>
       public static void InitializeData()
        {
           ApplicationDataInitialize.InitializeData();
        }

    }
}
