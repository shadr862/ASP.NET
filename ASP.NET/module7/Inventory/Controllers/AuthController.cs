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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtUsername, string txtPassword)
        {

            /*
            User obj = new User();
            DataTable dt= obj.ValidateMemberAsDataTable(txtUsername, txtPassword);
            if(dt.Rows.Count>0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    int id = int.Parse(row["Id"].ToString());
                    string name = row["Name"].ToString();
                    string Pass = row["Password"].ToString();
                    if(name==txtUsername && Pass==txtPassword)
                    {
                        return Redirect(Url.Action("Index", "Home"));
                    }
                    
                }
                ViewBag.UserName = txtUsername;
                Session["UserName"] = txtUsername;
                return Redirect(Url.Action("About", "Home"));
            }
            */

            User obj = new User();
            DataTable dt = obj.ValidateMemberAsDataTableBySp(txtUsername, txtPassword);
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
            /*
            User obj = new User();
            List<User> list = obj.ValidateMemberAsList();
            bool status = false;
            foreach (User member in list)
            {
                if (member.Name == txtUsername && member.Password == txtPassword)
                {
                    status = true;
                    break;
                }
            }
            ViewBag.UserName = txtUsername;
            Session["UserName"] = txtUsername;
            if (status)
            {
                return Redirect(Url.Action("About", "Home"));
            }
            */
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("UserName");
            return Redirect(@Url.Action("Login", "Auth"));
        }
    }
}