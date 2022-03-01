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
        public static bool pharmPanelSwitch = false;
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
            panel3.Visible = false;

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
            else if (pharmPanelSwitch == true)
            {
                panel1.Visible = false;
                panel3.Visible = true;

                panel3.Location = new System.Drawing.Point(27, 29);
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

            infoFill();
        }

        public void infoFill()
        {
            Dictionary<string, string> info = db.infoUpdateQuery();

            if (info != null)
            {
                firstNameTextBox.Text = info["fname"];
                lastNameTextBox.Text = info["lname"];
                dateOfBirthTextBox.Text = info["dob"];
                //emailTextBox.Text = info["email"];
                //phoneTextBox.Text = info["phone"];
                streetAddressTextBox.Text = info["address"];
                stateTextBox.Text = info["state"];
                cityTextBox.Text = info["city"];
                zipCodeTextBox.Text = info["zip"];
                drugAllergyTextBox1.Text = info["allergy"];
            }
        }

        public void infoUpdate()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("fname", firstNameTextBox.Text);
            info.Add("lname", lastNameTextBox.Text);
            info.Add("dob", dateOfBirthTextBox.Text);
            //info.Add("phone", phoneTextBox.Text);
            //info.Add("email", emailTextBox.Text);
            info.Add("address", streetAddressTextBox.Text);
            info.Add("city", cityTextBox.Text);
            info.Add("state", stateTextBox.Text);
            info.Add("zip", zipCodeTextBox.Text);
            info.Add("allergy", drugAllergyTextBox1.Text);

            db.infoUpdater(info);
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
                    infoUpdate();
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

        private void cityTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
