using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueery
{
    class Program
    {
        static void Main()
        {
            using(var dbContext = new AdventureWorks2022Entities())
            {
                //var users = dbContext.UserDetails.Where(i => i.Age > 0).ToList();
                try
                {
                    var str = dbContext.Address.Where(i=>i.AddressID==1).ToList();
                    foreach (var user in str)
                    {
                        Console.WriteLine(user.StateProvinceID);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("some error - "+ex);
                }

            }

            Console.ReadLine();
        }
    }
}
