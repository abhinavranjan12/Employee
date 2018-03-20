using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Employee_Manager_Table.Models.Entity;

namespace Employee_Manager_Table.Models
{
	public class Model
	{
		string con = string.Empty;
		


		public Model()
		{
			con = ConfigurationManager.ConnectionStrings["employeeConnection"].ToString();
		}

		internal List<Entity.Entity> GetEmployees()
		{
			var employees = new List<Entity.Entity>();
			using (var sqlCon = new SqlConnection(con))
			{
				sqlCon.Open();
				var command = new SqlCommand(@"SELECT EmpId, EmpName,ActiveEmp FROM  EmpTable  INNER JOIN EmpManager ON EmpTable.EmpId = EmpManager.EmpId", sqlCon);
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						employees.Add(new Entity.Entity
						{
							 EmpId = reader.GetInt32(0),
							EmpName = reader.GetString(1),
							ActiveEmp = reader.GetBoolean(2),
							//ManagerId = reader.GetInt32(3),
						//	Active = reader.GetBoolean(4),
						//	PrimaryManager = reader.GetBoolean(5)


						});
					}
				}
				return employees;
			}
		}
	}
}