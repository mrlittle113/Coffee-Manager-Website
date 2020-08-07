using CoffeeShops.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

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
            string user = Request.QueryString["username"];
            string pass = Request.QueryString["password"];
            if (Auth(user, pass))
            {
                employees emp = (employees)Session["user"];
                switch ((int)emp.role)
                {
                    case 1:
                        return RedirectToAction("Index", "OverallManager");
                       
                    case 2:
                        return RedirectToAction("Index", "AgencyManager");
                       
                    case 3:
                        return RedirectToAction("Index", "Staff");
                    default:
                        return RedirectToAction("Index", "Login");
                }             
            }
            else
            {
                ViewBag.fail = true;
                return View("Index");
            }
        }
        private bool Auth(string user, string pass)
        {
            using (dacnEntities db = new dacnEntities())
            {
                int emp_id = db.Database.SqlQuery<int>("select id from employees where username = @u", new SqlParameter("@u", user)).FirstOrDefault();
                employees emp = db.employees.Find(emp_id);
                if (emp == null)
                {
                    return false;
                }
                else
                {
                    if (emp.password.Equals(pass))
                    {
                        Session.Add("user", emp);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public ActionResult logOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }




        public ActionResult accessDenied()
        {

            ViewBag.error = "ACCESS DENIED";
            return View("Error");
        }
    }
}