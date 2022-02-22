using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace USPS
{
    public class DB
    {
        string connectionstring;
        static string userPass;
        static string userID;
        public DB()
        {

        }
        public void DBLogin(string pass, string user)
        {
            var conn = new SqlConnection();

            userPass = pass; // these take input from relevant fields
            userID = user;

            //builder class allows to use variables for user and password fields (get user input)
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost\\SQLExpress";
            builder.InitialCatalog = "Northwind"; //Whatever Database, used one from a previous course for testing
            builder.TrustServerCertificate = true;
            builder.Password = pass;
            builder.UserID = user;
            connectionstring = builder.ConnectionString;

            conn.ConnectionString = connectionstring;
            try
            {
                //open session
                conn.Open();
                Form1.errorBox("Successfully connected!");
                Form1.customerPanelSwitch = true;
            }
            catch (Exception ex)
            {
                Form1.errorBox("Login failed.");
                Console.WriteLine(ex.Message);
            }
            
        }

        public string getCustomerNames()
        {
            string names = "";
            SqlDataReader dataReader;

            SqlConnection cnn = new SqlConnection(connectionstring);
            cnn.Open();

            string countQuery = "SELECT SUBSTRING(ContactName, CHARINDEX(' ', ContactName) + 1, LEN(ContactName) - CHARINDEX(' ', ContactName)) AS LastName from dbo.Customers;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);
            try
            {
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    try
                    {
                        names = names + dataReader.GetValue(0) + "\n";
                    }
                    catch (Exception ex)
                    {
                        Form1.errorBox("Error with query.");
                        Console.WriteLine(ex.Message);
                    }
                }
                //return names;
            }
            catch (Exception ex)
            {
                Form1.errorBox(ex.Message);
            }
            return names;
        }
    }
}
