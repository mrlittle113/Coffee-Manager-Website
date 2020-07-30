using CoffeeShops.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class StaffController : Controller
    {

        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Order()
        {

            dacnEntities db = new dacnEntities();
            List<product_type> list = db.product_type.ToList();
            ViewBag.listType = list;
            return View();
        }
        public JsonResult newInvoice()
        {
            dacnEntities db = new dacnEntities();
            //
            employees emp = (employees)Session["user"];
            invoices invoices = new invoices
            {
                id = db.invoices.Count(),
                created_date = System.DateTime.Now,
                employee_id = emp.id,
                invoice_status = db.invoice_status.Find(4),
                store_id = emp.store_id
            };
            db.invoices.Add(invoices);
            db.SaveChanges();
            //           
            return Json(new { invoice_id = invoices.id, status = invoices.invoice_status.name }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult addInvoiceDetail()
        {
            string data = Request.QueryString["p_id"] + "server received!";




            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Info()
        {
            return View();
        }
    }

    internal class Json_type
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Json_product> list_products { get; set; }
    }

    public class Json_product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string formular { get; set; }
        public int price { get; set; }
    }
}