using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Inventory.Models
{
    public class EquipmentList
    {
       public int Equipmentid { get; set; }
       public string EquipmentName { get; set; }
       public int Quantity { get; set; }
       public DateTime EntryDate { get; set; }
       public DateTime EndDate { get; set; }

       public List<EquipmentList> equipmentLists ()
       {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();

            SqlConnection sqlConnection = new SqlConnection(constr);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EquipmentList_procedure";
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            List<EquipmentList> list = new List<EquipmentList>();
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    EquipmentList obj = new EquipmentList();
                    obj.Equipmentid = int.Parse(reader["Equipmentid"].ToString());
                    obj.EquipmentName = reader["EquipmentName"].ToString();
                    obj.Quantity= int.Parse(reader["Quantity"].ToString());
                    obj.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString().IsEmpty()?"2023-05-22": reader["EntryDate"].ToString());
                    obj.EndDate= Convert.ToDateTime(reader["EndDate"].ToString().IsEmpty() ?"2023-05-22" : reader["EndDate"].ToString());
                    list.Add(obj);
                }
            }

            cmd.Dispose();
            sqlConnection.Close();
            return list;

       }



       public void DeleteRow(int id)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();

            SqlConnection sqlConnection = new SqlConnection(constr);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EquipmentList_procedure_Delete";
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@Equipmentid", id));
            cmd.ExecuteNonQuery();
            


            cmd.Dispose();
            sqlConnection.Close();
    

        }





       public void SaveEquipment(int choice)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();

            SqlConnection sqlConnection = new SqlConnection(constr);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Save_Procedure";
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@choice", choice));
            cmd.Parameters.Add(new SqlParameter("@Equipmentid", this.Equipmentid));
            cmd.Parameters.Add(new SqlParameter("@EquipmentName", this.EquipmentName));
            cmd.Parameters.Add(new SqlParameter("@Quantity", this.Quantity));
            cmd.Parameters.Add(new SqlParameter("@EntryDate", this.EntryDate));
            cmd.Parameters.Add(new SqlParameter("@EndDate", this.EndDate));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            sqlConnection.Close();
        }



       public bool checkValidity(int id)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();

            SqlConnection sqlConnection = new SqlConnection(constr);
            sqlConnection.Open();

            string checkQuery = "SELECT COUNT(*) FROM [dbo].[EquipmentList] WHERE Equipmentid = '" + id + "' ";
            SqlCommand checkCmd = new SqlCommand(checkQuery, sqlConnection);
            checkCmd.CommandTimeout = 0;
            int count = (int)checkCmd.ExecuteScalar();

            checkCmd.Dispose();
            sqlConnection.Close();

            if (count > 0)
            {
                return true;
            }
            return false;
        }



       public DataTable AssignedEquipmentList()
    {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();

            SqlConnection sqlConnection = new SqlConnection(constr);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "AssignedEquipmentList_procedure";
            cmd.Connection = sqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dt);

            cmd.Dispose();
            sqlConnection.Close();

            return dt;
    }


        public static int SaveEquipmentAssignment(FormCollection frmCol)
        {
            string Connstring = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(Connstring);
            sqlConnection.Open();

            string CommandText = "";
            if (frmCol["btnSubmit"].ToString()== "Save")
            {
                CommandText = "Save_NewAssignCustomer";
            }
            else if(frmCol["btnSubmit"].ToString() == "Update")
            {
                CommandText = "Update_NewAssignCustomer";
            }
            SqlCommand cmd = new SqlCommand(CommandText, sqlConnection);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@CustomerID", Convert.ToInt32(frmCol["txtCustomerID"].ToString())));
            cmd.Parameters.Add(new SqlParameter("@EquipmentID", Convert.ToInt32(frmCol["txtEquipmentID"].ToString())));
            cmd.Parameters.Add(new SqlParameter("@EquiCount", Convert.ToInt32(frmCol["txtQuantity"].ToString())));
            //cmd.Parameters.Add()
            int returnvalue = cmd.ExecuteNonQuery();
            cmd.Dispose();
            sqlConnection.Close();
            return returnvalue;
        }



















    }
}