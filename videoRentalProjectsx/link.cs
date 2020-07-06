using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoRentalProjectsx
{
   public class link
    {

        //object of the sqlconnection class that is used to create the connection 
        SqlConnection conection;

        
        String conectiontring = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=Movie_Project;Integrated Security=True";

        // object of the command class that is used to create a coonection between sqlcommand 
        SqlCommand command;

        // object of the reader class that is used to create a coonection between sqlDataReader 
        SqlDataReader DataReader;


        //this method is used to execute the command by pasing the query as a argument 
        public void Query(String query)
        {
            conection = new SqlConnection(conectiontring);
            conection.Open();
            command = new SqlCommand(query, conection);
            command.ExecuteNonQuery();
            conection.Close();
        }

        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable Record(String qry)
        {
            DataTable tbl = new DataTable();

            conection = new SqlConnection(conectiontring);

            conection.Open();

            command = new SqlCommand(qry, conection);

            DataReader = command.ExecuteReader();

            tbl.Load(DataReader);

            conection.Close();

            return tbl;
        }

    }
}
