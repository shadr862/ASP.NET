using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;

namespace Inventory.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtUsername, string txtPassword)
        {

            User obj = new User();
            DataTable dt = obj.LoginSp(txtUsername, txtPassword);
            if (dt.Rows.Count > 0)
            {
                //foreach (DataRow row in dt.Rows)
                //{
                //    int id = int.Parse(row["Id"].ToString());
                //    string name = row["Name"].ToString();
                //    string Pass = row["Password"].ToString();
                //    if (name == txtUsername && Pass == txtPassword)
                //    {
                //        return Redirect(Url.Action("Index", "Home"));
                //    }

                //}
                ViewBag.UserName = txtUsername;
                Session["UserName"] = txtUsername;
                return Redirect(Url.Action("Index", "Dashboard"));
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("UserName");
            return Redirect(@Url.Action("Login", "Auth"));
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string UserName,string Password,string Age,string Role,string ServiceType)
        {
            User obj = new User();
            if (obj.CheckUserName(UserName))
            {
                ViewBag.UserName = "Username already Exist";
                return View();
            }
            obj.SignUpSp(UserName, Password, int.Parse(Age), Role, ServiceType);
            return Redirect(@Url.Action("Login","Auth"));
        }

        public ActionResult Forget()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forget(string UserName,string NPassword, string CPassword)
        {
            User obj = new User();
            if (!obj.CheckUserName(UserName))
            {
                ViewBag.Message = "Username doesnot Exist";
                return View();
            }
            else if (NPassword != CPassword)
            {
                ViewBag.Message = "Password are not matching";
                return View();
            }
            
            obj.ForgetSp(UserName, NPassword);

            return Redirect(Url.Action("Login","Auth"));
        }
    }
}