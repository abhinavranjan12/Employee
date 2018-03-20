using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Employee.Models.Entity;

namespace Employee.Models
{
	public class EmployeeManagerModel
	{
		string con = string.Empty;
		public EmployeeEntity entity = new EmployeeEntity();



		public EmployeeManagerModel()
		{
			con = ConfigurationManager.ConnectionStrings["employeeConnection"].ToString();
		}

		public List<EmployeeEntity> GetEmployees()
		{
			var employees = new List<EmployeeEntity>();



			using (var sqlCon = new SqlConnection(con))
			{
				sqlCon.Open();
				var command = new SqlCommand("Select * from Employees", sqlCon);
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						employees.Add(new EmployeeEntity
						{
							Id = reader.GetInt32(0),
							FirstName = reader.GetString(1),
							LastName = reader.GetString(2),
							Active = reader.GetBoolean(3),
							UserName = reader.GetString(4),
							Password = reader.GetString(5),
							Mobile = reader.GetString(6),
							Address1 = reader.GetString(7),
							Address2 = reader.GetString(8),
							City = reader.GetString(9),
							State = reader.GetString(10),
							Zip = reader.GetString(11),
							Dob = reader.GetDateTime(12),
							JoiningDate = reader.GetDateTime(13),
							Role = reader["Role"].ToString()


						});
					}
				}
				return employees;
			}

		}

		internal string ActivateEmployee(int id)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand("UPDATE Employees SET Active =1  where Id=@Id ", sqlCon);
				sqlCon.Open();
				command.Parameters.AddWithValue("@id", id);
				if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
				{
					return "Success";
				}
				return "something worng in insert operation. try again...";
			}
		}

		internal List<EmployeeEntity> GetEmployeeManager(int id)
		{
			var employees = new List<EmployeeEntity>();

			using (var sqlCon = new SqlConnection(con))
			{
				sqlCon.Open();
				var command = new SqlCommand("SELECT *  FROM Employees emp INNER JOIN EmployeeManager empMgr   ON emp.Id = empMgr.ManagerId  where emp.Id = @id", sqlCon);

				command.Parameters.AddWithValue("id", id);
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						employees.Add(mapEmployee(reader));
					}
				}
				return employees;
			}

		}

		internal void UpdateAssigneManager(int id, int managerId, bool primary)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand(@"Update EmployeeManager set ManagerId=@managerId,ActiveEmp=1,PrimaryManager=1 where Id= @id", sqlCon);
				sqlCon.Open();
				command.Parameters.AddWithValue("@id", id);
				command.Parameters.AddWithValue("@managerId", managerId);
			   // command.Parameters.AddWithValue("@primaryManager", primary);
				command.ExecuteNonQuery();
			}
		}

		internal string UpdateManagers(EmployeeEntity employees, int Id)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand(@"Update  Employees  set FirstName=@FirstName , LastName=@LastName , UserName=@UserName  , Mobile=@Mobile , Address1=@Address1 , Address2=@Address2 , City=@City , State=@State , Zip=@Zip , Dob=@Dob , JoiningDate=@JoiningDate ,Role=@Role where Id=@id", sqlCon);
				sqlCon.Open();
				command.Parameters.AddWithValue("@id", Id);
				command.Parameters.AddWithValue("@FirstName", employees.FirstName);
				command.Parameters.AddWithValue("@LastName", employees.LastName);
			//	command.Parameters.AddWithValue("@Active", employees.Active);
				command.Parameters.AddWithValue("@UserName", employees.UserName);
				//	command.Parameters.AddWithValue("@Password", employees.Password);

				command.Parameters.AddWithValue("@Mobile", employees.Mobile);
				command.Parameters.AddWithValue("@Address1", employees.Address1);
				command.Parameters.AddWithValue("@Address2", employees.Address2);
				command.Parameters.AddWithValue("@City", employees.City);
				command.Parameters.AddWithValue("@State", employees.State);
				command.Parameters.AddWithValue("@Zip", employees.Zip);
				command.Parameters.AddWithValue("@Dob", employees.Dob);
				command.Parameters.AddWithValue("@JoiningDate", employees.JoiningDate);
				command.Parameters.AddWithValue("@Role", employees.Role);

				if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
				{
					return "Success";
				}
				else
				{
					return "something worng in insert operation. try again...";
				}
			}
		}

		internal string AddManager(EmployeeEntity employees)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand(@"insert into Employees (FirstName,LastName,Active,UserName,Password,Mobile,Address1,Address2,City,State,Zip,Dob,JoiningDate,Role)  values(@FirstName,@LastName,1,@UserName,@Password,@Mobile,@Address1,@Address2,@City,@State,@Zip,@Dob,@JoiningDate,@Role)", sqlCon);
				sqlCon.Open();
				//command.Parameters.AddWithValue("@image", employees.image);
				command.Parameters.AddWithValue("@FirstName", employees.FirstName);
				command.Parameters.AddWithValue("@LastName", employees.LastName);
				//command.Parameters.AddWithValue("@Active", employees.Active);
				command.Parameters.AddWithValue("@UserName", employees.UserName);
				command.Parameters.AddWithValue("@Password", employees.Password);

				command.Parameters.AddWithValue("@Mobile", employees.Mobile);
				command.Parameters.AddWithValue("@Address1", employees.Address1);
				command.Parameters.AddWithValue("@Address2", employees.Address2);
				command.Parameters.AddWithValue("@City", employees.City);
				command.Parameters.AddWithValue("@State", employees.State);
				command.Parameters.AddWithValue("@Zip", employees.Zip);
				command.Parameters.AddWithValue("@Dob", employees.Dob);
				command.Parameters.AddWithValue("@JoiningDate", employees.JoiningDate);
				command.Parameters.AddWithValue("@Role", employees.Role);

				if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
				{
					return "Success";

				}
				else
				{
					return "something worng in insert operation. try again...";
				}
			}
		}



		//internal List<EmployeeEntity> GetManagerById(int id)
		//{
		//	var employees = new List<EmployeeEntity>();

		//	using (var sqlCon = new SqlConnection(con))
		//	{
		//		sqlCon.Open();
		//		var command = new SqlCommand("SELECT *  FROM Employees emp INNER JOIN EmployeeManager empMgr   ON emp.Id = empMgr.ManagerId  where emp.Id = @id", sqlCon);

		//		command.Parameters.AddWithValue("id", id);
		//		using (var reader = command.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				employees.Add(mapEmployee(reader));
		//			}
		//		}
		//		return employees;
		//	}


		//}

		internal void AssigneManager(int id, int managerId, bool primary)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand(@"Insert  EmployeeManager (EmployeeId, ManagerId, ActiveEmp, PrimaryManager ) values (@EmployeeId , @managerId, 1, @primaryManager)", sqlCon);
				sqlCon.Open();
				command.Parameters.AddWithValue("@EmployeeId", id);
				command.Parameters.AddWithValue("@managerId", managerId);
				command.Parameters.AddWithValue("@primaryManager", primary);
				command.ExecuteNonQuery();
			}
		}

		internal EmployeeEntity GetEmployees(int Id)
		{
			var employees =new EmployeeEntity();
			using (var sqlCon = new SqlConnection(con))
			{
				sqlCon.Open();
				var command = new SqlCommand("Select * from Employees Where Id=@id", sqlCon);
				command.Parameters.AddWithValue("@id", Id);
				using (var reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						employees=new EmployeeEntity
						{
							Id = reader.GetInt32(0),
							FirstName = reader.GetString(1),
							LastName = reader.GetString(2),
							Active = reader.GetBoolean(3),
							UserName = reader.GetString(4),
							Password = reader.GetString(5),
							Mobile = reader.GetString(6),
							Address1 = reader.GetString(7),
							Address2 = reader.GetString(8),
							City = reader.GetString(9),
							State = reader.GetString(10),
							Zip = reader.GetString(11),
							Dob = reader.GetDateTime(12),
							JoiningDate = reader.GetDateTime(13),
							//ManagerId = reader.GetInt32(14),
							//ActiveEmp = reader.GetBoolean(15),
							//PrimaryManager = reader.GetBoolean(16),
							//ManagerName = reader.GetString(17),



						};
					}
				}
				return employees;
			}
		}

		internal string UpdateEmployees(EmployeeEntity employees, int Id)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand(@"Update  Employees  set FirstName=@FirstName , LastName=@LastName , UserName=@UserName  , Mobile=@Mobile , Address1=@Address1 , Address2=@Address2 , City=@City , State=@State , Zip=@Zip , Dob=@Dob , JoiningDate=@JoiningDate where Id=@id", sqlCon);
				sqlCon.Open();
				command.Parameters.AddWithValue("@id", Id);
				command.Parameters.AddWithValue("@FirstName", employees.FirstName);
				command.Parameters.AddWithValue("@LastName", employees.LastName);
			//	command.Parameters.AddWithValue("@Active", employees.Active);
				command.Parameters.AddWithValue("@UserName", employees.UserName);
			//	command.Parameters.AddWithValue("@Password", employees.Password);

				command.Parameters.AddWithValue("@Mobile", employees.Mobile);
				command.Parameters.AddWithValue("@Address1", employees.Address1);
				command.Parameters.AddWithValue("@Address2", employees.Address2);
				command.Parameters.AddWithValue("@City", employees.City);
				command.Parameters.AddWithValue("@State", employees.State);
				command.Parameters.AddWithValue("@Zip", employees.Zip);
				command.Parameters.AddWithValue("@Dob", employees.Dob);
				command.Parameters.AddWithValue("@JoiningDate", employees.JoiningDate);

				if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
				{
					return "Success";
				}
				else
				{
					return "something worng in insert operation. try again...";
				}
			}
		}

		internal string AddEmployees(EmployeeEntity employees)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand(@"insert into Employees (FirstName,LastName,Active,UserName,Password,Mobile,Address1,Address2,City,State,Zip,Dob,JoiningDate)  values(@FirstName,@LastName,1,@UserName,@Password,@Mobile,@Address1,@Address2,@City,@State,@Zip,@Dob,@JoiningDate)", sqlCon);
				sqlCon.Open();
				//command.Parameters.AddWithValue("@image", employees.image);
				command.Parameters.AddWithValue("@FirstName", employees.FirstName);
				command.Parameters.AddWithValue("@LastName", employees.LastName);
				//command.Parameters.AddWithValue("@Active", employees.Active);
				command.Parameters.AddWithValue("@UserName", employees.UserName);
				command.Parameters.AddWithValue("@Password", employees.Password);
			
				command.Parameters.AddWithValue("@Mobile", employees.Mobile);
				command.Parameters.AddWithValue("@Address1", employees.Address1);
				command.Parameters.AddWithValue("@Address2", employees.Address2);
				command.Parameters.AddWithValue("@City", employees.City);
				command.Parameters.AddWithValue("@State", employees.State);
				command.Parameters.AddWithValue("@Zip", employees.Zip);
				command.Parameters.AddWithValue("@Dob", employees.Dob);
				command.Parameters.AddWithValue("@JoiningDate", employees.JoiningDate);
				
				if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
				{
					return "Success";

				}
				else
				{
					return "something worng in insert operation. try again...";
				}
			}
		}




		internal string DeactivateEmployee(int Id)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand("UPDATE Employees SET Active =0  where Id=@Id ", sqlCon);
				sqlCon.Open();
				command.Parameters.AddWithValue("@id", Id);
				if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
				{
					return "Success";
				}
				return "something worng in insert operation. try again...";
			}
		}


		internal string DeleteEmployeeDetails(int Id)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand("delete EmployeeManager where Id=@id; delete Employees where Id=@id", sqlCon);
				sqlCon.Open();
				command.Parameters.AddWithValue("@id", Id);
				if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
				{
					return "Success";
				}
				return "something worng in insert operation. try again...";
			}
		}


		public List<EmployeeEntity> Getmanager()
		{
			var employees = new List<EmployeeEntity>();

			using (var sqlCon = new SqlConnection(con))
			{
				sqlCon.Open();
				var command = new SqlCommand("SELECT * FROM Employees WHERE Role = 'Manager'", sqlCon);
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						employees.Add(mapEmployee(reader));
					}
				}
				return employees;
			}

		}

		private EmployeeEntity mapEmployee(SqlDataReader reader)
		{
			return new EmployeeEntity
			{
				Id = reader.GetInt32(0),
				FirstName = reader.GetString(1),
				LastName = reader.GetString(2),
				Active = reader.GetBoolean(3),
				UserName = reader.GetString(4),
				Password = reader.GetString(5),
				Mobile = reader.GetString(6),
				Address1 = reader.GetString(7),
				Address2 = reader.GetString(8),
				City = reader.GetString(9),
				State = reader.GetString(10),
				Zip = reader.GetString(11),
				Dob = reader.GetDateTime(12),
				JoiningDate = reader.GetDateTime(13),
			};
		}

		internal List<EmployeeEntity> GetManagerDetails(int Id)
		{
			var employees = new List<EmployeeEntity>();



			using (var sqlCon = new SqlConnection(con))
			{
				sqlCon.Open();
				var command = new SqlCommand("SELECT b.Id , a.FirstName ManagerName FROM Employees a  INNER JOIN EmployeeManager b   ON b.ManagerId = a.Id  where b.Id =@id", sqlCon);
				command.Parameters.AddWithValue("@id", Id);
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						employees.Add(new EmployeeEntity
						{
							Id = (int)reader["Id"],
							ManagerName = reader["ManagerName"].ToString()



						});
					}
					
				}
				return employees;
			}

		}



		//internal List<Entity.EmployeeEntity> GetManagerDetails(int Id)
		//{
		//	var employees = new List<Entity.EmployeeEntity>();
		//	using (var sqlCon = new SqlConnection(con))
		//	{
		//		sqlCon.Open();
		//		//var command = new SqlCommand(@"select EmpId, EmpName, ManagerId from Employee1 as t1 where ManagerId = @empId or exists (select*  from Employee1 as t2	where EmpId = t1.ManagerId	and( ManagerId = @empId or exists (select * from Employee1 as t3	where EmpId = t2.ManagerId and ManagerId = @empId))) " , sqlCon);
		//		var command = new SqlCommand(@"SELECT b.Id , a.FirstName ManagerName FROM Employees a  INNER JOIN EmployeeManager b   ON b.ManagerId = a.Id  where b.Id =@id ", sqlCon);
		//		//var command = new SqlCommand(@"SELECT DISTINCT e.EmpId AS 'ManagerId',  e.EmpName AS 'ManagerName'  FROM Employees e, Employees m WHERE e.ManagerId = @id", sqlCon);

		//		command.Parameters.AddWithValue("@id", Id);


		//		using (var reader = command.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				employees.Add(new Entity.EmployeeEntity
		//				{

		//					Id = reader.GetInt32(0),
		//					//FirstName = reader.GetString(1),
		//					//LastName = reader.GetString(2),
		//					//Active = reader.GetBoolean(3),
		//					//UserName = reader.GetString(4),
		//					//Password = reader.GetString(5),
		//					//Mobile = reader.GetString(6),
		//					//Address1 = reader.GetString(7),
		//					//Address2 = reader.GetString(8),
		//					//City = reader.GetString(9),
		//					//State = reader.GetString(10),
		//					//Zip = reader.GetString(11),
		//					//Dob = reader.GetDateTime(12),
		//					//JoiningDate = reader.GetDateTime(13),
		//					//ManagerId = reader.GetInt32(14),
		//					//ActiveEmp = reader.GetBoolean(15),
		//					//PrimaryManager = reader.GetBoolean(16),
		//					ManagerName = reader.GetString(17),

		//				});
		//			}
		//			return employees;
		//		}

		//	}
		//}





		internal string UpdateManager(Entity.EmployeeEntity employees, int Id)
		{
			using (var sqlCon = new SqlConnection(con))
			{
				var command = new SqlCommand(@"update EmployeeManager set ManagerId = @managerId, ActiveEmp =@activeEmp, PrimaryManager = @primaryManager where Id = @id", sqlCon);
				//var command = new SqlCommand(@"UPDATE Employee1 SET EmpName = @name, EmpAddress= @address WHERE ManagerId = @managerId", sqlCon);

				sqlCon.Open();
				command.Parameters.AddWithValue("@id", Id);
				command.Parameters.AddWithValue("@managerId", employees.ManagerId);
				command.Parameters.AddWithValue("@activeEmp", employees.ActiveEmp);
				command.Parameters.AddWithValue("@primaryManager", employees.PrimaryManager);
				if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
				{
					return "Success";

				}
				return "something worng in insert operation. try again...";
			}
		}

		
	internal string Insertmanager(Entity.EmployeeEntity employee)
	{
		using (var sqlCon = new SqlConnection(con))
		{
			//var command = new SqlCommand(@"INSERT INTO EmpTable (EmpId, EmpName,ActiveEmp) Values(@empId,@name,@ActiveEmp)", sqlCon);
			var command1 = new SqlCommand(@" INSERT INTO EmployeeManager(ManagerId, ActiveEmp, PrimaryManager,Id) VALUES (@ManagerId,@Active,@PrimaryManager,@Id)", sqlCon);

			sqlCon.Open();
			command1.Parameters.AddWithValue("@ManagerId", employee.ManagerId);
			command1.Parameters.AddWithValue("@Active", employee.Active);
			command1.Parameters.AddWithValue("@PrimaryManager", employee.PrimaryManager);
			command1.Parameters.AddWithValue("@Id", employee.Id);
			if (Convert.ToInt32(command1.ExecuteNonQuery()) > 0)
			{
				return "Success";

			}
			return "something worng in insert operation. try again...";
		}
	}




		//	---------------------Login----------------


	
		public EmployeeEntity GetLogin(EmployeeEntity employeeEntity)
		{

			using (var sqlCon = new SqlConnection(con))
			{
				var employees = new EmployeeEntity();
				sqlCon.Open();
				var command = new SqlCommand("Select Id,UserName ,Password,Role from Employees where UserName=@UserName and Password=@Password;", sqlCon);
				command.Parameters.AddWithValue("@userName", employeeEntity.UserName);
				command.Parameters.AddWithValue("@Password", employeeEntity.Password);
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

		//internal List<Entity.EmployeeEntity> GetManagerById(int empId)
		//{
		//	var employees = new List<Entity.EmployeeEntity>();
		//	using (var sqlCon = new SqlConnection(con))
		//	{

		//		sqlCon.Open();
		//		var command = new SqlCommand("Select * from Employees where EmpId=@id", sqlCon);
		//		command.Parameters.AddWithValue("@id", empId);
		//		using (var reader = command.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				employees.Add(new Entity.EmployeeEntity
		//				{
		//					EmpId = reader.GetInt32(0),
		//					EmpName = reader.GetString(1),
		//					ManagerId = reader.GetInt32(2),
		//					//EmpAddress = reader.GetString(3),

		//				});
		//			}
		//			return employees;
		//		}
		//	}

		//}

		//internal string InsertManager(Entity.EmployeeEntity employee)
		//{


	}



	//internal string PostEmployees(Entity.EmployeeEntity employee)
	//{

	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		var command = new SqlCommand(@"insert into Employee1 (EmpId,EmpName,EmpAddress,ManagerId)  values(@empId,@name,@address,@id)", sqlCon);
	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@empId", employee.EmpId);
	//		command.Parameters.AddWithValue("@name", employee.EmpName);
	//		//command.Parameters.AddWithValue("@address", employee.EmpAddress);
	//		command.Parameters.AddWithValue("@id", employee.ManagerId); 

	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}

	//}

	//internal string DeleteEmployee(int empId)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		var command = new SqlCommand("delete employee1 where EmpId=@id", sqlCon);
	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@id", empId);

	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}

	//}

	//internal string UpdateEmployee(Entity.EmployeeEntity employee, int empId)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		var command = new SqlCommand(@"UPDATE Employee1 SET EmpName = @name, EmpAddress= @address WHERE EmpId = @id", sqlCon);

	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@id", empId);
	//		command.Parameters.AddWithValue("@name", employee.EmpName);
	//		//command.Parameters.AddWithValue("@address", employee.EmpAddress);
	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}

	//}

	//internal string updateEmployeeLeavesType(Entity.EmployeeEntity employee, int managerId, string employeeType, int empId)
	//{
	//	throw new NotImplementedException();
	//}



	//internal string DeleteEmployeeLeavesTypes(int empId)
	//{
	//	throw new NotImplementedException();
	//}

	//internal string CreateEmployeeLeavesType(Entity.EmployeeEntity employee)
	//{
	//	throw new NotImplementedException();
	//}

	//internal List<Entity.EmployeeEntity> GetManager(int empId)
	//{
	//	var employees = new List<Entity.EmployeeEntity>();
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		sqlCon.Open();
	//		//var command = new SqlCommand(@"select EmpId, EmpName, ManagerId from Employee1 as t1 where ManagerId = @empId or exists (select*  from Employee1 as t2	where EmpId = t1.ManagerId	and( ManagerId = @empId or exists (select * from Employee1 as t3	where EmpId = t2.ManagerId and ManagerId = @empId))) " , sqlCon);
	//		var command = new SqlCommand(@"SELECT a.EmpId, a.ManagerId, A.EmpName EmployeeName, B.EmpName ManagerName, a.EmpAddress FROM employees a  INNER JOIN employees b   ON A.ManagerId = B.EmpId  where A.EmpId  =@id ", sqlCon);
	//		//var command = new SqlCommand(@"SELECT DISTINCT e.EmpId AS 'ManagerId',  e.EmpName AS 'ManagerName'  FROM Employees e, Employees m WHERE e.ManagerId = @id", sqlCon);

	//		command.Parameters.AddWithValue("@id", empId);


	//		using (var reader = command.ExecuteReader())
	//		{
	//			while (reader.Read())
	//			{
	//				employees.Add(new Entity.EmployeeEntity
	//				{

	//					EmpId = reader.GetInt32(0),
	//					EmpName = reader.GetString(2),
	//					ManagerId = reader.GetInt32(1),
	//					//ManagerName= reader.GetString(3),
	//				//	EmpAddress = reader.GetString(4),



	//				});
	//			}
	//			return employees;
	//		}

	//	}


	//}
	//internal List<Entity.EmployeeEntity> GetManagerdata(int managerId)
	//{
	//	var employees = new List<Entity.EmployeeEntity>();
	//	using (var sqlCon = new SqlConnection(con))
	//	{

	//		sqlCon.Open();
	//		var command = new SqlCommand("Select * from Employees where ManagerId=@id", sqlCon);
	//		command.Parameters.AddWithValue("@id", managerId);
	//		using (var reader = command.ExecuteReader())
	//		{
	//			while (reader.Read())
	//			{
	//				employees.Add(new Entity.EmployeeEntity
	//				{
	//					EmpId = reader.GetInt32(0),
	//					EmpName = reader.GetString(1),
	//					//EmpAddress = reader.GetString(2),
	//					ManagerId = reader.GetInt32(4)
	//			});
	//			}
	//			return employees;
	//		}
	//	}

	//}






	//internal List<Entity.EmployeeEntity> GetEmployee()
	//{
	//	var employees = new List<Entity.EmployeeEntity>();
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		sqlCon.Open();
	//		var command = new SqlCommand(@"SELECT EmpTable.EmpId, EmpManager.ManagerId, EmpTable.EmpName, EmpTable.ActiveEmp, EmpManager.PrimaryManager, EmpManager.Active FROM EmpTable inner JOIN EmpManager ON EmpTable.EmpId = EmpManager.EmpId where EmpTable.ActiveEmp =1", sqlCon);
	//		using (var reader = command.ExecuteReader())
	//		{
	//			while (reader.Read())
	//			{
	//				employees.Add(new Entity.EmployeeEntity
	//				{
	//					EmpId = reader.GetInt32(0),
	//					EmpName = reader.GetString(2),
	//					ActiveEmp = reader.GetBoolean(3),
	//					ManagerId = reader.GetInt32(1),
	//					Active = reader.GetBoolean(5),
	//					PrimaryManager = reader.GetBoolean(4)



	//				});
	//			}
	//			return employees;
	//		}

	//	}
	//}



	//internal List<Entity.EmployeeEntity> GetEmployeeDetail(int empId)
	//{
	//	var employees = new List<Entity.EmployeeEntity>();
	//	using (var sqlCon = new SqlConnection(con))
	//	{

	//		sqlCon.Open();
	//		var command = new SqlCommand(@"SELECT b.EmpId, b.ManagerId, a.EmpName FROM EmpTable a  INNER JOIN EmpManager b   ON b.EmpId = a.EmpId  where b.EmpId =@id", sqlCon);
	//		command.Parameters.AddWithValue("@id", empId);
	//		using (var reader = command.ExecuteReader())
	//		{
	//			while (reader.Read())
	//			{
	//				employees.Add(new Entity.EmployeeEntity
	//				{
	//					EmpId = reader.GetInt32(0),
	//					EmpName = reader.GetString(2),
	//					//ActiveEmp = reader.GetBoolean(2),
	//					ManagerId = reader.GetInt32(1)
	//			//		Active = reader.GetBoolean(4),
	//			//		PrimaryManager = reader.GetBoolean(5)


	//				});
	//			}
	//			return employees;
	//		}
	//	}
	//}






	//internal string UpdateManager(Entity.EmployeeEntity employee,int managerId, int empId)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		//var command = new SqlCommand(@"UPDATE EmpManager SET PrimaryManager = CASE WHEN EmpId =@managerId THEN 1  ELSE 0 END ", sqlCon);
	//		var command = new SqlCommand(@"update EmpManager set ManagerId=@managerId where EmpId=@empid; ", sqlCon);
	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@managerId", managerId);
	//		command.Parameters.AddWithValue("@empid", empId);
	//		//command.Parameters.AddWithValue("@name", employee.EmpName);
	//		//	command.Parameters.AddWithValue("@address", employee.ActiveEmp);
	//		//	command.Parameters.AddWithValue("@managerId", employee.ManagerId);
	//		//	command.Parameters.AddWithValue("@managerId", employee.Active);
	//		//	command.Parameters.AddWithValue("@managerId", employee.PrimaryManager);
	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}



	//internal string CreateManager(Entity.EmployeeEntity employee)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		//var command = new SqlCommand(@"INSERT INTO EmpTable (EmpId, EmpName,ActiveEmp) Values(@empId,@name,@ActiveEmp)", sqlCon);
	//		var command1= new SqlCommand(@" INSERT INTO EmpManager(ManagerId, Active, PrimaryManager, EmpId) VALUES (@ManagerId,@Active,@PrimaryManager,@EmpId)", sqlCon);


	//		sqlCon.Open();
	//		//command.Parameters.AddWithValue("@empId", employee.EmpId);
	//	//	command.Parameters.AddWithValue("@name", employee.EmpName);
	//		//command.Parameters.AddWithValue("@ActiveEmp", employee.ActiveEmp);
	//		command1.Parameters.AddWithValue("@ManagerId", employee.ManagerId);
	//		command1.Parameters.AddWithValue("@Active", employee.Active);
	//		command1.Parameters.AddWithValue("@PrimaryManager", employee.PrimaryManager);
	//		command1.Parameters.AddWithValue("@EmpId", employee.EmpId);
	//		if (Convert.ToInt32(command1.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}


	//internal string DeleteManagerDetails(int empId)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		//var command = new SqlCommand(" DELETE a FROM EmpManager a  INNER JOIN EmpTable b   ON a.EmpId = b.EmpId   Where a.EmpId =@id  AND b.EmpId =@id", sqlCon);
	//		var command = new SqlCommand(" delete EmpManager where EmpId=@id", sqlCon);
	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@id", empId);

	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}


	//internal string Insertemployee(Entity.EmployeeEntity employee)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		var command = new SqlCommand(@"INSERT INTO EmpTable (EmpId, EmpName,ActiveEmp) Values(@empId,@name,@ActiveEmp)", sqlCon);
	//		//var command1 = new SqlCommand(@" INSERT INTO EmpManager(ManagerId, Active, PrimaryManager, EmpId) VALUES (@ManagerId,@Active,@PrimaryManager,@EmpId)", sqlCon);

	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@empId", employee.EmpId);
	//			command.Parameters.AddWithValue("@name", employee.EmpName);
	//		command.Parameters.AddWithValue("@ActiveEmp", employee.ActiveEmp);
	//		//command1.Parameters.AddWithValue("@ManagerId", employee.ManagerId);
	//		//command1.Parameters.AddWithValue("@Active", employee.Active);
	//		//command1.Parameters.AddWithValue("@PrimaryManager", employee.PrimaryManager);
	//		//command1.Parameters.AddWithValue("@EmpId", employee.EmpId);
	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}





	//internal string DeactivateManager(Entity.EmployeeEntity employee, int empId)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		var command = new SqlCommand(@"UPDATE EmpManager SET Active = CASE WHEN EmpId =@EmpId THEN 0  ELSE 1 END ", sqlCon);

	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@EmpId", empId);
	//		//command.Parameters.AddWithValue("@name", employee.EmpName);
	//		//	command.Parameters.AddWithValue("@address", employee.ActiveEmp);
	//		//	command.Parameters.AddWithValue("@managerId", employee.ManagerId);
	//		//	command.Parameters.AddWithValue("@managerId", employee.Active);
	//		//	command.Parameters.AddWithValue("@managerId", employee.PrimaryManager);
	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}


	//internal string AssignPrimaryManager(Entity.EmployeeEntity employee,  int empId)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		//var command = new SqlCommand(@"UPDATE EmpManager SET PrimaryManager = CASE WHEN EmpId =@empid THEN 1  ELSE 0 END ", sqlCon);
	//		var command = new SqlCommand(@"update EmpManager set ManagerId=@managerId where EmpId=@empid; ", sqlCon);
	//		sqlCon.Open();
	//		//command.Parameters.AddWithValue("@managerId", managerId);
	//		command.Parameters.AddWithValue("@empid", empId);
	//		//command.Parameters.AddWithValue("@name", employee.EmpName);
	//		//	command.Parameters.AddWithValue("@address", employee.ActiveEmp);
	//		//	command.Parameters.AddWithValue("@managerId", employee.ManagerId);
	//		//	command.Parameters.AddWithValue("@managerId", employee.Active);
	//		//	command.Parameters.AddWithValue("@managerId", employee.PrimaryManager);
	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}



	//internal string DeleteEmployeeDetails(int empId)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		//var command = new SqlCommand(" DELETE a FROM EmpManager a  INNER JOIN EmpTable b   ON a.EmpId = b.EmpId   Where a.EmpId =@id  AND b.EmpId =@id", sqlCon);
	//		var command = new SqlCommand(" delete   EmpTable  where EmpId = @id", sqlCon);
	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@id", empId);

	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}


	//// emlpoyee salary type 

	//internal List<Entity.EmployeeEntity> GetEmployeeSalaryType(int empId)
	//{
	//	var employees = new List<Entity.EmployeeEntity>();
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		sqlCon.Open();
	//		//var command = new SqlCommand(@"select EmpId, EmpName, ManagerId from Employee1 as t1 where ManagerId = @empId or exists (select*  from Employee1 as t2	where EmpId = t1.ManagerId	and( ManagerId = @empId or exists (select * from Employee1 as t3	where EmpId = t2.ManagerId and ManagerId = @empId))) " , sqlCon);
	//		var command = new SqlCommand(@"SELECT b.EmpId, a.EmpName,b.Salary,b.EmployeeType  FROM EmpTable a  INNER JOIN EmpSalary b   ON b.EmpId = a.EmpId  where b.EmpId =@id ", sqlCon);
	//		//var command = new SqlCommand(@"SELECT DISTINCT e.EmpId AS 'ManagerId',  e.EmpName AS 'ManagerName'  FROM Employees e, Employees m WHERE e.ManagerId = @id", sqlCon);

	//		command.Parameters.AddWithValue("@id", empId);


	//		using (var reader = command.ExecuteReader())
	//		{
	//			while (reader.Read())
	//			{
	//				employees.Add(new Entity.EmployeeEntity
	//				{
	//					EmpId = reader.GetInt32(0),
	//					EmpName = reader.GetString(1),
	//					Salary= reader.GetInt32(2),
	//					EmployeeType= reader.GetString(3),



	//				});
	//			}
	//			return employees;
	//		}

	//	}
	//}


	//// update salary type

	//internal string updateEmployeeType(Entity.EmployeeEntity employee,int managerId,string employeeType, int empId)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		//var command = new SqlCommand(@"UPDATE EmpManager SET PrimaryManager = CASE WHEN EmpId =@empid THEN 1  ELSE 0 END ", sqlCon);
	//		var command = new SqlCommand(@"update EmpSalary set Salary=@managerId , EmployeeType=@employeeType ,where EmpId=@empid; ", sqlCon);
	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@managerId", managerId);
	//		command.Parameters.AddWithValue("@employeeType", employeeType);
	//		command.Parameters.AddWithValue("@empid", empId);
	//		//	command.Parameters.AddWithValue("@address", employee.ActiveEmp);
	//		//	command.Parameters.AddWithValue("@managerId", employee.ManagerId);
	//		//	command.Parameters.AddWithValue("@managerId", employee.Active);
	//		//	command.Parameters.AddWithValue("@managerId", employee.PrimaryManager);
	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}



	//// insert into salary type
	//internal string CreateEmployeeType(Entity.EmployeeEntity employee)
	//{

	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		//var command = new SqlCommand(@"INSERT INTO EmpTable (EmpId, EmpName,ActiveEmp) Values(@empId,@name,@ActiveEmp)", sqlCon);
	//		var command1 = new SqlCommand(@"INSERT INTO EmpSalary(EmpId, Salary, EmployeeType) VALUES (@empId,@salary,@employeeType)", sqlCon);


	//		sqlCon.Open();
	//		//command.Parameters.AddWithValue("@empId", employee.EmpId);
	//		//	command.Parameters.AddWithValue("@name", employee.EmpName);
	//		//command.Parameters.AddWithValue("@ActiveEmp", employee.ActiveEmp);
	//		command1.Parameters.AddWithValue("@empId", employee.EmpId);
	//		command1.Parameters.AddWithValue("@salary", employee.Salary);
	//		command1.Parameters.AddWithValue("@employeeType", employee.EmployeeType);

	//		if (Convert.ToInt32(command1.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}


	//// delete into salary
	//internal string DeleteEmployeeTypes(int empId)
	//{
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		//var command = new SqlCommand(" DELETE a FROM EmpManager a  INNER JOIN EmpTable b   ON a.EmpId = b.EmpId   Where a.EmpId =@id  AND b.EmpId =@id", sqlCon);
	//		var command = new SqlCommand(" delete EmpSalary where EmpId=@id", sqlCon);
	//		sqlCon.Open();
	//		command.Parameters.AddWithValue("@id", empId);

	//		if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
	//		{
	//			return "Success";

	//		}
	//		return "something worng in insert operation. try again...";
	//	}
	//}



	//internal List<Entity.EmployeeEntity> GetEmployeeLeavesType(int empId)
	//{
	//	var employees = new List<Entity.EmployeeEntity>();
	//	using (var sqlCon = new SqlConnection(con))
	//	{
	//		sqlCon.Open();
	//		var command = new SqlCommand(@"SELECT b.EmpId, a.EmpName,b.Days,b.Type  FROM EmpTable a  INNER JOIN EmpLeaves b   ON b.EmpId = a.EmpId  where b.EmpId =@id", sqlCon);
	//		command.Parameters.AddWithValue("@id", empId);
	//		using (var reader = command.ExecuteReader())
	//		{
	//			while (reader.Read())
	//			{
	//				employees.Add(new Entity.EmployeeEntity
	//				{
	//					EmpId = reader.GetInt32(0),
	//					EmpName = reader.GetString(1),

	//					Days =reader.GetInt32(2),
	//					Type= reader.GetString(3)
	//				});
	//			}
	//			return employees;
	//		}

	//	}
	//}

	//}
}




