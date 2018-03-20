using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Employee.Models.Entity;

namespace Employee.Models.loginModels
{
	public class LoginModel
	{
		string con = string.Empty;
		public EmployeeEntity entity = new EmployeeEntity();



		public LoginModel()
		{
			con = ConfigurationManager.ConnectionStrings["employeeConnection"].ToString();
		}

		public EmployeeEntity GetLogin(string role)
		{

			using (var sqlCon = new SqlConnection(con))
			{
				var employees = new EmployeeEntity();
				sqlCon.Open();
				var command = new SqlCommand("Select Id,UserName ,Password,Role from Employees where Role=@role", sqlCon);
				command.Parameters.AddWithValue("@role", role);

				using (var reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						employees = new EmployeeEntity
						{
							Id = reader.GetInt32(0),
							//FirstName = reader.GetString(1),
							//LastName = reader.GetString(2),
							//Active = reader.GetBoolean(3),
							UserName = reader["UserName"].ToString(),
							Password = reader["Password"].ToString(),
							Role = reader["Role"].ToString()
							//Mobile = reader.GetString(6),
							//Address1 = reader.GetString(7),
							//Address2 = reader.GetString(8),
							//City = reader.GetString(9),
							//State = reader.GetString(10),
							//Zip = reader.GetString(11),
							//Dob = reader.GetDateTime(12),
							//	JoiningDate = reader.GetDateTime(13),
							//	ManagerId = reader.GetInt32(14),
							//	ActiveEmp = reader.GetBoolean(15),
							//	PrimaryManager = reader.GetBoolean(16),
							//	ManagerName = reader.GetString(17),



						};
					}
					
				}
				return employees;
			}
		}

		internal EmployeeEntity GetLogin()
		{
			throw new NotImplementedException();
		}
	}
}