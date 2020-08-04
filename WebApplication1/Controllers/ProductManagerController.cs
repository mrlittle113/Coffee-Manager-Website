using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShops.Models;

namespace CoffeeShops.Controllers
{
    public class ProductManagerController : Controller
    {
        // GET: ProductManager
        public ActionResult Index()
        {
            dacnEntities db = new dacnEntities();
            List<product_type> product_Types = db.product_type.ToList();
            //
            ViewBag.listTypes = product_Types;
            return View();
        }
        
    }
}