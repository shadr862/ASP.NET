using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

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

        public DataTable ValidateMemberAsDataTable(string UserName, string Password)
        {
            string Constring = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();

            SqlConnection sqlConnection = new SqlConnection(Constring);
            sqlConnection.Open();

            string command = "select * from [dbo].[User] where Name='"+ UserName + "' and Password='"+Password+"'";
            SqlCommand cmd = new SqlCommand(command, sqlConnection);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();

            //Table Data
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);


            cmd.Dispose();
            sqlConnection.Close();
            return dataTable;
          
        }

        public List<User> ValidateMemberAsList()
        {
            string Appseting = ConfigurationManager.AppSettings["EmployeeDBConnectionAppSetting"].ToString();

            SqlConnection sqlConnection = new SqlConnection(Appseting);
            sqlConnection.Open();

            string command = "select * from [dbo].[User]";
            SqlCommand cmd = new SqlCommand(command, sqlConnection);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();

            //List
            List<User> users = new List<User>();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = int.Parse(reader["Id"].ToString());
                    user.Name = reader["Name"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.Age = int.Parse(reader["Age"].ToString());
                    user.Role = reader["Role"].ToString();
                    user.Servicetype = reader["Servicetype"].ToString();
                    users.Add(user);
                }
            }



            cmd.Dispose();
            sqlConnection.Close();

            return users;
        }

    }

    
}