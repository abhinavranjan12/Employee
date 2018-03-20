using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Manager_Table.Models.Entity
{
	public class Entity
	{
		public int EmpId { get; set; }
		public string EmpName { get; set; }
		public bool ActiveEmp { get; set; }
		public int ManagerId { get; set; }
		public bool Active { get; set; }
		public bool PrimaryManager { get; set; }
	}
}