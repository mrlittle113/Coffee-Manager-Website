using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShops.Models;

namespace CoffeeShops.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //get list
        public JsonResult listEmployee()
        {
            string data = Request.QueryString["p_id"] + "server received!";
            dacnEntities db = new dacnEntities();
            List<employees> list = db.employees.ToList();
            List<Json_employee> json_list = new List<Json_employee>();
            //
            foreach (employees emp in list)
            {
                Json_employee jt = new Json_employee()
                {

                    id = emp.id,
                    username = emp.username,
                    password = emp.password,
                    name = emp.name,
                    date_of_birth = emp.date_of_birth,
                    phone_number = emp.phone_number,
                    address = emp.address,
                    role = emp.role,
                    salary_rate = emp.salary_rate,
                    store_id = emp.store_id,
                    joined_date = emp.joined_date
                };

                json_list.Add(jt);
            }



            return Json(json_list, JsonRequestBehavior.AllowGet);
        }
        //add
        public JsonResult addEmployee()
        {
            dacnEntities db = new dacnEntities();

            string username = Request.QueryString["usename"];
            string password = Request.QueryString["password"];
            string name = Request.QueryString["name"];
            string dateofbirth = Request.QueryString["dateofbirth"];
            string phonenumber = Request.QueryString["phonenumber"];
            string address = Request.QueryString["address"];
            string role = Request.QueryString["role"];
            string salaryrate = Request.QueryString["salaryrate"];
            string storeid = Request.QueryString["storeid"];


            int generatedID = 0;
            if (db.employees.Count() == 0)
            {
                generatedID = 0;
            }
            else
            {
                List<employees> list = db.employees.ToList();
                generatedID = list[db.employees.Count() - 1].id + 1;
            }
            //assign value
            employees emp = new employees();
            emp.id = generatedID;
            emp.username = username;
            emp.password = password;
            emp.name = name;
            emp.date_of_birth = Convert.ToDateTime(dateofbirth);
            emp.phone_number = phonenumber;
            emp.address = address;
            emp.role = Int32.Parse(role);
            emp.salary_rate = Int32.Parse(salaryrate);
            emp.store_id = Int32.Parse(storeid);
            emp.joined_date = System.DateTime.Now;


            db.employees.Add(emp);
            db.SaveChanges();

            return Json("added" + name, JsonRequestBehavior.AllowGet);
        }

        // remove
        public JsonResult deleteEmployee()
        {
            string id = Request.QueryString["id"];
            dacnEntities db = new dacnEntities();



            employees empDel = db.employees.Find(Int32.Parse(id));
            db.employees.Remove(empDel);
            db.SaveChanges();


            return Json("removed the employee with id: " + id, JsonRequestBehavior.AllowGet);
        }

        //edit 
        public JsonResult editEmployee()
        {


            try
            {
                string id = Request.QueryString["id"];
                dacnEntities db = new dacnEntities();
                employees emp = new employees();
                emp.id = Int32.Parse(id);


                employees employee = db.employees.Find(emp.id);

                string newPassword = Request.QueryString["newPassword"];
                string newPhone = Request.QueryString["newPhone"];
                string newAddress = Request.QueryString["newAddress"];
                string newRole = Request.QueryString["newRole"];
                string newSalaryRate = Request.QueryString["newSalaryRate"];
                string newStoreId = Request.QueryString["newStoreId"];

                if (newPassword == null) { }
                else { employee.password = newPassword; }

                if (newPhone == null) { }
                else { employee.phone_number = newPhone; }

                if (newAddress == null) { }
                else { employee.address = newAddress; }

                if (newRole == null) { }
                else { employee.role = Int32.Parse(newRole); }

                if (newSalaryRate == null) { }
                else { employee.salary_rate = Int32.Parse(newSalaryRate); }

                if (newStoreId == null) { }
                else { employee.store_id = Int32.Parse(newStoreId); }

                db.SaveChanges();

                return Json("edit employee with id: " + employee.id, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }
        public class Json_employee
        {
            public int id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string name { get; set; }
            public System.DateTime date_of_birth { get; set; }
            public string phone_number { get; set; }
            public string address { get; set; }
            public Nullable<int> role { get; set; }
            public Nullable<int> salary_rate { get; set; }
            public Nullable<int> store_id { get; set; }
            public System.DateTime joined_date { get; set; }
        }
    }
}