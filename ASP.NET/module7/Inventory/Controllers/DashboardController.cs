using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;

namespace Inventory.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            EquipmentList equipmentList = new EquipmentList();
            List<EquipmentList> list = equipmentList.equipmentLists();
            ViewBag.EquipmentList = list;

            return View();
        }
        [HttpPost]
        public ActionResult Index(string btnSubmit, string EquipmentID, FormCollection formCollection)
        {
            EquipmentList obj = new EquipmentList();
            if (btnSubmit == "Delete")
            {
                obj.DeleteRow(int.Parse(EquipmentID));  
            }
            else if (btnSubmit == "Save")
            {
                if (obj.checkValidity(Convert.ToInt32(formCollection["EquipmentID"].ToString())))
                {
                    ViewBag.Message = "ID already exist";
                }
                else
                {
                    obj.Equipmentid = Convert.ToInt32(formCollection["EquipmentID"].ToString());
                    obj.EquipmentName = formCollection["txtName"].ToString();
                    obj.Quantity = Convert.ToInt32(formCollection["txtQuantity"].ToString());
                    obj.EntryDate = Convert.ToDateTime(formCollection["txtEntryDate"].ToString());
                    obj.EndDate = Convert.ToDateTime(formCollection["txtEndDate"].ToString());
                    obj.SaveEquipment(Convert.ToInt32(formCollection["choice"].ToString()));
                }
            }
            else if (btnSubmit == "Update")
            {
                obj.Equipmentid = Convert.ToInt32(formCollection["EquipmentID"].ToString());
                obj.EquipmentName = formCollection["txtName"].ToString();
                obj.Quantity = Convert.ToInt32(formCollection["txtQuantity"].ToString());
                obj.EntryDate = Convert.ToDateTime(formCollection["txtEntryDate"].ToString());
                obj.EndDate = Convert.ToDateTime(formCollection["txtEndDate"].ToString());
                obj.SaveEquipment(Convert.ToInt32(formCollection["choice"].ToString()));
            }

            EquipmentList equipmentList = new EquipmentList();
            List<EquipmentList> list = equipmentList.equipmentLists();
            ViewBag.EquipmentList = list;

            return View();
        }

        public ActionResult NewAssignedEquipment()
        {
            EquipmentList equipmentList= new EquipmentList();
            List<EquipmentList> list = equipmentList.equipmentLists();

            Customer customer = new Customer();
            List<Customer> customerList = customer.CustomerList();



            ViewBag.lstEquipment = list;
            ViewBag.customerList = customerList;
            return View();
        }
        [HttpPost]
        public ActionResult NewAssignedEquipment(FormCollection formCollection)
        {
            
            return View();
        }

    }
}
        
    