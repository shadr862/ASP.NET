using ClassroomApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetToken/{ValidKey}")]
        public IActionResult GetToken(string ValidKey)
        {
            if (ValidKey == "Riaz")
                return Ok(ServiceToken.GenerateServiceToken(_configuration));
            else
                return Unauthorized();
        }
    }
}
