﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeManagerController : Controller
    {
        // GET: EmployeeManager
        public ActionResult Index()
        {
            return View();
        }
    }
}