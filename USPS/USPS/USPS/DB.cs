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
        static string dbID;
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
            builder.InitialCatalog = "IT488_USPS";
            builder.TrustServerCertificate = true;
            builder.Password = pass;
            builder.UserID = user;
            connectionstring = builder.ConnectionString;

            conn.ConnectionString = connectionstring;
            try
            {
                //open session
                conn.Open();
                Form1.failed = false;
                Form1.errorBox("Successfully connected!");

            }
            catch (Exception ex)
            {
                Form1.failed = true;
                Form1.errorBox("Login failed.");
                Console.WriteLine(ex.Message);
            }

        }

        public void logOut()
        {
            Form1.errorBox("Successfully logged out.");
            Form1.customerPanelSwitch = false;
            Form1.pharmPanelSwitch = false;
        }

        public void infoUpdater(Dictionary<string, string> info)
        {
            SqlConnection cnn = new SqlConnection(connectionstring);
            cnn.Open();

            string infoQuery = $"UPDATE Customers_List SET Customer_FirstName = '{info["fname"]}', " +
                $"Customer_LastName = '{info["lname"]}', Customer_DateOfBirth = '{info["dob"]}', " +
                $"Customer_Address = '{info["address"]}', Customer_City = '{info["city"]}', " +
                $"Customer_State = '{info["state"]}', Customer_ZipCode = '{info["zip"]}', " +
                $"Customer_DrugAllergy = '{info["allergy"]}' WHERE Customer_ID = '{dbID}'";

            SqlCommand cmd = new SqlCommand(infoQuery, cnn);
            cmd.BeginExecuteNonQuery();
        }
        
        public Dictionary<string, string> infoUpdateQuery()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("ID", "");
            info.Add("fname", "");
            info.Add("lname", "");
            info.Add("dob", "");
            info.Add("phone", "");
            info.Add("email", "");
            info.Add("address", "");
            info.Add("city", "");
            info.Add("state", "");
            info.Add("zip", "");
            info.Add("allergy", "");

            SqlDataReader dataReader;

            SqlConnection cnn = new SqlConnection(connectionstring);
            try
            {
                cnn.Open();

                string infoQuery = $"SELECT * FROM Customers_List WHERE Customer_UserName = '{userID}'";
                SqlCommand cmd = new SqlCommand(infoQuery, cnn);
                try
                {
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        try
                        {
                            info["ID"] = dataReader[0].ToString();
                            info["fname"] = dataReader[1].ToString();
                            info["lname"] = dataReader[2].ToString();
                            info["dob"] = dataReader[5].ToString().Remove(10);
                            info["phone"] = dataReader[6].ToString();
                            info["email"] = dataReader[7].ToString();
                            info["address"] = dataReader[8].ToString();
                            info["city"] = dataReader[9].ToString();
                            info["state"] = dataReader[10].ToString();
                            info["zip"] = dataReader[11].ToString();
                            info["allergy"] = dataReader[12].ToString();
                        }
                        catch (Exception ex)
                        {
                            Form1.errorBox("Error with query.");
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Form1.errorBox(ex.Message);
                    return null;
                }

                dbID = info["ID"];

                return info;
            }
            catch (Exception ex)
            {
                Form1.errorBox(ex.Message);

            }
            return null;
            
        }

        public Dictionary<string, string> searchCustomers(string searchString)
        {
            string queryString = $"SELECT * FROM Customers_List WHERE Customer_FirstName = '{searchString}' " +
                $"OR Customer_LastName = '{searchString}'";

            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("ID", "");
            info.Add("fname", "");
            info.Add("lname", "");
            info.Add("dob", "");
            info.Add("phone", "");
            info.Add("email", "");
            info.Add("address", "");
            info.Add("city", "");
            info.Add("state", "");
            info.Add("zip", "");
            info.Add("allergy", "");

            SqlDataReader dataReader;

            SqlConnection cnn = new SqlConnection(connectionstring);
            cnn.Open();

            SqlCommand cmd = new SqlCommand(queryString, cnn);
            try
            {
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    try
                    {
                        info["ID"] = dataReader[0].ToString();
                        info["fname"] = dataReader[1].ToString();
                        info["lname"] = dataReader[2].ToString();
                        info["dob"] = dataReader[5].ToString().Remove(10);
                        info["phone"] = dataReader[6].ToString();
                        info["email"] = dataReader[7].ToString();
                        info["address"] = dataReader[8].ToString();
                        info["city"] = dataReader[9].ToString();
                        info["state"] = dataReader[10].ToString();
                        info["zip"] = dataReader[11].ToString();
                        info["allergy"] = dataReader[12].ToString();
                    }
                    catch (Exception ex)
                    {
                        Form1.errorBox("Error with query.");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Form1.errorBox(ex.Message);
            }

            dbID = info["ID"];

            return info;
        }
    }
}
