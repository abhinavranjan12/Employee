using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Models.loginModels
{
	public class LoginEntity
	{
		public int userId { get; set; }
		public string userName { get; set; }
		public string password { get; set; }
		public string role { get; set; }

		
	}
}