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
using System.Text.RegularExpressions;

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
        static string dbID;
        public bool refillCheck = false;
        public static bool failed = false;

        public Form1()
        {
            InitializeComponent();
            //Change title bar name from 'Form1' to 'USPS'
            this.Text = "USPS";
            //hide currently unused elements
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            //set form to autosize to currently used elements
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Save.Enabled = false;
            saveChanges.Enabled = false;
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
                panel3.Visible = false;
            }
        }
        public static void errorBox(string errMessage)
        {
            string err = errMessage;
            MessageBox.Show(err);
        }

        private void user_TextChanged(object sender, EventArgs e)
        {
            userID = user.Text;
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

            userPass = pass.Text;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost\\SQLExpress";
            builder.InitialCatalog = "IT488_USPS";
            builder.TrustServerCertificate = true;
            builder.Password = userPass;
            builder.UserID = userID;

            db = new DB();

            db.DBLogin(userPass, userID);

            infoFill();


        }

        public void infoFill()
        {
            //populate user query data into dictionary, then use those keys to populate textboxes
            Dictionary<string, string> info = db.infoUpdateQuery();

            if (info != null)
            {
                firstNameTextBox.Text = info["fname"];
                textBox_firstName.Text = info["fname"];
                lastNameTextBox.Text = info["lname"];
                textBox_lastName.Text = info["lname"];
                dateOfBirthTextBox.Text = info["dob"];
                textBox_dateOfBirth.Text = info["dob"];
                emailTextBox.Text = info["email"];
                textBox_email.Text = info["email"];
                telephoneNumberTextBox.Text = info["phone"];
                textBox_telephone.Text = info["phone"];
                streetAddressTextBox.Text = info["address"];
                textBox_streetAddress.Text = info["address"];
                stateTextBox.Text = info["state"];
                textBox_state.Text = info["state"];
                cityTextBox.Text = info["city"];
                textBox_city.Text = info["city"];
                zipCodeTextBox.Text = info["zip"];
                textBox_zipcode.Text = info["zip"];
                allergyTextBox.Text = info["allergy"];
                textBox_drugAllergies1.Text = info["allergy"];
                dbID = info["ID"];
            }
            if (!failed)
            {
                if (userID == "IT488_Admin")
                {
                    pharmPanelSwitch = true;
                    formSwitch1();
                }
                else if (info != null)
                {
                    customerPanelSwitch = true;
                    formSwitch1();
                }
            }
        }
        public void searchResults(Dictionary<string, string> info)
        {
            if (info != null)
            {
                firstNameTextBox.Text = info["fname"];
                textBox_firstName.Text = info["fname"];
                lastNameTextBox.Text = info["lname"];
                textBox_lastName.Text = info["lname"];
                dateOfBirthTextBox.Text = info["dob"];
                textBox_dateOfBirth.Text = info["dob"];
                emailTextBox.Text = info["email"];
                textBox_email.Text = info["email"];
                telephoneNumberTextBox.Text = info["phone"];
                textBox_telephone.Text = info["phone"];
                streetAddressTextBox.Text = info["address"];
                textBox_streetAddress.Text = info["address"];
                stateTextBox.Text = info["state"];
                textBox_state.Text = info["state"];
                cityTextBox.Text = info["city"];
                textBox_city.Text = info["city"];
                zipCodeTextBox.Text = info["zip"];
                textBox_zipcode.Text = info["zip"];
                allergyTextBox.Text = info["allergy"];
                textBox_drugAllergies1.Text = info["allergy"];
                dbID = info["ID"];
            }
        }

        public void infoUpdate()
        {
            //update dictionary values with edited data from textboxes and send to db for updating database

            //user side
            if (panel2.Visible == true)
            {
                Dictionary<string, string> info = new Dictionary<string, string>();
                info.Add("fname", firstNameTextBox.Text);
                info.Add("lname", lastNameTextBox.Text);
                info.Add("dob", dateOfBirthTextBox.Text);
                info.Add("phone", telephoneNumberTextBox.Text);
                info.Add("email", emailTextBox.Text);
                info.Add("address", streetAddressTextBox.Text);
                info.Add("city", cityTextBox.Text);
                info.Add("state", stateTextBox.Text);
                info.Add("zip", zipCodeTextBox.Text);
                info.Add("allergy", allergyTextBox.Text);

                db.infoUpdater(info);
            }
            //pharm side
            else
            {
                Dictionary<string, string> info = new Dictionary<string, string>();
                info.Add("fname", textBox_firstName.Text);
                info.Add("lname", textBox_lastName.Text);
                info.Add("dob", textBox_dateOfBirth.Text);
                info.Add("phone", textBox_telephone.Text);
                info.Add("email", textBox_email.Text);
                info.Add("address", textBox_streetAddress.Text);
                info.Add("city", textBox_city.Text);
                info.Add("state", textBox_state.Text);
                info.Add("zip", textBox_zipcode.Text);
                info.Add("allergy", textBox_drugAllergies1.Text);

                db.infoUpdater(info);
            }


        }
        private void requestRefill_Click(object sender, EventArgs e)
        {
            panel4.Location = new System.Drawing.Point(450, 29);
            panel4.Size = new System.Drawing.Size(287, 315);
            panel4.Visible = true;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            //user side edit checks to enable changes
            if (!editCheck)
            {
                DialogResult dR = MessageBox.Show("Edit your information?", "System Message", MessageBoxButtons.OKCancel);
                if (dR == DialogResult.OK)
                {
                    editCheck = true;
                    saveCheck = true;
                    edit.Enabled = false;
                    Edit_onPharmForm.Enabled = false;
                    Save.Enabled = true;
                    saveChanges.Enabled = true;

                    firstNameTextBox.ReadOnly = false;
                    lastNameTextBox.ReadOnly = false;
                    dateOfBirthTextBox.ReadOnly = false;
                    streetAddressTextBox.ReadOnly = false;
                    cityTextBox.ReadOnly = false;
                    stateTextBox.ReadOnly = false;
                    zipCodeTextBox.ReadOnly = false;
                    insuranceTextBox.ReadOnly = false;
                    paymentMethodTextBox.ReadOnly = false;
                    allergyTextBox.ReadOnly = false;
                    telephoneNumberTextBox.ReadOnly = false;
                    emailTextBox.ReadOnly = false;
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
            //user side save checks to verify intent to save and then disable textboxes again
            if (saveCheck)
            {
                DialogResult dR = MessageBox.Show("Save your information?", "System Message", MessageBoxButtons.OKCancel);
                if (dR == DialogResult.OK)
                {
                    infoUpdate();
                    saveCheck = false;
                    Save.Enabled = false;
                    saveChanges.Enabled = false;

                    firstNameTextBox.ReadOnly = true;
                    lastNameTextBox.ReadOnly = true;
                    dateOfBirthTextBox.ReadOnly = true;
                    streetAddressTextBox.ReadOnly = true;
                    cityTextBox.ReadOnly = true;
                    stateTextBox.ReadOnly = true;
                    zipCodeTextBox.ReadOnly = true;
                    insuranceTextBox.ReadOnly = true;
                    paymentMethodTextBox.ReadOnly = true;
                    allergyTextBox.ReadOnly = true;
                    telephoneNumberTextBox.ReadOnly = true;
                    emailTextBox.ReadOnly = true;

                    edit.Enabled = true;
                    Edit_onPharmForm.Enabled = true;
                    editCheck = false;
                }
            }

        }

        //logout and return to sign in screen
        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Log Out?", "System Message", MessageBoxButtons.OKCancel);
            if (dR == DialogResult.OK)
            {
                db.logOut();
                formSwitch1();
            }
        }

        private void Edit_onPharmForm_Click(object sender, EventArgs e)
        {
            //pharm side edit checks
            if (!editCheck)
            {
                DialogResult dR = MessageBox.Show("Edit your information?", "System Message", MessageBoxButtons.OKCancel);
                if (dR == DialogResult.OK)
                {
                    editCheck = true;
                    saveCheck = true;
                    Edit_onPharmForm.Enabled = false;
                    textBox_searchName.Enabled = false;
                    saveChanges.Enabled = true;

                    textBox_firstName.ReadOnly = false;
                    textBox_lastName.ReadOnly = false;
                    textBox_dateOfBirth.ReadOnly = false;
                    textBox_telephone.ReadOnly = false;
                    textBox_email.ReadOnly = false;
                    textBox_streetAddress.ReadOnly = false;
                    textBox_state.ReadOnly = false;
                    textBox_city.ReadOnly = false;
                    textBox_zipcode.ReadOnly = false;
                    textBox_insurance.ReadOnly = false;
                    textBox_paymentMethod.ReadOnly = false;
                    textBox_drugAllergies1.ReadOnly = false;
                }
                else
                {
                    editCheck = false;
                    saveCheck = false;
                }
            }
        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            //pharm side save checks
            if (saveCheck)
            {
                DialogResult dR = MessageBox.Show("Save your information?", "System Message", MessageBoxButtons.OKCancel);
                if (dR == DialogResult.OK)
                {
                    infoUpdate();
                    saveCheck = false;
                    saveChanges.Enabled = false;
                    textBox_searchName.Enabled = true;

                    textBox_firstName.ReadOnly = true;
                    textBox_lastName.ReadOnly = true;
                    textBox_dateOfBirth.ReadOnly = true;
                    textBox_telephone.ReadOnly = true;
                    textBox_email.ReadOnly = true;
                    textBox_streetAddress.ReadOnly = true;
                    textBox_state.ReadOnly = true;
                    textBox_city.ReadOnly = true;
                    textBox_zipcode.ReadOnly = true;
                    textBox_insurance.ReadOnly = true;
                    textBox_paymentMethod.ReadOnly = true;
                    textBox_drugAllergies1.ReadOnly = true;

                    Edit_onPharmForm.Enabled = true;
                    editCheck = false;
                }
            }
        }
        //trigger event when enter key pressed in search field
        private void SearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Do something
                Dictionary<string, string> info = db.searchCustomers(textBox_searchName.Text);
                searchResults(info);
                e.Handled = true;
            }
        }

        private void textBox_searchName_TextChanged(object sender, EventArgs e)
        {
            textBox_searchName.KeyUp += SearchKeyUp;
        }

        // ---- textbox validation section -----

        // Login page validation
        private void user_Validating(object sender, CancelEventArgs e)
        {
            //this allows the form to be closed without displaying the validation method
            if (this.ActiveControl.Equals(sender))
            {
                return;
            }
            //this is the regular null-check validation
            if (String.IsNullOrEmpty(user.Text.Trim()))
            {
                //the e.Cancel bit keeps the cursor from leaving the field until the error is completed
                e.Cancel = true;
                errorBox("Fields cannot be left blank.");
            }
        }

        private void pass_Validating(object sender, CancelEventArgs e)
        {
            if (this.ActiveControl.Equals(sender))
            {
                return;
            }
            if (String.IsNullOrEmpty(pass.Text.Trim()))
            {
                e.Cancel = true;
                errorBox("Fields cannot be left blank.");
            }
        }

        // panel 1 Customer validation
        private void firstNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            //the editCheck makes sure that you are actually editing the data when validations are triggered
            //otherwise it tries to validate even when you aren't editing/changing anything
            if (editCheck)
            {
                firstNameTextBox.Text = firstNameTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(firstNameTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (firstNameTextBox.Text.isAlpha())
                {
                    e.Cancel = true;
                    errorBox("Only letters allowed in name fields.");
                }
            }
        }

        private void lastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                lastNameTextBox.Text = lastNameTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(lastNameTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (lastNameTextBox.Text.isAlpha())
                {
                    e.Cancel = true;
                    errorBox("Only letters allowed in name fields.");
                }
            }
        }

        private void dateOfBirthTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                dateOfBirthTextBox.Text = dateOfBirthTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(dateOfBirthTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (!ValidationFunctions.isDOB(dateOfBirthTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("DOB must be in ##/##/#### format.");
                }
            }
        }

        private void streetAddressTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                streetAddressTextBox.Text = streetAddressTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(streetAddressTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (streetAddressTextBox.Text.isAlphaNum())
                {
                    e.Cancel = true;
                    errorBox("Only letters and numbers allowed in Address field.");
                }
            }
        }

        private void cityTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                cityTextBox.Text = cityTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(cityTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (cityTextBox.Text.isAlpha())
                {
                    e.Cancel = true;
                    errorBox("Only letters allowed in City field.");
                }
            }
        }

        private void stateTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                stateTextBox.Text = stateTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(stateTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (stateTextBox.Text.isAlpha())
                {
                    e.Cancel = true;
                    errorBox("Only letters allowed in State field.");
                }
            }
        }

        private void stateTextBox_TextChanged(object sender, EventArgs e)
        {
            //force uppercase for valid state code
            stateTextBox.Text = stateTextBox.Text.ToUpper();
        }

        private void zipCodeTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                zipCodeTextBox.Text = zipCodeTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(zipCodeTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (zipCodeTextBox.Text.isNum())
                {
                    e.Cancel = true;
                    errorBox("Zipcode field must be in ##### format.");
                }
            }
        }

        private void insuranceTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                insuranceTextBox.Text = insuranceTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(insuranceTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (insuranceTextBox.Text.isAlphaNum())
                {
                    e.Cancel = true;
                    errorBox("Only letters and numbers allowed in Address field.");
                }
            }
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                emailTextBox.Text = emailTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(emailTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (!ValidationFunctions.IsEmail(emailTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Please enter a valid email address.");
                }
            }
        }

        private void telephoneNumberTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                telephoneNumberTextBox.Text = telephoneNumberTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(telephoneNumberTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (telephoneNumberTextBox.Text.isPhone())
                {
                    e.Cancel = true;
                    errorBox("Telephone Number field must be in ###-###-#### format.");
                }
            }
        }

        private void telephoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            //when inputting a phone number, automatically insert "-" after first three digits and
            //next three digits, then put the cursor after the dash
            if (telephoneNumberTextBox.Text.Length == 3)
            {
                telephoneNumberTextBox.Text = telephoneNumberTextBox.Text + "-";
                telephoneNumberTextBox.SelectionStart = 4;
            }
            if (telephoneNumberTextBox.Text.Length == 7)
            {
                telephoneNumberTextBox.Text = telephoneNumberTextBox.Text + "-";
                telephoneNumberTextBox.SelectionStart = 8;
            }
        }

        private void paymentMethodTextBox_Validating(object sender, CancelEventArgs e)
        {
            //We can include regex to verify that input is a valid cc number, but for
            //now it simply checks for the right number of digits
            if (editCheck)
            {
                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                paymentMethodTextBox.Text = paymentMethodTextBox.Text.Trim();

                if (String.IsNullOrEmpty(paymentMethodTextBox.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if ((paymentMethodTextBox.Text.isNum()) || (paymentMethodTextBox.Text.Length < 15))
                {
                    e.Cancel = true;
                    errorBox("Payment Method field must be between 15 and 19 numerical characters.");
                }
            }
        }

        private void allergyTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                allergyTextBox.Text = allergyTextBox.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                //no null check, as this is the only field that may not always be used
                if (allergyTextBox.Text.isAlphaNum())
                {
                    e.Cancel = true;
                    errorBox("Only letters and numbers allowed in Drug Allergies field.");
                }
            }
        }

        //panel 2 Pharm validation

        private void textBox_firstName_Validating(object sender, CancelEventArgs e)
        {
            //the editCheck makes sure that you are actually editing the data when validations are triggered
            //otherwise it tries to validate even when you aren't editing/changing anything
            if (editCheck)
            {
                textBox_firstName.Text = textBox_firstName.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_firstName.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (textBox_firstName.Text.isAlpha())
                {
                    e.Cancel = true;
                    errorBox("Only letters allowed in name fields.");
                }
            }
        }

        private void textBox_lastName_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_lastName.Text = textBox_lastName.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_lastName.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (textBox_lastName.Text.isAlpha())
                {
                    e.Cancel = true;
                    errorBox("Only letters allowed in name fields.");
                }
            }
        }

        private void textBox_dateOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_dateOfBirth.Text = textBox_dateOfBirth.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_dateOfBirth.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (!ValidationFunctions.isDOB(textBox_dateOfBirth.Text))
                {
                    e.Cancel = true;
                    errorBox("DOB must be in ##/##/#### format.");
                }
            }
        }

        private void textBox_streetAddress_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_streetAddress.Text = textBox_streetAddress.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_streetAddress.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (textBox_streetAddress.Text.isAlphaNum())
                {
                    e.Cancel = true;
                    errorBox("Only letters and numbers allowed in Address field.");
                }
            }
        }

        private void textBox_city_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_city.Text = textBox_city.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_city.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (textBox_city.Text.isAlpha())
                {
                    e.Cancel = true;
                    errorBox("Only letters allowed in City field.");
                }
            }
        }

        private void textBox_state_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_state.Text = textBox_state.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_state.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (textBox_state.Text.isAlpha())
                {
                    e.Cancel = true;
                    errorBox("Only letters allowed in State field.");
                }
            }
        }

        private void textBox_state_TextChanged(object sender, EventArgs e)
        {
            //force uppercase for valid state code
            stateTextBox.Text = stateTextBox.Text.ToUpper();
        }

        private void textBox_zipcode_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_zipcode.Text = textBox_zipcode.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_zipcode.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (textBox_zipcode.Text.isNum())
                {
                    e.Cancel = true;
                    errorBox("Zipcode field must be in ##### format.");
                }
            }
        }

        private void textBox_insurance_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_insurance.Text = textBox_insurance.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_insurance.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (textBox_insurance.Text.isAlphaNum())
                {
                    e.Cancel = true;
                    errorBox("Only letters and numbers allowed in Address field.");
                }
            }
        }

        private void textBox_email_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_email.Text = textBox_email.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_email.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (!ValidationFunctions.IsEmail(textBox_email.Text))
                {
                    e.Cancel = true;
                    errorBox("Please enter a valid email address.");
                }
            }
        }

        private void textBox_telephone_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_telephone.Text = textBox_telephone.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                if (String.IsNullOrEmpty(textBox_telephone.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if (textBox_telephone.Text.isPhone())
                {
                    e.Cancel = true;
                    errorBox("Telephone Number field must be in ###-###-#### format.");
                }
            }
        }

        private void textBox_telephone_TextChanged(object sender, EventArgs e)
        {
            //when inputting a phone number, automatically insert "-" after first three digits and
            //next three digits, then put the cursor after the dash
            if (textBox_telephone.Text.Length == 3)
            {
                textBox_telephone.Text = textBox_telephone.Text + "-";
                textBox_telephone.SelectionStart = 4;
            }
            if (textBox_telephone.Text.Length == 7)
            {
                textBox_telephone.Text = textBox_telephone.Text + "-";
                textBox_telephone.SelectionStart = 8;
            }
        }

        private void textBox_paymentMethod_Validating(object sender, CancelEventArgs e)
        {
            //We can include regex to verify that input is a valid cc number, but for
            //now it simply checks for the right number of digits
            if (editCheck)
            {
                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                textBox_paymentMethod.Text = textBox_paymentMethod.Text.Trim();

                if (String.IsNullOrEmpty(textBox_paymentMethod.Text))
                {
                    e.Cancel = true;
                    errorBox("Fields cannot be left blank.");
                }

                if ((textBox_paymentMethod.Text.isNum()) || (textBox_paymentMethod.Text.Length < 15))
                {
                    e.Cancel = true;
                    errorBox("Payment Method field must be between 15 and 19 numerical characters.");
                }
            }
        }

        private void textBox_drugAllergies1_Validating(object sender, CancelEventArgs e)
        {
            if (editCheck)
            {
                textBox_drugAllergies1.Text = textBox_drugAllergies1.Text.Trim();

                if (this.ActiveControl.Equals(sender))
                {
                    return;
                }

                //no null check, as this is the only field that may not always be used
                if (textBox_drugAllergies1.Text.isAlphaNum())
                {
                    e.Cancel = true;
                    errorBox("Only letters and numbers allowed in Drug Allergies field.");
                }
            }
        }

        // unused stuff. Will delete if all remains unused.

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

        private void password_Click(object sender, EventArgs e)
        {

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

        

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void goBack_btn_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        //refill checkbox area -- customer
        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                button3.Enabled = true;
            }
            else if ((checkBox1.Checked == true) || (checkBox2.Checked == true) ||
                (checkBox3.Checked == true) || (checkBox4.Checked == true) || (checkBox5.Checked == true))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                button3.Enabled = true;
            }
            else if ((checkBox1.Checked == true) || (checkBox2.Checked == true) ||
                (checkBox3.Checked == true) || (checkBox4.Checked == true) || (checkBox5.Checked == true))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                button3.Enabled = true;
            }
            else if ((checkBox1.Checked == true) || (checkBox2.Checked == true) ||
                (checkBox3.Checked == true) || (checkBox4.Checked == true) || (checkBox5.Checked == true))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                button3.Enabled = true;
            }
            else if ((checkBox1.Checked == true) || (checkBox2.Checked == true) ||
                (checkBox3.Checked == true) || (checkBox4.Checked == true) || (checkBox5.Checked == true))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button3.Enabled = true;
            }
            else if ((checkBox1.Checked == true) || (checkBox2.Checked == true) || 
                (checkBox3.Checked == true) || (checkBox4.Checked == true) || (checkBox5.Checked == true))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        //refil checkbox area -- pharm

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_reorder.Checked == true)
            {
                SubmitOrder.Enabled = true;
            }
            else if ((checkBox1_reorder.Checked == true) || (checkBox2__reorder.Checked == true) ||
                (checkBox3_reorder.Checked == true) || (checkBox4_reorder.Checked == true) || (checkBox5_reorder.Checked == true))
            {
                SubmitOrder.Enabled = true;
            }
            else
            {
                SubmitOrder.Enabled = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2__reorder.Checked == true)
            {
                SubmitOrder.Enabled = true;
            }
            else if ((checkBox1_reorder.Checked == true) || (checkBox2__reorder.Checked == true) ||
                (checkBox3_reorder.Checked == true) || (checkBox4_reorder.Checked == true) || (checkBox5_reorder.Checked == true))
            {
                SubmitOrder.Enabled = true;
            }
            else
            {
                SubmitOrder.Enabled = false;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3_reorder.Checked == true)
            {
                SubmitOrder.Enabled = true;
            }
            else if ((checkBox1_reorder.Checked == true) || (checkBox2__reorder.Checked == true) ||
                (checkBox3_reorder.Checked == true) || (checkBox4_reorder.Checked == true) || (checkBox5_reorder.Checked == true))
            {
                SubmitOrder.Enabled = true;
            }
            else
            {
                SubmitOrder.Enabled = false;
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4_reorder.Checked == true)
            {
                SubmitOrder.Enabled = true;
            }
            else if ((checkBox1_reorder.Checked == true) || (checkBox2__reorder.Checked == true) ||
                (checkBox3_reorder.Checked == true) || (checkBox4_reorder.Checked == true) || (checkBox5_reorder.Checked == true))
            {
                SubmitOrder.Enabled = true;
            }
            else
            {
                SubmitOrder.Enabled = false;
            }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5_reorder.Checked == true)
            {
                SubmitOrder.Enabled = true;
            }
            else if ((checkBox1_reorder.Checked == true) || (checkBox2__reorder.Checked == true) ||
                (checkBox3_reorder.Checked == true) || (checkBox4_reorder.Checked == true) || (checkBox5_reorder.Checked == true))
            {
                SubmitOrder.Enabled = true;
            }
            else
            {
                SubmitOrder.Enabled = false;
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click_1(object sender, EventArgs e)
        {

        }

        private void Adherence_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void report_btn_Click(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    public static partial class ValidationFunctions
    {
        public static bool isAlpha(this string @this)
        {
            return Regex.IsMatch(@this, "[^a-zA-Z]");
        }
        public static bool isNum(this string @this)
        {
            return Regex.IsMatch(@this, "[^0-9]");
        }
        public static bool isPhone(this string @this)
        {
            return Regex.IsMatch(@this, "[^0-9-]");
        }
        public static bool isAlphaNum(this string @this)
        {
            return Regex.IsMatch(@this, @"[^a-zA-Z0-9\s,.]");
        }
        public static bool isDOB(string dt)
        {
            //compares textbox to DateTime format with '/' as the separator to verify that it is valid
            try
            {
                string[] dateSplit = dt.Split('/');
                DateTime td = new DateTime(Convert.ToInt32(dateSplit[2]),
                    Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]));

                return true;
            }
            catch
            {
                return false;
            }
        }
        //simple email validation
        //from user Cogwheel @ https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        public static bool IsEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
