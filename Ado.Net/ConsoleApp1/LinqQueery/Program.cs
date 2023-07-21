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
                var users = dbContext.Address.Where(i => i.City == "Bothell").ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.AddressLine1);
                }
            }

            Console.ReadLine();
        }
    }
}
