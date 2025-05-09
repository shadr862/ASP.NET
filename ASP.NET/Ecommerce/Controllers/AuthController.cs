using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;


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
            User obj = new User();
            obj.Registration(form);

            return RedirectToAction("Login", "Auth"); // Redirect to another page  
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            User user = new User();
            string FirstName = form["Email"].ToString().Split('@')[0];

            if (user.LoginCheck(form))
            {
                // Directly using HttpContext.Session
                HttpContext.Session.SetString("FirstName", FirstName);
                return RedirectToAction("UserDashboard");
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword( IFormCollection form)
        { 
            User obj=new User();
            string email=form["Email"].ToString();
            string password=form["Password"].ToString();
            if(obj.ForgotPasswordCheck(email))
            {
                if(obj.UpdatePassword(email,password))
                {
                    ViewBag.message = "Successfully change the password";
                }
                return View();
            }

            ViewBag.message = "Your email is not exist";
            return View();
        }

        public IActionResult UserDashboard()
        {
            User obj=new User();
            List<User> users = obj.GetUserData();
            ViewBag.Users = users;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}

