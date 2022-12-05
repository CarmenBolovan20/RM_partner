using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Management.Instrumentation;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    class DBConnectionClass
    {
        //attributes

        //private object of the class itself
        private static DBConnectionClass instance;

        //connection string
        private static string DBConnectionString;

        //connection to the DB
        private SqlConnection connToDB;

        public StreamingContext SqlQuerry { get; private set; }

        //Constructors
        private DBConnectionClass()
        {

            //initialise the DBConnectionString
            DBConnectionString = Properties.Settings.Default.DBConnectionString;
        }


        ///
        ///methods
        ///
        /**
         * a static method that creates an unique object of the class itself
         */

        public static DBConnectionClass GetInstanceOfDBConnectionClass()
        {
            if (instance == null)
                instance = new DBConnectionClass();
            return instance;
        }

        public DataSet getDataSet(string SqlQuery)
        {
            //create the dataset object
            DataSet dataset = new DataSet();

            using (SqlConnection connToDB = new SqlConnection(DBConnectionString)) ;
            {
                //open connection
                connToDB.Open();

                //send Sql querry to the database
                SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, connToDB);

                //Fill in the dataset
                adapter.Fill(dataset);
            }

            return dataset;
        }

        /**
         * Method to save the parameters in the database
         */

        public void saveToDB(string SqlQuery, string username, string password)
        {
           
           using (SqlConnection connToDB = new SqlConnection(DBConnectionString))

            {
                //open connection
                connToDB.Open();

               SqlCommand sqlCommand =  new SqlCommand(SqlQuery, connToDB);

                //set the sqlCommand's properties
                sqlCommand.CommandType = CommandType.Text;

               // sqlCommand.Parameters.Add(new SqlParameter("Username", Username));
               // sqlCommand.Parameters.Add(new SqlParameter("Password", Password));

                //execute the command
                sqlCommand.ExecuteNonQuery();

               

           }
        }


            internal static int ExecuteNonQuery()
            {
                throw new NotImplementedException();
            }

        internal class getInstanceOfDBConnectionClass : DBConnectionClass
        {
        }
    }

}



















