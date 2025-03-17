using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Optimization;

namespace Inventory.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string Servicetype { get; set; }

        public DataTable LoginSp(string UserName, string Password)
        {
            string Constring = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();

            SqlConnection sqlConnection = new SqlConnection(Constring);
            sqlConnection.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "LoginProcedure";
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@userName", UserName));
            cmd.Parameters.Add(new SqlParameter("@Password", Password));


            //Table Data
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);


            cmd.Dispose();
            sqlConnection.Close();
            return dataTable;

        }

        public void SignUpSp(string UserName, string Password,int Age,string Role,string ServiceType)
        {
            string Constring = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();

            SqlConnection sqlConnection = new SqlConnection(Constring);
            sqlConnection.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SignUpProcedure";
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@userName", UserName));
            cmd.Parameters.Add(new SqlParameter("@Password", Password));
            cmd.Parameters.Add(new SqlParameter("@Age", Age));
            cmd.Parameters.Add(new SqlParameter("@Role", Role));
            cmd.Parameters.Add(new SqlParameter("@ServiceType", ServiceType));
            cmd.ExecuteNonQuery();
        


            cmd.Dispose();
            sqlConnection.Close();
            return ;

        }


    }
    
}