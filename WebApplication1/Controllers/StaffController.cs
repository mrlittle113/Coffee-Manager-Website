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
            int generatedId = 0;
            //
            if (db.invoices.Count() != 0)
            {
                List<invoices> list = db.invoices.ToList();
                generatedId = list[db.invoices.Count() - 1].id + 1;
            }           
            //
            invoices invoices = new invoices
            {

                id = generatedId,
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
            //
            int invoice_id = int.Parse(Request.QueryString["current_invoice"]);
            int quantity = int.Parse(Request.QueryString["quantity"]);
            int product_id = int.Parse(Request.QueryString["p_id"]);
            //
            dacnEntities db = new dacnEntities();
            //
            int generatedId = 0;
            //
            if (db.invoice_detail.Count() != 0)
            {
                List<invoice_detail> list = db.invoice_detail.ToList();
                generatedId = list[db.invoice_detail.Count() - 1].id + 1;
            }           
            //
            invoice_detail invoice_Detail = new invoice_detail()
            {
                id = generatedId,
                product_id = product_id,
                quantity = quantity,
                invoice_id = invoice_id
            };
            //
            db.invoice_detail.Add(invoice_Detail);
            db.SaveChanges();
            return Json(invoice_Detail.id, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getInvoiceDetail()
        {
            int id = int.Parse(Request.QueryString["id"]);
            dacnEntities db = new dacnEntities();
            invoice_detail invoiceDetailFromDb = db.invoice_detail.Find(id);
            Json_invoice_detail json_Invoice_Detail = new Json_invoice_detail()
            {
                id = invoiceDetailFromDb.id,
                product_id = (int)invoiceDetailFromDb.product_id,
                quantity = (int)invoiceDetailFromDb.quantity,
                invoice_id = (int)invoiceDetailFromDb.invoice_id
            };
            //
           
            //
            return Json(json_Invoice_Detail, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getProduct()
        {

            int id = int.Parse(Request.QueryString["product_id"]);
            dacnEntities db = new dacnEntities();
            //
            products productsFromDb = db.products.Find(id);
            Json_product json_Product = new Json_product()
            {
                id = productsFromDb.id,
                name = productsFromDb.name,
                formular = productsFromDb.formular,
                price = (int)productsFromDb.price
            };
            return Json(json_Product, JsonRequestBehavior.AllowGet);
        }
        public JsonResult removeDetail()
        {
            int id = int.Parse(Request.QueryString["id"]);
            int toMinus = 0;
            dacnEntities db = new dacnEntities();
            //
            toMinus = (int) db.invoice_detail.Find(id).quantity * (int) db.invoice_detail.Find(id).products.price;
            db.invoice_detail.Remove(db.invoice_detail.Find(id));
            db.SaveChanges();
            return Json(toMinus, JsonRequestBehavior.AllowGet);
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
    public class Json_invoice_detail
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int invoice_id { get; set; }
        public int quantity { get; set; }
    }
}