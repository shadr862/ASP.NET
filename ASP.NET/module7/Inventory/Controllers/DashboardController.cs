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
            else if(btnSubmit == "Save")
            {
                obj.Equipmentid = Convert.ToInt32(formCollection["EquipmentID"].ToString());
                obj.EquipmentName = formCollection["txtName"].ToString();
                obj.Quantity = Convert.ToInt32(formCollection["txtQuantity"].ToString());
                obj.EntryDate = Convert.ToDateTime(formCollection["txtEntryDate"].ToString());
                obj.EndDate = Convert.ToDateTime(formCollection["txtEndDate"].ToString());
                obj.SaveEquipment();
            }
            else if (btnSubmit == "Update")
            {
                obj.Equipmentid = Convert.ToInt32(formCollection["EquipmentID"].ToString());
                obj.EquipmentName = formCollection["txtName"].ToString();
                obj.Quantity = Convert.ToInt32(formCollection["txtQuantity"].ToString());
                obj.EntryDate = Convert.ToDateTime(formCollection["txtEntryDate"].ToString());
                obj.EndDate = Convert.ToDateTime(formCollection["txtEndDate"].ToString());
                obj.SaveEquipment();
            }

            EquipmentList equipmentList = new EquipmentList();
            List<EquipmentList> list = equipmentList.equipmentLists();
            ViewBag.EquipmentList = list;

            return View();
        }
       
    } 
        
    }