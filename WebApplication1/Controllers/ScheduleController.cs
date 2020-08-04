using CoffeeShops.Models;
using CoffeeShops.Models.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShops.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule        
        public JsonResult getEmpByStore()
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
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getWeekByStore()
        {
            int id = int.Parse(Request.QueryString["id"]);
            dacnEntities db = new dacnEntities();
            List<Week> weeks = new List<Week>();
            foreach(shifts_week entity in db.shifts_week.ToList())
            {
                if(entity.store_id == id)
                {
                    weeks.Add(Week.JsonConvert(entity));
                }
            }
            return Json(weeks, JsonRequestBehavior.AllowGet);
        }
        //
        public JsonResult getAssignByWeek()
        {
            int id = int.Parse(Request.QueryString["id"]);
            dacnEntities db = new dacnEntities();
            List<Assign> assigns = new List<Assign>();
            foreach (assign_shifts entity in db.assign_shifts.ToList())
            {
                if (entity.week_id == id)
                {
                    assigns.Add(Assign.JsonConvert(entity));
                }
            }
            return Json(assigns, JsonRequestBehavior.AllowGet);
        }
        public void addAssign()
        {
            int week_id = int.Parse(Request.QueryString["week_id"]);
            int shift_id = int.Parse(Request.QueryString["shift_id"]);
            int emp_id = int.Parse(Request.QueryString["emp_id"]);
            //
            dacnEntities db = new dacnEntities();
            int generatedId = 0;
            if (db.assign_shifts.Count() != 0)
            {
                List<assign_shifts> list = db.assign_shifts.ToList();
                generatedId = list[db.assign_shifts.Count() - 1].id + 1;
            }
            //
            assign_shifts thisToDb = new assign_shifts()
            {
                id=generatedId,
                week_id = week_id,
                shift_id = shift_id,
                employee_id = emp_id
            };
            db.assign_shifts.Add(thisToDb);
            db.SaveChanges();
        }
    }
}