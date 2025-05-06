using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(IFormCollection form)
        {
            // You can access form values like this
            var firstName = form["firstName"];
            var lastName = form["lastName"];
            var email = form["email"];
            var password = form["password"];
            var confirmPassword = form["confirmPassword"];
            var gender = form["gender"];
            var role = form["role"];

            // Process the form data here

            return RedirectToAction("RegistrationSuccess"); // Redirect to another page
        }
    }
}
