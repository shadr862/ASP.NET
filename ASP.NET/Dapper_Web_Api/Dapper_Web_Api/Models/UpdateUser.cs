namespace Dapper_Web_Api.Models
{
    public class UpdateUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get;set; }
    }
}
