using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Manager_Table.Models;
using Employee_Manager_Table.Models.Entity;

namespace Employee_Manager_Table.Controllers
{
	[RoutePrefix("employee")]
	public class Employee_ManagerController : Controller
    {

		private Model model;


		public Employee_ManagerController()
		{
			model = new Model();
		}
		// GET: Employee_Manager
		public ActionResult Index()
        {
            return View();
        }

		[Route("user1")]
		[HttpGet]
		// GET api/values
		public List<Entity> Get()
		{
			return model.GetEmployees();
		}



	}
}