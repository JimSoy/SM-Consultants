using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

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
                Form1.mySystemMessage("Successfully connected!");

            }
            catch (Exception ex)
            {
                Form1.failed = true;
                Form1.mySystemMessage("Login failed.");
                Console.WriteLine(ex.Message);
            }

        }

        public void logOut()
        {
            Form1.mySystemMessage("Successfully logged out.");
            Form1.customerPanelSwitch = Form1.adminPanelSwitch = Form1.pharmPanelSwitch = false;
        }

        public void infoUpdater(Dictionary<string, string> info)
        {
            //Check if new user
            if (Form1.newUserCheck)
            {
                SqlConnection cnn = new SqlConnection(connectionstring);
                cnn.Open();

                //check if username exists
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Customers_List WHERE Customer_ID = @id", cnn);

                cmd.Parameters.AddWithValue("@id", dbID);

                int exists = (Int32)cmd.ExecuteScalar();

                //if username already exists, they have logged in with the correct credentials,
                //so inform them that the user exists and update their data
                if (exists > 0)
                {
                    Form1.mySystemMessage("User already exists. Updating your information.");
                    Form1.newUserCheck = false;
                    infoUpdater(info);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Customers_List (Customer_FirstName, Customer_LastName, " +
                    $"Customer_DateOfBirth, Customer_Address, Customer_City, Customer_State, Customer_ZipCode, " +
                    $"Customer_DrugAllergy, Customer_Phone, Customer_Email, Customer_UserName) VALUES (@fn, @ln, " +
                    $"@db, @ad, @ci, @st, @zp, @al, @ph, @em, @id)", cnn);

                    cmd.Parameters.AddWithValue("@fn", info["fname"]);
                    cmd.Parameters.AddWithValue("@ln", info["lname"]);
                    cmd.Parameters.AddWithValue("@db", info["dob"]);
                    cmd.Parameters.AddWithValue("@ad", info["address"]);
                    cmd.Parameters.AddWithValue("@ci", info["city"]);
                    cmd.Parameters.AddWithValue("@st", info["state"]);
                    cmd.Parameters.AddWithValue("@zp", info["zip"]);
                    cmd.Parameters.AddWithValue("@al", info["allergy"]);
                    cmd.Parameters.AddWithValue("@ph", info["phone"]);
                    cmd.Parameters.AddWithValue("@em", info["email"]);
                    cmd.Parameters.AddWithValue("@id", userID);

                    cmd.ExecuteNonQuery();
                    Form1.newUserCheck = false;
                }
            }
            //if not new user do usual update
            else
            {
                SqlConnection cnn = new SqlConnection(connectionstring);
                cnn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Customers_List SET Customer_FirstName = @fn, " +
                                $"Customer_LastName = @ln, Customer_DateOfBirth = @db, Customer_Address = @ad, " +
                                $"Customer_City = @ci, Customer_State = @st, Customer_ZipCode = @zp, " +
                                $"Customer_DrugAllergy = @al, Customer_Phone = @ph, Customer_Email = @em " +
                                $"WHERE Customer_ID = @id", cnn);

                cmd.Parameters.AddWithValue("@fn", info["fname"]);
                cmd.Parameters.AddWithValue("@ln", info["lname"]);
                cmd.Parameters.AddWithValue("@db", info["dob"]);
                cmd.Parameters.AddWithValue("@ad", info["address"]);
                cmd.Parameters.AddWithValue("@ci", info["city"]);
                cmd.Parameters.AddWithValue("@st", info["state"]);
                cmd.Parameters.AddWithValue("@zp", info["zip"]);
                cmd.Parameters.AddWithValue("@al", info["allergy"]);
                cmd.Parameters.AddWithValue("@ph", info["phone"]);
                cmd.Parameters.AddWithValue("@em", info["email"]);
                cmd.Parameters.AddWithValue("@id", dbID);

                using (cmd)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Form1.mySystemMessage(ex.Message);
                    }
                }
                
            }
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
                            Form1.mySystemMessage("Error with query.");
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Form1.mySystemMessage(ex.Message);
                    return null;
                }

                dbID = info["ID"];

                return info;
            }
            catch (Exception ex)
            {
                Form1.mySystemMessage(ex.Message);

            }
            return null;
            
        }

        public Dictionary<string, string> searchCustomers(string searchString)
        {
            //temp string to store and convert date if present
            string dt = "";
            string queryString = "";

            //check the string to see if date is present, then store to string dt
            if (!Regex.IsMatch(searchString, "[^0-9/]"))
            {
                dt = searchString;
                string[] dateSplit = dt.Split('/');
                DateTime td = new DateTime(Convert.ToInt32(dateSplit[2]),
                    Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]));
                dt = td.ToShortDateString();
            }
            
            //if dt is not empty, search by date, otherwise search by name
            if (dt != "")
            {
                queryString = $"SELECT * FROM Customers_List WHERE Customer_DateOfBirth = '{dt}'";
            }
            else
            {
                queryString = $"SELECT * FROM Customers_List WHERE Customer_FirstName = '{searchString}' " +
                $"OR Customer_LastName = '{searchString}'";
            }

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
                        Form1.mySystemMessage("Error with query.");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Form1.mySystemMessage(ex.Message);
            }

            dbID = info["ID"];

            return info;
        }
    }
}
