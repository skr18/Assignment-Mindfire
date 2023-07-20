using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "server=127.0.0.1;uid=root;pwd=mindfire;database=practice";
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            //var mysqlConn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                var sde = new MySqlDataAdapter("insert into User(Firstname) values('aniket')", con);

                try
                {
                    // writing sql query  
                    MySqlCommand cm = new MySqlCommand("insert into User(Firstname) values('aniket')", con);
                    // Opening Connection  
                    con.Open();
                    // Executing the SQL query  
                    MySqlCommand cm2 = new MySqlCommand("select * from user", con);
                    MySqlDataReader sdr = cm2.ExecuteReader();
                    // Iterating Data  
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Firstname"]); // Displaying Record  
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong.\n" + e);
                }
                // Closing the connection  
                finally
                {
                    con.Close();
                }












                /* sde.Fill(ds);
                 Console.WriteLine("Using Data Set");
                 //IList<Address> studentList = new List<Address>();
                 foreach (DataRow row in ds.Tables[0].Rows)
                 {
                     //Accessing the data using string Key Name
                     if(row["City"].ToString() == "Bothell")
                     {
                          Console.WriteLine(row["City"]);
                         arr.Add(row["AddressLine1"]);
                     }
                 }*/
            }
            for(int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();

        }
    }
    public class Address
    {

        public int AddressID { get; set; }
        public string CityName { get; set; }
    }
}
