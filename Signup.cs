
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;

namespace WealthFront
{
    public partial class Signup : Form
    {
      

        public object Constants { get; private set; }

        public Signup()
        {
            InitializeComponent();
        }

        private void signup_button_Click(object sender, EventArgs e)
        {
            if (usernameSignup_textBox.Text.Equals("") || passwordSignup_textBox.Text.Equals(""))
                MessageBox.Show("Please enter your details");

            else if (! passwordSignup_textBox.Text.Equals(confPassSignup_textBox.Text))
                MessageBox.Show("Passwords do not match");

            else
            {
                // sets these variables to be the input of the user
                string nameValue = nameSignup_textBox.Text;
                string roleValue = roleSignup_textBox.Text;
                string usernameValue = usernameSignup_textBox.Text;
                string passwordValue = passwordSignup_textBox.Text;
                string confirm_passwordValue = confPassSignup_textBox.Text;
                string emailValue = emailSignup_textBox.Text;
                // passes the variables (user input) as parameters for the query, inserting the values to the db through the query
                DBConnection.getInstanceOfDBConnection().SignupQuery(Constants.RegistrationQuery_CHECK, nameValue, roleValue, usernameValue, passwordValue, confirm_passwordValue, emailValue);
                MessageBox.Show("Registered successfully");
                // clears the text boxes in case the user wants to register again
                nameSignup_textBox.Text = roleSignup_textBox.Text = usernameSignup_textBox.Text = passwordSignup_textBox.Text = confPassSignup_textBox.Text = "";
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Signup_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Return2login_button_Click(object sender, EventArgs e)
        {
                this.Hide();
                new Login().Show();
        }

        private void signup_button_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
