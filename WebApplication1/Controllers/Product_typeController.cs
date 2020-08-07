using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShops.Models;

namespace CoffeeShops.Controllers
{
    public class Product_typeController : Controller
    {
        // GET: Product_type
        public ActionResult Index()
        {
            return View();
        }
        //get list
        public JsonResult listProductType()
        {
            string data = Request.QueryString["p_id"] + "server received!";
            dacnEntities db = new dacnEntities();
            List<product_type> list = db.product_type.ToList();
            List<Json_type> json_list = new List<Json_type>();
            //
            foreach (product_type pt in list)
            {
                Json_type jt = new Json_type()
                {

                    id = pt.id,
                    name = pt.name,
                    list_products = new List<Json_product>()
                };

                json_list.Add(jt);
            }



            return Json(json_list, JsonRequestBehavior.AllowGet);
        }
        //add
        public JsonResult addType()
        {
            string name = Request.QueryString["name"];
            dacnEntities db = new dacnEntities();
            product_type pt = new product_type();

            int generatedID = 0;
            if (db.product_type.Count() == 0)
            {
                generatedID = 0;
            }
            else
            {
                List<product_type> list = db.product_type.ToList();
                generatedID = list[db.product_type.Count() - 1].id + 1;
            }
            pt.id = generatedID;
            pt.name = name;

            db.product_type.Add(pt);
            db.SaveChanges();

            return Json("added" + name, JsonRequestBehavior.AllowGet);
        }

        // remove
        public JsonResult deleteType()
        {
            string id = Request.QueryString["id"];
            dacnEntities db = new dacnEntities();



            product_type pr_type = db.product_type.Find(Int32.Parse(id));
            db.product_type.Remove(pr_type);
            db.SaveChanges();


            return Json("removed the product with id: " + id, JsonRequestBehavior.AllowGet);
        }

        //edit chua lam
        public JsonResult editType()
        {
            try
            {
                string id = Request.QueryString["id"];
                dacnEntities db = new dacnEntities();

                product_type pr_type = db.product_type.Find(Int32.Parse(id));

                string newName = Request.QueryString["newName"];


                if (newName == null) { }
                else { pr_type.name = newName; }



                db.SaveChanges();

                return Json("edit employee with id: " + id, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e) { Console.WriteLine(e); }

            return null;
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


}
