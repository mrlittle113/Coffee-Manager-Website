using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class OverallManagerController : Controller
    {
        // GET: OverallManager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgencyDetail()
        {
            return View();
        }
        public ActionResult Finance()
        {
            return View();
        }
    }
}