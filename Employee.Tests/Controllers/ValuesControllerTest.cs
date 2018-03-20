using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Employee;
using Employee.Controllers;
using Employee.Models.Entity;

namespace Employee.Tests.Controllers
{
	[TestClass]
	public class ValuesControllerTest
	{
		private int empId;

		[TestMethod]
		public void Get()
		{
			// Arrange
			EmployeeController controller = new EmployeeController();

			// Act
			List<EmployeeEntity> result = controller.GetEmployee();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.Count());
			Assert.AreEqual("value1", result.ElementAt(0));
			Assert.AreEqual("value2", result.ElementAt(1));
		}

		[TestMethod]
		public void GetById(Guid id)
		{
			// Arrange
			EmployeeController controller = new EmployeeController();

			// Act
			string result = controller.GetEmployee(id);

			// Assert
			Assert.AreEqual("value", result);
		}

		[TestMethod]
		public void Post()
		{
			// Arrange
			EmployeeController controller = new EmployeeController();

			// Act
			controller.Insertemployee("value");

			// Assert
		}

		[TestMethod]
		public void Put()
		{
			// Arrange
			EmployeeController controller = new EmployeeController();

			// Act
			controller.DeactivateEmployee("employee", empId);

			// Assert
		}

		[TestMethod]
		public void Delete()
		{
			// Arrange
			EmployeeController controller = new EmployeeController();

			// Act
			controller.DeleteEmployeeDetails(5);

			// Assert
		}
	}
}
