using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShops.Models;
namespace CoffeeShops.Controllers
{
    public class WarehouseController : Controller
    {
        // GET: Warehouse
        public ActionResult Index()
        {
            return View();
        }

        //get list
        public JsonResult listWarehouse()
        {
            string data = Request.QueryString["p_id"] + "server received!";
            dacnEntities db = new dacnEntities();
            List<warehouses> list = db.warehouses.ToList();
            List<Json_warehouse> json_list = new List<Json_warehouse>();
            //
            foreach (warehouses wrh in list)
            {
                Json_warehouse jt = new Json_warehouse()
                {

                    id = wrh.id,
                    store_id = wrh.store_id,
                    ingredient_id = wrh.ingredient_id,
                    quantity = wrh.quantity,

                };

                json_list.Add(jt);
            }



            return Json(json_list, JsonRequestBehavior.AllowGet);
        }
        //add
        public JsonResult addEmployee()
        {
            dacnEntities db = new dacnEntities();

            string store_id = Request.QueryString["store_id"];
            string ingredient_id = Request.QueryString["ingredient_id"];
            string quantity = Request.QueryString["quantity"];
            string ingredients = Request.QueryString["ingredients"];
            string stores = Request.QueryString["stores"];



            int generatedID = 0;
            if (db.employees.Count() == 0)
            {
                generatedID = 0;
            }
            else
            {
                List<warehouses> list = db.warehouses.ToList();
                generatedID = list[db.warehouses.Count() - 1].id + 1;
            }
            //assign value
            warehouses warehouse = new warehouses();
            warehouse.id = generatedID;
            warehouse.store_id = Int32.Parse(store_id);
            warehouse.ingredient_id = Int32.Parse(ingredient_id);
            warehouse.quantity = Int32.Parse(quantity);





            db.warehouses.Add(warehouse);
            db.SaveChanges();

            return Json("added", JsonRequestBehavior.AllowGet);
        }

        // remove
        public JsonResult deleteEmployee()
        {
            string id = Request.QueryString["id"];
            dacnEntities db = new dacnEntities();



            warehouses warehouseDel = db.warehouses.Find(Int32.Parse(id));
            db.warehouses.Remove(warehouseDel);
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

                warehouses wrh = db.warehouses.Find(Int32.Parse(id));

                string newStoreId = Request.QueryString["newStoreId"];
                string newIngredientId = Request.QueryString["newIngredientId"];
                string newQuantity = Request.QueryString["newQuantity"];


                if (newStoreId == null) { }
                else { wrh.store_id = Int32.Parse(newStoreId); }

                if (newIngredientId == null) { }
                else { wrh.ingredient_id = Int32.Parse(newIngredientId); }

                if (newQuantity == null) { }
                else { wrh.quantity = Int32.Parse(newQuantity); }



                db.SaveChanges();

                return Json("edit warehouse with id: " + id, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e) { Console.WriteLine(e); }

            return null;
        }

        public class Json_warehouse
        {
            public int id { get; set; }
            public Nullable<int> store_id { get; set; }
            public Nullable<int> ingredient_id { get; set; }
            public Nullable<int> quantity { get; set; }
        }
    }
}
