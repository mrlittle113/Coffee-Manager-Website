using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShops.Models;
using WebApplication1.Controllers;

namespace CoffeeShops.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        // get list
        public JsonResult getList()
        {
            string data = Request.QueryString["p_id"] + "server received!";
            dacnEntities db = new dacnEntities();
            List<products> list = db.products.ToList();
            List<Json_Product> json_list = new List<Json_Product>();

            foreach (products pt in list)
            {
                Json_Product jp = new Json_Product()
                {

                    id = pt.id,
                    name = pt.name,
                    formular = pt.formular,
                    price = pt.price,
                    type_id = pt.type_id
                };

                json_list.Add(jp);
            }
            return Json(json_list, JsonRequestBehavior.AllowGet);
        }
        //add 
        public JsonResult addProduct()
        {
            dacnEntities db = new dacnEntities();

            string name = Request.QueryString["name"];
            string formular = Request.QueryString["formular"];
            int price = int.Parse(Request.QueryString["price"]);
            string type_id = Request.QueryString["type_id"];

            int generatedID = 0;
            if (db.products.Count() == 0)
            {
                generatedID = 0;
            }
            else
            {
                List<products> list = db.products.ToList();
                generatedID = list[db.products.Count() - 1].id + 1;
            }

            //assign value
            products product = new products();
            product.id = generatedID;
            product.name = name;
            product.formular = formular;
            product.type_id = int.Parse(type_id);
            product.price = price;


            db.products.Add(product);
            db.SaveChanges();
            return Json("added" + name, JsonRequestBehavior.AllowGet);
        }
        //remove
        public JsonResult removeProduct()
        {
            string id = Request.QueryString["id"];
            dacnEntities db = new dacnEntities();
            products productDel = db.products.Find(Int32.Parse(id));
            db.products.Remove(productDel);
            db.SaveChanges();


            return Json("removed the employee with id: " + id, JsonRequestBehavior.AllowGet);
        }
        //edit 
        public JsonResult editProduct()
        {
            try
            {
                string id = Request.QueryString["id"];
                dacnEntities db = new dacnEntities();

                products pr = db.products.Find(Int32.Parse(id));

                string newname = Request.QueryString["newname"];
                string newformular = Request.QueryString["newformular"];
                string newprice = Request.QueryString["newprice"];
                string newtypeid = Request.QueryString["newtypeid"];


                if (newname == null) { }
                else { pr.name = newname; }

                if (newformular == null) { }
                else { pr.formular = newformular; }

                if (newprice == null) { }
                else { pr.price = Int32.Parse(newprice); }

                if (newtypeid == null) { }
                else { pr.type_id = Int32.Parse(newtypeid); }



                db.SaveChanges();

                return Json("edit product with id: " + id, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e) { Console.WriteLine(e); }

            return null;
        }

        public class Json_Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string formular { get; set; }
            public Nullable<int> price { get; set; }
            public Nullable<int> type_id { get; set; }
        }
    }
}