using System;
using System.Collections.Generic;
using System.Web.Http;
using Employee.Models;
using Employee.Models.Entity;

namespace Employee.Controllers
{

	[RoutePrefix("api")]

	public class EmployeeController : ApiController
	{
		private EmployeeManagerModel model;


		public EmployeeController() {
			model = new EmployeeManagerModel();
		}


		[Route("employees")]
		[HttpGet]
		public List<EmployeeEntity> GetEmployees()
		{
			return model.GetEmployees();
		}


		[Route("employees")]
		[HttpPost]
		public string AddEmployees([FromBody] EmployeeEntity employees)
		{
			return model.AddEmployees(employees);
		}


	

		[Route("employees/{Id}")]
		[HttpGet]
		public EmployeeEntity GetEmployees(int Id)
		{
			return model.GetEmployees(Id);
		}


		[Route("employees/{Id}")]
		[HttpPut]
		public string UpdateEmployees([FromBody] EmployeeEntity employees, int Id)
		{
			return model.UpdateEmployees(employees, Id);
		}
		//--------------------------------------------


		[Route("employees/{Id}/deactivate")]
		[HttpPut]

		public string DeactivateEmployee(int Id)
		{

			return model.DeactivateEmployee(Id);
		}

		[Route("employees/{Id}/activate")]
		[HttpPut]

		public string ActivateEmployee(int Id)
		{

			return model.ActivateEmployee(Id);
		}

		//---------------------------


		[Route("employees/{Id}")]
		[HttpDelete]

		public string DeleteEmployeeDetails(int Id)
		{

			return model.DeleteEmployeeDetails(Id);
		}


		[Route("managers")]
		[HttpGet]
		public List<EmployeeEntity> Getmanager()
		{
			return model.Getmanager();
		}

		[Route("employees/{Id}/managers")]
		[HttpGet]
		public List<EmployeeEntity> GetEmployeeManager(int Id)
		{
			return model.GetEmployeeManager(Id);
		}


		[Route("employees/{Id}/managers/{managerId}/assign")]
		[HttpPost]
		public void AssigneManager(int Id, int managerId, bool primary = false)
		{
			model.AssigneManager(Id, managerId, primary);
		}

		[Route("employees/{Id}/managers/{managerId}/assign")]
		[HttpPut]
		public void UpdateAssigneManager(int Id, int managerId, bool primary = false)
		{
			model.UpdateAssigneManager(Id, managerId, primary);
		}





		[Route("manager")]
		[HttpPost]
		public string Insertmanager([FromBody] EmployeeEntity employee)
		{
			return model.Insertmanager(employee);
		}

		[Route("manager")]
		[HttpPost]
		public string AddManager([FromBody] EmployeeEntity employees)
		{
			return model.AddManager(employees);
		}

		[Route("manager/{Id}")]
		[HttpPut]
		public string UpdateManagers([FromBody] EmployeeEntity employees , int Id)
		{
			return model.UpdateManagers(employees, Id);
		}


		//[Route("manager/{Id}")]
		//[HttpPut]
		//public string UpdateManager([FromBody] EmployeeEntity employee, int Id)
		//{
		//	return model.UpdateManager(employee, Id);
		//}










		//[Route("manager/{empId}")]
		//[HttpGet]
		//public List<EmployeeEntity> GetManagerById(int empId)
		//{
		//	return model.GetManagerById(empId);
		//}


		[Route("manager/{Id}")]
		[HttpGet]
		public List<EmployeeEntity> GetManagerDetails(int Id)
		{
			return model.GetManagerDetails(Id);
		}




		//	---------------------login--------------------------

		[Route("getlogin")]
		[HttpPost]
		public EmployeeEntity GetLogin(EmployeeEntity employeeEntity)
		{
			
			return model.GetLogin(employeeEntity);
		}




		//[Route("employee/{empId}/manager/{managerId}")]
		//[HttpPut]
		//public string UpdateManager([FromBody] EmployeeEntity employee, int managerId, int empId)
		//{
		//	return model.UpdateManager(employee, managerId, empId);
		//}


		//[Route("employee/{empId}/manager")]
		//[HttpPut]
		//public string AssignPrimaryManager([FromBody] EmployeeEntity employee, int empId)
		//{
		//	return model.AssignPrimaryManager(employee,  empId);
		//}




		//[Route("employee/{empId}/manager")]
		//[HttpPost]
		//public string CreateManager([FromBody] EmployeeEntity employee)
		//{
		//	return model.CreateManager(employee);
		//}

		//[Route("employee/{empId}/manager")]
		//[HttpDelete]

		//public string DeleteManagerDetails(int empId)
		//{

		//	return model.DeleteManagerDetails(empId);
		//}


		//[Route("employee/{empId}/EmployeeSalary")]
		//[HttpGet]
		//public List<EmployeeEntity> GetEmployeeSalaryType(int empId)
		//{
		//	return model.GetEmployeeSalaryType(empId);
		//}


		//[Route("employee/{empId}/EmployeeSalary")]
		//[HttpPut]
		//public string updateEmployeeType([FromBody] EmployeeEntity employee, int managerId, string employeeType, int empId)
		//{
		//	return model.updateEmployeeType(employee,  managerId,  employeeType, empId);
		//}




		//[Route("employee/{empId}/EmployeeSalary")]
		//[HttpPost]
		//public string CreateEmployeeType([FromBody] EmployeeEntity employee)
		//{
		//	return model.CreateEmployeeType(employee);
		//}

		//[Route("employee/{empId}/EmployeeSalary")]
		//[HttpDelete]

		//public string DeleteEmployeeTypes(int empId)
		//{

		//	return model.DeleteEmployeeTypes(empId);
		//}




		//[Route("employee/{empId}/EmployeeLeaves")]
		//[HttpGet]
		//public List<EmployeeEntity> GetEmployeeLeavesType(int empId)
		//{
		//	return model.GetEmployeeLeavesType(empId);
		//}


		//[Route("employee/{empId}/EmployeeLeaves")]
		//[HttpPut]
		//public string updateEmployeeLeavesType([FromBody] EmployeeEntity employee, int managerId, string employeeType, int empId)
		//{
		//	return model.updateEmployeeLeavesType(employee, managerId, employeeType, empId);
		//}




		//[Route("employee/{empId}/EmployeeLeaves")]
		//[HttpPost]
		//public string CreateEmployeeLeavesType([FromBody] EmployeeEntity employee)
		//{
		//	return model.CreateEmployeeLeavesType(employee);
		//}

		//[Route("employee/{empId}/EmployeeLeaves")]
		//[HttpDelete]

		//public string DeleteEmployeeLeavesTypes(int empId)
		//{

		//	return model.DeleteEmployeeLeavesTypes(empId);
		//}
	}
}
