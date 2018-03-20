using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class AddEmployeesController : Controller
    {
        // GET: AddEmployees
        public ActionResult Index(int id = 0)
        {
            return View();
        }


	}
}