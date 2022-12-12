using System;
using System.Data;
using System.Data.SqlClient;

namespace WealthFront
{
    class DBConnection
    {
        // private object of the dbconnection class
        private static DBConnection singleton_instance;

        // variable holding the connection string, if you just hardcode the connection string then the program will not work on other machines
        private string connectionString;

        // connection to the database - used to query the database
        private SqlConnection connectionToDB;

        // constructor for this class
        private DBConnection()
        {
            // configuring the connection string (will use default settings)
            connectionString = Properties.Settings.Default.DBConnection;
        }

        // called to perform actions on the database/connect it to the form
        public static DBConnection getInstanceOfDBConnection()
        {
            // the connection will only be initiated if there is no pre-existing connection that has been made
            // if no instance: make new instance, return the instance to make it this method's value
            if (singleton_instance == null)
                singleton_instance = new DBConnection();
            return singleton_instance;
        }

        // this will return the data that is asked by the sql query (passed to it) to retrieve
        public DataSet getDataSet(string SqlQuery)
        {
            // makes a new, empty dataset
            DataSet dataSet = new DataSet();

            // using, because once the method is executed, the connection should be disposed of
            using (connectionToDB = new SqlConnection(connectionString))
            {
                // opens connection to the database
                connectionToDB.Open();
                // used to send a query to the database
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SqlQuery, connectionToDB);
                // fills in the dataset
                dataAdapter.Fill(dataSet);
            }
            // returns the dataset, which is now no longer empty
            return dataSet;
        }

        // inserts data from datagridview into the database
        // the values passed to it are those defined by the user's input in the gui
        public void submitToDB(string sqlQuery, string sectorSelected, bool like, string comments, int randomSearch, string ideaString, string followContentCreator)
        {
            // using, because once the method is executed, the connection should be disposed of
            using (connectionToDB = new SqlConnection(connectionString))
            {
                // opens a connection...
                connectionToDB.Open();
                // sets sqlCommand to hold the specified query, acted on the specified database
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connectionToDB);
                // the command is specififed to be interpreted as text to avoid errors since it depends on user input
                sqlCommand.CommandType = CommandType.Text;
                // these parameters are seen in the insert query in constants, in the brackets, the second arguments will take the place of the string arguments
                // giving the query the data it is required to insert
                sqlCommand.Parameters.Add(new SqlParameter("sectorSelected", sectorSelected));
                sqlCommand.Parameters.Add(new SqlParameter("like", like));
                sqlCommand.Parameters.Add(new SqlParameter("comments", comments));
                sqlCommand.Parameters.Add(new SqlParameter("randomSearch", randomSearch));
                sqlCommand.Parameters.Add(new SqlParameter("ideaString", ideaString));
                sqlCommand.Parameters.Add(new SqlParameter("followContentCreator", followContentCreator));
                // executes the command, using the parameters
                sqlCommand.ExecuteNonQuery();
            }
        }

        // test method for inputing directly into datagridview
        public void TESTsubmitToDB(string sqlQuery)
        {
            // open a connection to the database...
            connectionToDB.Open();
            // run the sql query specified on the specified database
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connectionToDB);
            // executes the command
            sqlCommand.ExecuteNonQuery();
        }

        // take the arguments: the sql query to use, and all of the fields the user has registered with
        public void SignupQuery(string sqlQuery, string name, string role, string username, string password, string confirm_password)
        {

            // using, because once the method is executed, the connection should be disposed of
            using (connectionToDB = new SqlConnection(connectionString))
            {
                // open the connection
                connectionToDB.Open();
                // make sql command be an sqlcommand that is the one specified and acts on the database specified
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connectionToDB);
                // interpret the query as text
                sqlCommand.CommandType = CommandType.Text;
                // take these specified arguments
                sqlCommand.Parameters.Add(new SqlParameter("name", name));
                sqlCommand.Parameters.Add(new SqlParameter("role", role));
                sqlCommand.Parameters.Add(new SqlParameter("username", username));
                sqlCommand.Parameters.Add(new SqlParameter("password", password));
                sqlCommand.Parameters.Add(new SqlParameter("confirm_password", confirm_password));
                // execute the query
                sqlCommand.ExecuteNonQuery();
            }
        }

        // use query and login values the user inputs
        public int loginQuery(string sqlQuery, string usernameValue, string passwordValue)
        {

            // using, because once the method is executed, the connection should be disposed of
            using (connectionToDB = new SqlConnection(connectionString))
            {
                // open the connection
                connectionToDB.Open();
                // sql command is of type sqlcommand and is the query specified, on the database specififed
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connectionToDB);
                // interpret command as text
                sqlCommand.CommandType = CommandType.Text;
                // take these values into the parameters of the query
                sqlCommand.Parameters.Add(new SqlParameter("username", usernameValue));
                sqlCommand.Parameters.Add(new SqlParameter("password", passwordValue));
                // sets temp to 1 if sqlCommand is successful (there is a username+password in the database, equal to the user's input in the login form)
                int temp = Convert.ToInt32(sqlCommand.ExecuteScalar());
                // return the outcome of the login - successful or not (whether the login details match)
                return temp;
            }
        }
    }
}
