namespace USPS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.submit = new System.Windows.Forms.Button();
            this.uspsLogo = new System.Windows.Forms.PictureBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.welcomeText = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.Label();
            this.Previous = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.requestRefill = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.drugAllergyTextBox3 = new System.Windows.Forms.TextBox();
            this.drugAllergyTextBox2 = new System.Windows.Forms.TextBox();
            this.drugAllergyTextBox1 = new System.Windows.Forms.TextBox();
            this.paymentMethodTextBox = new System.Windows.Forms.TextBox();
            this.insuranceTextBox = new System.Windows.Forms.TextBox();
            this.zipCodeTextBox = new System.Windows.Forms.TextBox();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.streetAddressTextBox = new System.Windows.Forms.TextBox();
            this.dateOfBirthTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.drugAllergies = new System.Windows.Forms.Label();
            this.dob = new System.Windows.Forms.Label();
            this.paymentMethod = new System.Windows.Forms.Label();
            this.insurance = new System.Windows.Forms.Label();
            this.zipCode = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.Label();
            this.streetAddress = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.Label();
            this.next = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uspsLogo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.submit);
            this.panel1.Controls.Add(this.uspsLogo);
            this.panel1.Controls.Add(this.loginLabel);
            this.panel1.Controls.Add(this.welcomeText);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.pass);
            this.panel1.Controls.Add(this.user);
            this.panel1.Controls.Add(this.userName);
            this.panel1.Location = new System.Drawing.Point(27, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 353);
            this.panel1.TabIndex = 0;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(100, 319);
            this.submit.Margin = new System.Windows.Forms.Padding(2);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(56, 19);
            this.submit.TabIndex = 7;
            this.submit.Text = "Login";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // uspsLogo
            // 
            this.uspsLogo.Image = ((System.Drawing.Image)(resources.GetObject("uspsLogo.Image")));
            this.uspsLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("uspsLogo.InitialImage")));
            this.uspsLogo.Location = new System.Drawing.Point(56, 14);
            this.uspsLogo.Margin = new System.Windows.Forms.Padding(2);
            this.uspsLogo.Name = "uspsLogo";
            this.uspsLogo.Size = new System.Drawing.Size(155, 125);
            this.uspsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uspsLogo.TabIndex = 6;
            this.uspsLogo.TabStop = false;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(72, 181);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(103, 13);
            this.loginLabel.TabIndex = 5;
            this.loginLabel.Text = "Please Login Below.";
            // 
            // welcomeText
            // 
            this.welcomeText.AutoSize = true;
            this.welcomeText.Location = new System.Drawing.Point(22, 159);
            this.welcomeText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcomeText.Name = "welcomeText";
            this.welcomeText.Size = new System.Drawing.Size(223, 13);
            this.welcomeText.TabIndex = 4;
            this.welcomeText.Text = "Welcome to the United States Postal Service!";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(54, 265);
            this.password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(53, 13);
            this.password.TabIndex = 3;
            this.password.Text = "Password";
            this.password.Click += new System.EventHandler(this.password_Click);
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(54, 281);
            this.pass.Margin = new System.Windows.Forms.Padding(2);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(150, 20);
            this.pass.TabIndex = 2;
            this.pass.UseSystemPasswordChar = true;
            this.pass.TextChanged += new System.EventHandler(this.pass_TextChanged);
            this.pass.Validating += new System.ComponentModel.CancelEventHandler(this.pass_Validating);
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(54, 233);
            this.user.Margin = new System.Windows.Forms.Padding(2);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(150, 20);
            this.user.TabIndex = 1;
            this.user.TextChanged += new System.EventHandler(this.user_TextChanged);
            this.user.Validating += new System.ComponentModel.CancelEventHandler(this.user_Validating);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(53, 217);
            this.userName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(58, 13);
            this.userName.TabIndex = 0;
            this.userName.Text = "User name";
            this.userName.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Previous
            // 
            this.Previous.Location = new System.Drawing.Point(240, 426);
            this.Previous.Margin = new System.Windows.Forms.Padding(2);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(56, 19);
            this.Previous.TabIndex = 1;
            this.Previous.Text = "Previous";
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.logOutButton);
            this.panel2.Controls.Add(this.requestRefill);
            this.panel2.Controls.Add(this.Save);
            this.panel2.Controls.Add(this.edit);
            this.panel2.Controls.Add(this.drugAllergyTextBox3);
            this.panel2.Controls.Add(this.drugAllergyTextBox2);
            this.panel2.Controls.Add(this.drugAllergyTextBox1);
            this.panel2.Controls.Add(this.paymentMethodTextBox);
            this.panel2.Controls.Add(this.insuranceTextBox);
            this.panel2.Controls.Add(this.zipCodeTextBox);
            this.panel2.Controls.Add(this.stateTextBox);
            this.panel2.Controls.Add(this.cityTextBox);
            this.panel2.Controls.Add(this.streetAddressTextBox);
            this.panel2.Controls.Add(this.dateOfBirthTextBox);
            this.panel2.Controls.Add(this.lastNameTextBox);
            this.panel2.Controls.Add(this.firstNameTextBox);
            this.panel2.Controls.Add(this.drugAllergies);
            this.panel2.Controls.Add(this.dob);
            this.panel2.Controls.Add(this.paymentMethod);
            this.panel2.Controls.Add(this.insurance);
            this.panel2.Controls.Add(this.zipCode);
            this.panel2.Controls.Add(this.state);
            this.panel2.Controls.Add(this.city);
            this.panel2.Controls.Add(this.streetAddress);
            this.panel2.Controls.Add(this.lastName);
            this.panel2.Controls.Add(this.firstName);
            this.panel2.Location = new System.Drawing.Point(412, 29);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 353);
            this.panel2.TabIndex = 2;
            // 
            // requestRefill
            // 
            this.requestRefill.Location = new System.Drawing.Point(292, 282);
            this.requestRefill.Margin = new System.Windows.Forms.Padding(2);
            this.requestRefill.Name = "requestRefill";
            this.requestRefill.Size = new System.Drawing.Size(94, 19);
            this.requestRefill.TabIndex = 24;
            this.requestRefill.Text = "Request Refill";
            this.requestRefill.UseVisualStyleBackColor = true;
            this.requestRefill.Click += new System.EventHandler(this.requestRefill_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(96, 327);
            this.Save.Margin = new System.Windows.Forms.Padding(2);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(56, 19);
            this.Save.TabIndex = 23;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(32, 327);
            this.edit.Margin = new System.Windows.Forms.Padding(2);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(56, 19);
            this.edit.TabIndex = 22;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // drugAllergyTextBox3
            // 
            this.drugAllergyTextBox3.Location = new System.Drawing.Point(32, 303);
            this.drugAllergyTextBox3.Margin = new System.Windows.Forms.Padding(2);
            this.drugAllergyTextBox3.Name = "drugAllergyTextBox3";
            this.drugAllergyTextBox3.ReadOnly = true;
            this.drugAllergyTextBox3.Size = new System.Drawing.Size(177, 20);
            this.drugAllergyTextBox3.TabIndex = 21;
            // 
            // drugAllergyTextBox2
            // 
            this.drugAllergyTextBox2.Location = new System.Drawing.Point(32, 280);
            this.drugAllergyTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.drugAllergyTextBox2.Name = "drugAllergyTextBox2";
            this.drugAllergyTextBox2.ReadOnly = true;
            this.drugAllergyTextBox2.Size = new System.Drawing.Size(177, 20);
            this.drugAllergyTextBox2.TabIndex = 20;
            // 
            // drugAllergyTextBox1
            // 
            this.drugAllergyTextBox1.Location = new System.Drawing.Point(32, 258);
            this.drugAllergyTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.drugAllergyTextBox1.Name = "drugAllergyTextBox1";
            this.drugAllergyTextBox1.ReadOnly = true;
            this.drugAllergyTextBox1.Size = new System.Drawing.Size(177, 20);
            this.drugAllergyTextBox1.TabIndex = 19;
            // 
            // paymentMethodTextBox
            // 
            this.paymentMethodTextBox.Location = new System.Drawing.Point(184, 193);
            this.paymentMethodTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.paymentMethodTextBox.Name = "paymentMethodTextBox";
            this.paymentMethodTextBox.ReadOnly = true;
            this.paymentMethodTextBox.Size = new System.Drawing.Size(146, 20);
            this.paymentMethodTextBox.TabIndex = 18;
            // 
            // insuranceTextBox
            // 
            this.insuranceTextBox.Location = new System.Drawing.Point(28, 193);
            this.insuranceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.insuranceTextBox.Name = "insuranceTextBox";
            this.insuranceTextBox.ReadOnly = true;
            this.insuranceTextBox.Size = new System.Drawing.Size(145, 20);
            this.insuranceTextBox.TabIndex = 17;
            // 
            // zipCodeTextBox
            // 
            this.zipCodeTextBox.Location = new System.Drawing.Point(211, 133);
            this.zipCodeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.zipCodeTextBox.Name = "zipCodeTextBox";
            this.zipCodeTextBox.ReadOnly = true;
            this.zipCodeTextBox.Size = new System.Drawing.Size(60, 20);
            this.zipCodeTextBox.TabIndex = 16;
            this.zipCodeTextBox.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // stateTextBox
            // 
            this.stateTextBox.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.stateTextBox.Location = new System.Drawing.Point(165, 133);
            this.stateTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.ReadOnly = true;
            this.stateTextBox.Size = new System.Drawing.Size(35, 20);
            this.stateTextBox.TabIndex = 15;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(32, 134);
            this.cityTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.ReadOnly = true;
            this.cityTextBox.Size = new System.Drawing.Size(121, 20);
            this.cityTextBox.TabIndex = 14;
            // 
            // streetAddressTextBox
            // 
            this.streetAddressTextBox.Location = new System.Drawing.Point(31, 97);
            this.streetAddressTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.streetAddressTextBox.Name = "streetAddressTextBox";
            this.streetAddressTextBox.ReadOnly = true;
            this.streetAddressTextBox.Size = new System.Drawing.Size(177, 20);
            this.streetAddressTextBox.TabIndex = 13;
            this.streetAddressTextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // dateOfBirthTextBox
            // 
            this.dateOfBirthTextBox.Location = new System.Drawing.Point(292, 47);
            this.dateOfBirthTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.dateOfBirthTextBox.Name = "dateOfBirthTextBox";
            this.dateOfBirthTextBox.ReadOnly = true;
            this.dateOfBirthTextBox.Size = new System.Drawing.Size(96, 20);
            this.dateOfBirthTextBox.TabIndex = 12;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(140, 47);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.ReadOnly = true;
            this.lastNameTextBox.Size = new System.Drawing.Size(142, 20);
            this.lastNameTextBox.TabIndex = 11;
            this.lastNameTextBox.TextChanged += new System.EventHandler(this.lastNameTextBox_TextChanged);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(28, 47);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.ReadOnly = true;
            this.firstNameTextBox.Size = new System.Drawing.Size(101, 20);
            this.firstNameTextBox.TabIndex = 10;
            this.firstNameTextBox.TextChanged += new System.EventHandler(this.firstNameTextBox_TextChanged);
            // 
            // drugAllergies
            // 
            this.drugAllergies.AutoSize = true;
            this.drugAllergies.Location = new System.Drawing.Point(31, 233);
            this.drugAllergies.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.drugAllergies.Name = "drugAllergies";
            this.drugAllergies.Size = new System.Drawing.Size(72, 13);
            this.drugAllergies.TabIndex = 9;
            this.drugAllergies.Text = "Drug Allergies";
            // 
            // dob
            // 
            this.dob.AutoSize = true;
            this.dob.Location = new System.Drawing.Point(290, 31);
            this.dob.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dob.Name = "dob";
            this.dob.Size = new System.Drawing.Size(66, 13);
            this.dob.TabIndex = 8;
            this.dob.Text = "Date of Birth";
            this.dob.Click += new System.EventHandler(this.label1_Click_5);
            // 
            // paymentMethod
            // 
            this.paymentMethod.AutoSize = true;
            this.paymentMethod.Location = new System.Drawing.Point(184, 177);
            this.paymentMethod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.paymentMethod.Name = "paymentMethod";
            this.paymentMethod.Size = new System.Drawing.Size(87, 13);
            this.paymentMethod.TabIndex = 7;
            this.paymentMethod.Text = "Payment Method";
            // 
            // insurance
            // 
            this.insurance.AutoSize = true;
            this.insurance.Location = new System.Drawing.Point(28, 176);
            this.insurance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.insurance.Name = "insurance";
            this.insurance.Size = new System.Drawing.Size(54, 13);
            this.insurance.TabIndex = 6;
            this.insurance.Text = "Insurance";
            // 
            // zipCode
            // 
            this.zipCode.AutoSize = true;
            this.zipCode.Location = new System.Drawing.Point(211, 117);
            this.zipCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.zipCode.Name = "zipCode";
            this.zipCode.Size = new System.Drawing.Size(50, 13);
            this.zipCode.TabIndex = 5;
            this.zipCode.Text = "Zip Code";
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Location = new System.Drawing.Point(163, 117);
            this.state.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(32, 13);
            this.state.TabIndex = 4;
            this.state.Text = "State";
            // 
            // city
            // 
            this.city.AutoSize = true;
            this.city.Location = new System.Drawing.Point(31, 118);
            this.city.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(24, 13);
            this.city.TabIndex = 3;
            this.city.Text = "City";
            // 
            // streetAddress
            // 
            this.streetAddress.AutoSize = true;
            this.streetAddress.Location = new System.Drawing.Point(29, 80);
            this.streetAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.streetAddress.Name = "streetAddress";
            this.streetAddress.Size = new System.Drawing.Size(76, 13);
            this.streetAddress.TabIndex = 2;
            this.streetAddress.Text = "Street Address";
            this.streetAddress.Click += new System.EventHandler(this.label1_Click_4);
            // 
            // lastName
            // 
            this.lastName.AutoSize = true;
            this.lastName.Location = new System.Drawing.Point(139, 31);
            this.lastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(58, 13);
            this.lastName.TabIndex = 1;
            this.lastName.Text = "Last Name";
            this.lastName.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // firstName
            // 
            this.firstName.AutoSize = true;
            this.firstName.Location = new System.Drawing.Point(26, 26);
            this.firstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(57, 13);
            this.firstName.TabIndex = 0;
            this.firstName.Text = "First Name";
            this.firstName.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(412, 426);
            this.next.Margin = new System.Windows.Forms.Padding(2);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(56, 19);
            this.next.TabIndex = 3;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(293, 319);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(93, 19);
            this.logOutButton.TabIndex = 25;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 623);
            this.Controls.Add(this.next);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uspsLogo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.PictureBox uspsLogo;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label welcomeText;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label firstName;
        private System.Windows.Forms.Label lastName;
        private System.Windows.Forms.Label streetAddress;
        private System.Windows.Forms.Label dob;
        private System.Windows.Forms.Label paymentMethod;
        private System.Windows.Forms.Label insurance;
        private System.Windows.Forms.Label zipCode;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.Label city;
        private System.Windows.Forms.Label drugAllergies;
        private System.Windows.Forms.TextBox dateOfBirthTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.TextBox streetAddressTextBox;
        private System.Windows.Forms.TextBox drugAllergyTextBox3;
        private System.Windows.Forms.TextBox drugAllergyTextBox2;
        private System.Windows.Forms.TextBox drugAllergyTextBox1;
        private System.Windows.Forms.TextBox paymentMethodTextBox;
        private System.Windows.Forms.TextBox insuranceTextBox;
        private System.Windows.Forms.TextBox zipCodeTextBox;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Button requestRefill;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button logOutButton;
    }
}

