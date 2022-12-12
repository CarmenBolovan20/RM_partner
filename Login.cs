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
using System.Management.Instrumentation;

namespace WealthFront
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            this.textBoxPassword.AutoSize = false;
            this.textBoxPassword.Size = new Size(this.textBoxPassword.Size.Width, 40);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //get the username and password and send them to the backend to be validated.
             String result = (new LoginBE()).login(textBoxUsername.Text);
             MessageBox.Show(result);
            //paLogin.Visible = false;

            SqlConnection connToDB = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\Users\LENOVO\source\repos\WealthFront\WealthFront.mdf; Integrated Security = True");

            //open connection
            connToDB.Open();

            SqlCommand command = new SqlCommand ("INSERT INTO 'loginDatabase'('username' , 'password') VALUES @usn, @pass)", connToDB);

            DBConnectionClass db = new DBConnectionClass.getInstanceOfDBConnectionClass();

            command.Parameters.Add("@usn", SqlDbType.VarChar).Value = textBoxUsername.Text;

        }
         
        private void label_Close_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void textBoxPasword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_Close_MouseEnter(object sender, EventArgs e)
        {
            label_Close.ForeColor = Color.Black;
        }

        private void label_Close_MouseLeave(object sender, EventArgs e)
        {
            label_Close.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //returns the object of the DBConnectionClass
            DBConnectionClass dBConn = DBConnectionClass.GetInstanceOfDBConnectionClass();
            DataSet datasetLogin = dBConn.getDataSet("SELECT *FROM Login");
            dgvLogin.DataSource = datasetLogin.Tables[0];


        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            //dBConn.saveToDB("INSERT INTO Login(Username, Password) VALUES (@Username, @Password)", username, password);
        }

        //check if the username already exists
        public bool checkUsername()
        {
            DBConnectionClass db = new DBConnectionClass.getInstanceOfDBConnectionClass();

            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT *FROM 'user' WHERE 'username' = @usn  and 'password' = @pass");


            command.Parameters.Add("@usn", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);


            //check if this username exists or not
            if (table.Rows.Count > 0)
            {
                this.Hide();
                MainForm1 mainform1 = new MainForm1();
                mainform1.Show();
            }
            else
            {
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("ENTER YOUR USERNAME TO LOGIN", "EMPTY USERNAME", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // MessageBox.Show("NO");
                else if (username.Trim().Equals(""))
                {
                    MessageBox.Show("ENTER YOUR PASSWORD TO LOGIN", "EMPTY PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("WRONG USERNAME OR PASSWORD ", "    WERONG DATA ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
            return false;

        }

        private void labelGoToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerform = new RegisterForm();
            registerform.Show();
        }

        private void labelGoToSignUp_MouseEnter(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.Yellow;
        }

        private void labelGoToSignUp_MouseLeave(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.Blue;
        }
    }
}
    
