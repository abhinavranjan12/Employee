using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee.Models;
using Employee.Models.Entity;
using Employee.Models.loginModels;

namespace Employee.Controllers
{
	[RoutePrefix("userlogin")]
	public class UserLoginController : Controller
    {

		private LoginModel model;


		public UserLoginController()
		{
			model = new LoginModel();
		}
		// GET: UserLogin
		public ActionResult Index()
		{
			return View();
		}

		[Route("getlogin")]
		[HttpGet]
		public EmployeeEntity GetLogin(string role)
		{
			return model.GetLogin(role);
		}
	}
}