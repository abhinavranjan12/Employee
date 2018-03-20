using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Models.Entity
{
	/// <summary>
	/// 
	/// </summary>
	public class EmployeeEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool Active { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Mobile { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set;}
		public string Zip { get; set; }
		public DateTime Dob { get; set; }
		public DateTime JoiningDate { get; set; }
		public string Role { get; set; }
		
		public int ManagerId { get; set; }
		public bool ActiveEmp { get; set; }
		public bool PrimaryManager { get; set; }
		public string ManagerName { get; set; }
		//public byte[] image { get; set; }

	}
}