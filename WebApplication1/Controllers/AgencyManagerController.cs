using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AgencyManagerController : Controller
    {
        // GET: AgencyManager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShiftManagement()
        {
            return View("ShiftManagement");
        }
    }
}