using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuestuonAndAnswer.Model;
using System.Data.SqlClient;

namespace QuestionAndAnswer.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class ProductsController : ControllerBase
    {
        private readonly string _connectionString;

        public ProductsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            var products = new List<Product>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand("SELECT * FROM Products", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()!,
                    Quantity = (int)reader["Quantity"],
                    Price = (decimal)reader["Price"]
                });
            }

            cmd.Dispose();
            conn.Close();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand("SELECT * FROM Products WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();

            if (!reader.Read()) return NotFound();

            var product = new Product
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString()!,
                Quantity = (int)reader["Quantity"],
                Price = (decimal)reader["Price"]
            };

            cmd.Dispose();
            conn.Close();


            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || product.Quantity < 0 || product.Price < 0)
                return BadRequest("Invalid data.");

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand(@"
              SET IDENTITY_INSERT Products ON;

              INSERT INTO Products (Id, Name, Quantity, Price)
              VALUES (@Id, @Name, @Quantity, @Price);

              SET IDENTITY_INSERT Products OFF;
             ", conn);

            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Price", product.Price);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();


            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

    }
}

