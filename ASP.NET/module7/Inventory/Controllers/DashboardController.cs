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
        public ActionResult Delete(string ID)
        {
            EquipmentList obj = new EquipmentList();
            obj.DeleteRow(int.Parse(ID));
            return RedirectToAction("Index", "Dashboard");
        }

    } 
        
    }