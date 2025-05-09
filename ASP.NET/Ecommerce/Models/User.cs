using System.Data;
using System.Data.SqlClient;

namespace Ecommerce.Models
{
    public class User
    {
        public string FirstName { get; set; }  // First name of the user
        public string LastName { get; set; }   // Last name of the user
        public string Email { get; set; }  // Email address
        public string Password { get; set; }  // Password (hashed)
        public string ConfirmPassword { get; set; }  // Confirm password for validation
        public string Gender { get; set; }  // Gender of the user (optional)
        public string Role { get; set; }  // Role of the user (e.g., Admin, User)
        public DateTime CreatedAt { get; set; }  // Timestamp when the user was created

        /*
           if we do not find SqlConnection -> Tools -> NuGet Package Manager console -> Install-Package System.Data.SqlClient
        */

        public void Registration(IFormCollection formCollection)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Server=DESKTOP-JBRE4TR; Database=Ecommerce; Trusted_Connection=True;";
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RegisterUser";
            cmd.Connection = sqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FirstName", formCollection["FirstName"].ToString());
            cmd.Parameters.AddWithValue("@LastName", formCollection["LastName"].ToString());
            cmd.Parameters.AddWithValue("@Email", formCollection["Email"].ToString());
            cmd.Parameters.AddWithValue("@Password", formCollection["Password"].ToString());
            cmd.Parameters.AddWithValue("@ConfirmPassword", formCollection["ConfirmPassword"].ToString());
            cmd.Parameters.AddWithValue("@Gender", formCollection["Gender"].ToString());
            cmd.Parameters.AddWithValue("@Role", formCollection["Role"].ToString());

            cmd.ExecuteNonQuery(); // Execute the command

            cmd.Dispose();
            sqlConnection.Close();
        }

        public bool LoginCheck(IFormCollection formCollection)
        {
            bool isAuthenticated = false;

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Server=DESKTOP-JBRE4TR; Database=Ecommerce; Trusted_Connection=True;";
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "LoginUser"; // Your stored procedure name
            cmd.Connection = sqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Email", formCollection["Email"].ToString());
            cmd.Parameters.AddWithValue("@Password", formCollection["Password"].ToString());

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                isAuthenticated = true; // User found with given email and password
            }

            reader.Close();
            cmd.Dispose();
            sqlConnection.Close();

            return isAuthenticated;
        }

        public List<User> GetUserData()
        {
            User user = null;
            List<User> obj = new List<User>();

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Server=DESKTOP-JBRE4TR; Database=Ecommerce; Trusted_Connection=True;";
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Users"; // Assumes table name is "Users"
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout= 0;
            cmd.Parameters.Clear();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = new User
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        ConfirmPassword = reader["ConfirmPassword"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Role = reader["Role"].ToString(),
                        CreatedAt = reader["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedAt"]) : DateTime.MinValue
                    };

                    obj.Add(user);
                }
            }

            reader.Close();
            cmd.Dispose();
            sqlConnection.Close();

            return obj;
        }

        public bool ForgotPasswordCheck(string email)
        {
            bool userExists = false;

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Server=DESKTOP-JBRE4TR; Database=Ecommerce; Trusted_Connection=True;";
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@Email", email);

            int count = (int)cmd.ExecuteScalar();
            userExists = count > 0;

            cmd.Dispose();
            sqlConnection.Close();

            return userExists;
        }

        public bool UpdatePassword(string email, string newPassword)
        {
            bool isUpdated = false;

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Server=DESKTOP-JBRE4TR; Database=Ecommerce; Trusted_Connection=True;";
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Users SET Password = @Password WHERE Email = @Email";
            cmd.Connection = sqlConnection;

            cmd.Parameters.AddWithValue("@Password", newPassword); // Ideally, hash the password
            cmd.Parameters.AddWithValue("@Email", email);

            int rowsAffected = cmd.ExecuteNonQuery();
            isUpdated = rowsAffected > 0;

            cmd.Dispose();
            sqlConnection.Close();

            return isUpdated;
        }
    }
}
