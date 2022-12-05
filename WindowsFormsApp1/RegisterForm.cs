using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class RegisterForm : Form
    {
        private string DBConnectionString;

        public RegisterForm()
        {
            InitializeComponent();
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {

            //remove the focus from the textboxes
            this.ActiveControl = label6;
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void labelLastName_Click(object sender, EventArgs e)
        {

        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFirstName_Enter(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            if (fname.ToLower().Trim().Equals("First Name"))
            {
                textBoxFirstName.Text = "";
                textBoxFirstName.ForeColor = Color.Black;
            }
        }

        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            if (fname.ToLower().Trim().Equals("First Name") || fname.Trim().Equals(""))
            {
                textBoxFirstName.Text = "First Name";
                textBoxFirstName.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmailaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmailaddress_Enter(object sender, EventArgs e)
        {
            String Emailaddress = textBoxEmailaddress.Text;
            if (Emailaddress.ToLower().Trim().Equals("Email address"))
            {
                textBoxEmailaddress.Text = "";
                textBoxEmailaddress.ForeColor = Color.Black;
            }
        }

        private void textBoxEmailaddress_Leave(object sender, EventArgs e)
        {
            String Emailaddress = textBoxEmailaddress.Text;
            if (Emailaddress.ToLower().Trim().Equals("Email address") || Emailaddress.Trim().Equals(""))
            {
                textBoxEmailaddress.Text = "Email address";
                textBoxEmailaddress.ForeColor = Color.Gray;
            }
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            String Username = textBoxUsername.Text;
            if (Username.ToLower().Trim().Equals("Username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            String Username = textBoxUsername.Text;
            if (Username.ToLower().Trim().Equals("Username") || Username.Trim().Equals(""))
            {
                textBoxUsername.Text = "Username";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String Password = textBoxPassword.Text;
            if (Password.ToLower().Trim().Equals("Password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String Password = textBoxPassword.Text;
            if (Password.ToLower().Trim().Equals("Password") || Password.Trim().Equals(""))
            {
                textBoxPassword.Text = "Password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            String ConfirmPassword = textBoxConfirmPassword.Text;
            if (ConfirmPassword.ToLower().Trim().Equals(" Confirm Password"))
            {
                textBoxConfirmPassword.Text = "";
                textBoxConfirmPassword.UseSystemPasswordChar = true;
                textBoxConfirmPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            String ConfirmPassword = textBoxConfirmPassword.Text;
            if (ConfirmPassword.ToLower().Trim().Equals("Confirm Password") ||
                ConfirmPassword.ToLower().Trim().Equals("Password") ||
                ConfirmPassword.Trim().Equals(""))
            {
                textBoxConfirmPassword.Text = "Confirm Password";
                textBoxConfirmPassword.UseSystemPasswordChar = false;
                textBoxConfirmPassword.ForeColor = Color.Gray;
            }
        }
        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            //add a new user

            SqlCommand command = new SqlCommand("INSERT INTO 'user'('firstname' , lastname' , 'email' , 'username' , 'password') VALUES (@fn, @ln, @email, @usn, @pass)");

            DBConnectionClass db = new DBConnectionClass.getInstanceOfDBConnectionClass();

            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = textBoxFirstName.Text;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = textBoxLastName.Text;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = textBoxEmailaddress.Text;
            command.Parameters.Add("@usn", SqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBoxPassword.Text;


            //SqlConnection connToDB = new SqlConnection(DBConnectionString);
            SqlConnection connToDB = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\asus\\source\\repos\\RM_partner\\WindowsFormsApp1\\LoginDatabase.mdf; Integrated Security = True");
            //open connection
            connToDB.Open();
            
            //check if the textboxes contains the default values
            if (checkTextBoxesValues())
            {
                //check if the password equal the confirm password
                if(textBoxPassword.Text.Equals(textBoxConfirmPassword.Text))
                {
                    //check if this username already exists
                    if (checkUsername())

                    {
                        MessageBox.Show("This Username Already Exists, Select A Different One","DUPLICATE USERNAME", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //execute the query
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("YOUR ACCOUNT HAS BEEN CREATED", "ACCOUNT CREATED", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                
                 }
                else
                {
                    MessageBox.Show("WRONG CONFIRMATION PASSWORD", "PASSWORD ERROR", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }


                //check if this username already exists
                if (checkUsername())

                {
                    MessageBox.Show("This Username Already Exists, Select A Different One");
                }
                else
                {
                    //execute the query
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("ACCOUNT CREATED");
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("ENTER YOUR INFORMATIONS FIRST", "EMPTY DATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }


            //close connection
            connToDB.Close();



            if (checkUsername())

            {
                MessageBox.Show("This Username Already Exists, Select A Different One");
            }
            else
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ACCOUNT CREATED");
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
            }

        }


        //check if the username already exists
        public Boolean checkUsername()
        {
                DBConnectionClass db = new DBConnectionClass.getInstanceOfDBConnectionClass();

                String username = textBoxUsername.Text;

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT *FROM 'user' WHERE 'username' = @usn");


                command.Parameters.Add("@usn", SqlDbType.VarChar).Value = username;

                adapter.SelectCommand = command;

                adapter.Fill(table);


            //check if this username already exists in the database 
            if (table.Rows.Count > 0)
            {

                return true;

            }
            else
            {

                return false;

            }

          }

          //check if the textboxes contains the default values
          public Boolean  checkTextBoxesValues()

        {
            String fname = textBoxFirstName.Text;
            String lname = textBoxLastName.Text;
            String Email = textBoxEmailaddress.Text;
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;

            if (fname.Equals("first name") || lname.Equals("last name") ||
                Email.Equals("email address") || username.Equals("username") 
                || password.Equals("password"))
            {
                return true;
            }
            else
            {
                return false;
            }



          }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Blue;
        }

        private void labelGoToLogin_MouseEnter(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.Blue;
        }

        private void labelGoToLogin_MouseLeave(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.Blue;
        }

        private void labelGoToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginform = new LoginForm();
            loginform.Show();
        }
    }
}


