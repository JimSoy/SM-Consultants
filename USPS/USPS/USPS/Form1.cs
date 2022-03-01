using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace USPS
{
    public partial class Form1 : Form
    {
        DB db;
        public static bool customerPanelSwitch = false;
        static bool editCheck = false;
        static bool saveCheck = false;
        static string userPass;
        static string userID;
        public Form1()
        {
            InitializeComponent();
            //Change title bar name from 'Form1' to 'USPS'
            this.Text = "USPS";
            //hide currently unused elements
            panel2.Visible = false;
            Previous.Visible = false;
            next.Visible = false;

            //set form to autosize to currently used elements
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Save.Enabled = false;
        }

        private void formSwitch1()
        {
            if (customerPanelSwitch == true)
            {
                //switch visible panels
                panel1.Visible = false;
                panel2.Visible = true;
                //shift 2nd panel to first panel position
                panel2.Location = new System.Drawing.Point(27, 29);
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }
        public static void errorBox(string errMessage)
        {
            string err = errMessage;
            MessageBox.Show(err);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void user_TextChanged(object sender, EventArgs e)
        {
            userID = user.Text;
        }

        private void password_Click(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            
            userPass = pass.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }

        private void label1_Click_5(object sender, EventArgs e)
        {

        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost\\SQLExpress";
            builder.InitialCatalog = "USPS_IT488"; //Whatever Database, used one from a previous course for testing
            builder.TrustServerCertificate = true;
            builder.Password = userPass;
            builder.UserID = userID;
            //connectionstring = builder.ConnectionString;

            db = new DB();

            db.DBLogin(userPass, userID);

            formSwitch1();
        }

        private void requestRefill_Click(object sender, EventArgs e)
        {
            //temporary query for testing
            string names = db.getCustomerNames();
            MessageBox.Show(names);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (!editCheck)
            {
                DialogResult dR = MessageBox.Show("Edit your information?", "System Message", MessageBoxButtons.OKCancel);
                if (dR == DialogResult.OK)
                {
                    editCheck = true;
                    saveCheck = true;
                    edit.Enabled = false;
                    Save.Enabled = true;

                    firstNameTextBox.ReadOnly = false;
                    lastNameTextBox.ReadOnly = false;
                    dateOfBirthTextBox.ReadOnly = false;
                    streetAddressTextBox.ReadOnly = false;
                    cityTextBox.ReadOnly = false;
                    stateTextBox.ReadOnly = false;
                    zipCodeTextBox.ReadOnly = false;
                    insuranceTextBox.ReadOnly = false;
                    paymentMethodTextBox.ReadOnly = false;
                    drugAllergyTextBox1.ReadOnly = false;
                    drugAllergyTextBox2.ReadOnly = false;
                    drugAllergyTextBox3.ReadOnly = false;
                }
                else
                {
                    editCheck = false;
                    saveCheck = false;
                }
            }
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (saveCheck)
            {
                DialogResult dR = MessageBox.Show("Save your information?", "System Message", MessageBoxButtons.OKCancel);
                if (dR == DialogResult.OK)
                {
                    saveCheck = false;
                    Save.Enabled = false;

                    firstNameTextBox.ReadOnly = true;
                    lastNameTextBox.ReadOnly = true;
                    dateOfBirthTextBox.ReadOnly = true;
                    streetAddressTextBox.ReadOnly = true;
                    cityTextBox.ReadOnly = true;
                    stateTextBox.ReadOnly = true;
                    zipCodeTextBox.ReadOnly = true;
                    insuranceTextBox.ReadOnly = true;
                    paymentMethodTextBox.ReadOnly = true;
                    drugAllergyTextBox1.ReadOnly = true;
                    drugAllergyTextBox2.ReadOnly = true;
                    drugAllergyTextBox3.ReadOnly = true;

                    edit.Enabled = true;
                    editCheck = false;
                }
            }
            
        }

        private void user_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(user.Text.Trim()))
            {
                errorBox("Fields cannot be left blank.");
            }
        }

        private void pass_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(pass.Text.Trim()))
            {
                errorBox("Fields cannot be left blank.");
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Log Out?", "System Message", MessageBoxButtons.OKCancel);
            if (dR == DialogResult.OK)
            {
                db.logOut();
                formSwitch1();
            }
        }
    }
}
