using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using CoffeeShops.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Auth()
        {
            String user = Request.QueryString["username"];
            String pass = Request.QueryString["password"];
            if (Auth(user,pass))
            {
                return RedirectToAction("Overview", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        private bool Auth(String user,String pass)
        {
            using (dacnEntities db = new dacnEntities())
            {
                String emp_id = db.Database.SqlQuery<String>("select id from employees where username = @u",new SqlParameter("@u",user)).FirstOrDefault();
                employees emp = db.employees.Find(emp_id);
                if (emp.Equals(null))
                {
                    return false;
                }
                else
                {
                    if (emp.password.Equals(pass))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}