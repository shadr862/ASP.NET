using Dapper;
using Dapper_Web_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;
using System.Net;

namespace Dapper_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private string connection { get; set; }
        public UsersController(IConfiguration configuration) {
            this.connection = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            string sql = "SELECT * FROM Users";

            using (var db = new SqlConnection(connection))
            {
                var Users=db.Query<User>(sql);
                return Ok(Users.ToList());
            }

         

        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(CreateUser user)
        {
            string sql = @"INSERT INTO Users (UserName, Password, Email, LastLogin)
                   VALUES (@UserName, @Password, @Email, NULL)";

            using (var db = new SqlConnection(connection))
            {
                db.Execute(sql, user);
            }

            return StatusCode(Convert.ToInt32(HttpStatusCode.OK), new { User = user });
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(CreateUser user, int id)
        {
            string sql = @"UPDATE Users 
                   SET UserName = @UserName, 
                       Password = @Password, 
                       Email = @Email 
                   WHERE Id = @Id";

            using (var db = new SqlConnection(connection))
            {
                var rowsAffected = db.Execute(sql, new { user.UserName, user.Password, user.Email, Id = id });
                if (rowsAffected == 0)
                    return NotFound(new { Message = "User not found" });
            }

            return Ok(new { Message = "User updated successfully", User = user });
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            string sql = "DELETE FROM Users WHERE Id = @Id";

            using (var db = new SqlConnection(connection))
            {
                var rowsAffected = db.Execute(sql, new { Id = id });
                if (rowsAffected == 0)
                    return NotFound(new { Message = "User not found" });
            }

            return Ok(new { Message = "User deleted successfully" });
        }





    }
}
