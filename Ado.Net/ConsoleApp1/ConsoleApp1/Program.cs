using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ConsoleApp1
{
    internal class Program
    { 
        static DataSet ds = new DataSet();
 
        static string connectionString = "server=127.0.0.1;uid=root;pwd=mindfire;database=practice";
        static void Main(string[] args)
        {

            //var mysqlConn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            /*using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                
                try
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT Id Firstname FROM user",con);
                    dataAdapter.UpdateCommand = new MySqlCommand("UPDATE user SET Age = @val " +"WHERE name = 'sujeet'", con);
                    dataAdapter.UpdateCommand.Parameters.Add("@val", MySqlDbType.Int32 , 15, "Age");
                    MySqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add("@CategoryID", MySqlDbType.Int32);
                   
                    parameter.SourceColumn = "CategoryID";
                    parameter.SourceVersion = DataRowVersion.Original;
                    dataAdapter.Fill(ds);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Console.WriteLine("Id - {0} Name - {1}", row[0], row[1]);
                    }
                    


                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong.\n" + e);
                }
                finally
                {
                    con.Close();
                }

            }*/


            using (var dbContext = new TestDBEntities())
            {
                var users = dbContext.UserDetails.Where(i => i.Age > 0).ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.FirstName);
                }
            }

            Console.ReadLine();

        }
        static void displayData(MySqlConnection con)
        {
            ds.Clear();
            var sde = new MySqlDataAdapter("select * from user; ", con);
            sde.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine("Id - {0} Name - {1} {2} Age- {3}", row[0], row[1], row[2], row[3]);
            }
            Console.WriteLine("\n\n");
        }
    }
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


//MySqlCommand cm = new MySqlCommand("insert into User(Firstname) values('aniket')", con);

//MySqlDataReader sdr = cm2.ExecuteReader(); 
/* while (sdr.Read())
 {
     Console.WriteLine("Name = {0} || Id - {1}", sdr[0], sdr[1]);  
 }*/
/*  ds.Clear();
sde.Fill(ds);
foreach (DataRow row in ds.Tables[0].Rows)
{
   Console.WriteLine("Id - {0} Name - {1}", row[0], row[1]);
}*/



/* con.Open();
MySqlCommand cm2 = new MySqlCommand("select * from user;",con);
 var sde = new MySqlDataAdapter("select * from user; ", con);
 sde.Fill(ds);
 foreach (DataRow row in ds.Tables[0].Rows)
 {

         Console.WriteLine("Id - {0} Name - {1}", row[0], row[1]);
 }


MySqlCommand cm = new MySqlCommand("update  user set Firstname='wasif12',Age=24 where Firstname='wasif';", con);
cm.ExecuteNonQuery();
MySqlDataReader sdr2 = cm2.ExecuteReader(); 

 Console.WriteLine("Data updated");

 while (sdr2.Read())
  {
      Console.WriteLine("Name = {0} || Id - {1}", sdr2[0], sdr2[1]);
  }*/

//stored procedure call;
/*con.Open();

using (MySqlCommand cmd = new MySqlCommand("getRoleName", con))
{
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("name", "sujeet");
    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
    {

        sda.Fill(ds);
        foreach (DataRow row in ds.Tables[0].Rows)
        {

            Console.WriteLine("Id - {0} Name - {1}", row[0], row[1]);
        }
    }
}*/



//user input data
/*bool login = true;
while (login)
{
    Console.WriteLine("Your choice's : ");
    Console.WriteLine("1> Show Data");
    Console.WriteLine("2> Insert Data");
    Console.WriteLine("3> Update Data");
    Console.WriteLine("4> Delete Data");
    Console.WriteLine("5> Exit");

    int ch = Convert.ToInt32(Console.ReadLine());

    switch (ch)
    {
        case 1:
            Console.WriteLine("Data :");
            displayData(con);
            break;
        case 2:
            Console.WriteLine("Enter data to insert:");

            Console.WriteLine("Id:");
            var id = Console.ReadLine();
            Console.WriteLine("FirstName:");
            var Fname = Console.ReadLine();
            Console.WriteLine("LastName:");
            var Lname = Console.ReadLine();
            Console.WriteLine("Age: ");
            var age = Console.ReadLine();

            MySqlCommand cmd = new MySqlCommand($"insert into user values({id},'{Fname}','{Lname}',{age})", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            break;
        case 5: return;

    }

}*/



//DataReader
/*
MySqlCommand cm = new MySqlCommand("select * from user", con);
Console.WriteLine("1st time");
con.Open();
MySqlDataReader sdr = cm.ExecuteReader();
while (sdr.Read())
{
    Console.WriteLine("Name = {0} || Id - {1}", sdr[0], sdr[1]);
}
con.Close();
con.Open();
*//*
sdr = cm.ExecuteReader();
Console.WriteLine("2nd time");
while (sdr.Read())
{
    Console.WriteLine("Name = {0} || Id - {1}", sdr[0], sdr[1]);
}*//*
Console.WriteLine("2nd time");

MySqlDataReader sdr2 = cm.ExecuteReader();
while (sdr2.Read())
{
    Console.WriteLine("Name = {0} || Id - {1}", sdr2[0], sdr2[1]);
}*/