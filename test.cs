// file is used to test out code/make large modifications before altering the actual version of the code

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using sqlconnection;

namespace WealthFront
{
    class testing
    {
        private void signupTest()
        {
             string connectionString = Properties.Settings.Default.connection;
            
            if (usernameSignup_textBox.Text == "" || passwordSignup_textBox.Text == "")
                MessageBox.Show("Please Enter Mandatory Details");

            else if (passwordSignup_textBox.Text != confPassSignup_textBox.Text)
                MessageBox.Show("Password do not Match");

            else
            {

                 using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlcmd = new SqlCommand("UserAdd", conn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@role_", textBox3.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@username", tbUsername.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@password", tbPassword.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@confirm_password", textBox2.Text.Trim()); 
                    sqlcmd.ExecuteNonQuery();

                    String query = "insert into user(name,username,password,role,confirm_password)Values('" + nameSignUp_textBox.Text + "', '" + usernameSignup_textBox.Text + "', '" + passwordSignup_textBox.Text + "', '" + jobDescSignup_textBox.Text + "', '" + confPassSignup_textBox.Text + "')";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    da.SelectCommand.ExecuteNonQuery();
                  
                MessageBox.Show("Registered successfully");
                    clear();

                }

            }

            void clear()
            {
                nameSignup_textBox.Text = roleDescSignup_textBox.Text = usernameSignup_textBox.Text = passwordSignup_textBox.Text = confPassSignup_textBox.Text = "";
            }
        }

        private void LoginTest()
        {
         using (SqlConnection conn = new SqlConnection(connectionString))
        {

            String check = "select count(*) from [user] where username = '" + usernameLogin_textBox.Text + "'AND password= '" + passwordLogin_textBox.Text + "' ";
            SqlCommand comand = new SqlCommand(check, conn);
            conn.Open();
            int temp = Convert.ToInt32(comand.ExecuteScalar().ToString());
            conn.Close();
        
        if (temp == 1)
                {
                    this.Hide();
                    new programForm().Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username and Password");
                }
            }
        }
    }
}
*/