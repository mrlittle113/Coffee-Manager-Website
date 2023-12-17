using CoffeeShops.Models;
using CoffeeShops.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AgencyManagerController : Controller
    {
        // GET: AgencyManager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShiftManagement()
        {
            return View("ShiftManagement");
        }
        public ActionResult StorageManagement()
        {
            int id = int.Parse(Request.QueryString["id"]);
            List<Employee> list = new List<Employee>();
            //
            dacnEntities db = new dacnEntities();
            foreach (employees entity in db.employees.ToList())
            {
                if (entity.store_id == id)
                {
                    list.Add(Employee.JsonConvert(entity));
                }

            }
            ViewData.Add("list", Json(list, JsonRequestBehavior.AllowGet));
            return View("StorageManagement");
        }
    }
}