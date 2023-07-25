
using Linq_Query_AdeventureWorks_;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueery
{
    public class Program
    {
        static void Main()
        {
            using(var testdbContext2 = new TestDBEntities1())
            {
               /* var user = testdbContext2.SelectAllCustomers(23);
                var user2 = testdbContext2.showDetails;
                foreach(var users in user2)
                {
                    Console.WriteLine("Id - {0} Name - {1}",users.UserId,users.FirstName);
                }*/
            }
           using (var dbContext = new AdventureWorks2022Entities())
            {
                //var users = dbContext.UserDetails.Where(i => i.Age > 0).ToList();
                try
                {
                    var str = dbContext.Employee.Distinct().OrderBy(r=> r.JobTitle).Select(r=> r.JobTitle);

                    var str2 = dbContext.SalesOrderHeader.GroupBy(r => r.CustomerID).
                         Select(obj => new { r = obj.Key, total = obj.Sum(r => r.Freight) }).OrderBy(k => k.r);



                    var str3 = from s in dbContext.SalesOrderHeader group s by s.Customer into g orderby g.Key select new { cid = g.Key, tot = g.Sum(r => r.Freight);


                    var str4 = dbContext.ProductInventory.GroupBy(r=>r.ProductID).Select(obj =>new { r = obj.Key , tot =  obj.Where(i=> i.Shelf=="A"|| i.Shelf=="C" || i.Shelf=="H").Sum(r=> r.Quantity)}).Where(i=> i.tot>=500).OrderBy(s => s.r);
                   /* var str = from s in dbContext.SalesOrderHeader orderby s.SubTotal
                              select new { s.SalesOrderID, s.CustomerID, s.OrderDate, s.SubTotal, tax = (s.SubTotal * 100) / 1000 };
                    foreach (var user in str)
                    {
                        Console.WriteLine("{0} , {1} , {2} , {3} , {4}", user.SalesOrderID, user.CustomerID, user.OrderDate,user.SubTotal,user.tax);
                    }*/
                    
                    /*var groupedResult = from s in dbContext.Employee
                                        group s by s.JobTitle;

                    //iterate each group        
                    foreach (var ageGroup in groupedResult)
                    {
                        Console.WriteLine("Age Group: {0}", ageGroup.Key);

                        foreach (var s in ageGroup) // Each group has inner collection
                            Console.WriteLine("Student Name: {0}", s.MaritalStatus);
                    }*/
                    /*var str = from s in dbContext.Person orderby s.FirstName , s.LastName , s.BusinessEntityID select s ;
                    
                    var item = dbContext.Person.Select(i => new { empId = i.BusinessEntityID,FirstName=i.FirstName,LastName=i.LastName}).OrderBy(i=>i.LastName);
                    foreach (var user in item)
                    {
                        Console.WriteLine("{0} , {1} , {2}",user.empId,user.FirstName,user.LastName);
                    }*/
                    // var str = dbContext.Person.OrderBy(r=>r.FirstName).
                    /*var str = dbContext.Employee.OrderBy(r => r.JobTitle);
                    foreach (var user in str)
                    {
                        Console.WriteLine(user.JobTitle);
                    }*/


                    /*var str = from s in dbContext.Address
                                where s.City == "Bothell"
                               select s;
                     //var str = dbContext.Address.Where(i => i.City == "Bothell").Select(r => r.City);
                     foreach (var user in str)
                     {
                         Console.WriteLine(user.city);
                     }*/

                    /*var str = from s in dbContext.Shift
                              where s.ShiftID <3
                              select s;
                    var str2 = dbContext.Shift.Where(i=> i.ShiftID <=3);
                    foreach (var user in str)
                    {
                        Console.WriteLine(user.Name);
                    }*/

                    /*   var salary = from sp in dbContext.EmployeePayHistory
                                    join emp in dbContext.Employee on sp.BusinessEntityID equals emp.BusinessEntityID
                                    where emp.BusinessEntityID == 1
                                    select sp.Rate;
                       foreach (var user in salary)
                       {
                           Console.WriteLine(user);
                       }*/



                    /*var str = from s in dbContext.Department
                               join st in dbContext.EmployeeDepartmentHistory
                               on s.DepartmentID equals st.DepartmentID
                               join emp in dbContext.Employee on st.BusinessEntityID equals emp.BusinessEntityID
                               where emp.BusinessEntityID == 1
                               select new
                               { // result selector 
                                   s = s,
                                   JobTitle = emp.JobTitle,
                                   salary = from sal in dbContext.EmployeePayHistory
                                            where sal.BusinessEntityID == 1 select sal.Rate

                               };
                   foreach (var user in str)
                   {
                       Console.WriteLine("DepartmentId = {0} DepartmentName = {1} JobTitle = {2}"
                           , user.s.DepartmentID, user.s.Name, user.salary);

                   }*/


                    /*  var str2 = dbContext.Department
                          .Join(dbContext.EmployeeDepartmentHistory,
                                  deptId => deptId.DepartmentID,
                                  empId => empId.DepartmentID, (deptId, empId) => new
                                  {
                                      busId = empId.BusinessEntityID,
                                      deptName = deptId.Name,
                                      deptId = deptId.DepartmentID,

                                  }).Join(dbContext.Employee,
                                          bId => bId.busId,
                                          eId => eId.BusinessEntityID,
                                          (bId, eId) => new { 
                                              deptName = bId.deptName,
                                              BussId = eId.BusinessEntityID,
                                              deptIds = bId.deptId,
                                              JobTitle = eId.JobTitle,
                                              sal =  dbContext.EmployeePayHistory.Where(i => i.BusinessEntityID == 1)
                                              .Select(r=> r.Rate).FirstOrDefault()

                                          }).Where(i=> i.BussId ==1);

                       foreach (var user in str)
                       {
                          Console.WriteLine("DepartmentId = {0} DepartmentName = {1} JobTitle = {2}",user.deptIds,user.deptName,user.sal);

                       }*/



                }
                catch (Exception ex)
                {
                    Console.WriteLine("some error - " + ex);
                }

            }
            //using(var testDbContext = new TestDBEntities())
            //{
                /*var user = testDbContext.UserDetails.Where(i => i.Age == 18).Select(r=>r.FirstName);
                foreach(var data in user)
                {
                    Console.WriteLine(data);
                }*/

                /* UserDetails obj = new UserDetails();
                 obj.FirstName = "Aniket";
                 obj.Age = 23;
                 //Adds an entity in a pending insert state to this System.Data.Linq.Table<TEntity>and parameter is the entity which to be added  
                 testDbContext.UserDetails.Add(obj);
                 testDbContext.SaveChanges();

                 var user = testDbContext.UserDetails.Where(i => i.Age >= 18).Select(r=>r.FirstName);
                foreach(var data in user)
                {
                    Console.WriteLine(data);
                }

                 obj.FirstName = "Ani";

                 testDbContext.UserDetails.AddOrUpdate(obj);
                 testDbContext.SaveChanges();*/

                /* var user2 = testDbContext.UserDetails.Where(i => i.Age == 18);

                 foreach (var data in user2)
                 {
                     data.FirstName = "suj";

                 }
                 testDbContext.SaveChanges();
                  user2 = testDbContext.UserDetails.Where(i => i.Age >= 18);

                 foreach (var data in user2)
                 {
                     Console.WriteLine(data.FirstName);

                 }*/

                /*var user2 = testDbContext.UserDetails.Where(i => i.FirstName == "Ani");
                foreach (var data in user2)
                {
                    testDbContext.UserDetails.Remove(data);

                }
                testDbContext.SaveChanges();
                user2 = testDbContext.UserDetails.Where(i => i.Age >= 18);

                foreach (var data in user2)
                {
                    Console.WriteLine(data.FirstName);

                }*/
                




            //}


            Console.ReadLine();
        }
    }
}
