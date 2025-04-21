using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Inventory.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomertName { get; private set; }
        public string CustomerName { get; set; }
        public string CustomerMob { get; set; }
        public string CustomerAdd { get; set; }

        public List<Customer> CustomerList()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();

            SqlConnection sqlConnection = new SqlConnection(constr);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "CustomerList_procedure";
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            List<Customer> list = new List<Customer>();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Customer obj = new Customer();
                    obj.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    obj.CustomertName = reader["CustomerName"].ToString();
                    obj.CustomerMob = reader["CustomerMob"].ToString();
                    obj.CustomerAdd = reader["CustomerAdd"].ToString();

                    list.Add(obj);
                }
            }

            cmd.Dispose();
            sqlConnection.Close();
            return list;
        }

    }
}