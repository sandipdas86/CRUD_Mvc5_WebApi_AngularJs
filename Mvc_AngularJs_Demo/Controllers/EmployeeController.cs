using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_AngularJs_Demo.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
	}
}