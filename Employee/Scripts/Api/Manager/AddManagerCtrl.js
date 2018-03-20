(function () {
	function AddManagerCtrl($scope, APIService, $location) {

		$scope.employees = {};


		$scope.clicked = function () {
			window.location.href = '/AddNewManager';
		}

		$scope.getAllEmployees = function () {
			APIService.GetEmployee().then(function (data) {
				$scope.employees = data;
			}, function (error) {
				console.log('Oops! Something went wrong while fetching the data.')
			});

		}
		$scope.getAllEmployeesById = function (id) {
			APIService.getEmployeeById(id).then(function (data) {
				$scope.employee = data.data;
				$scope.employee.JoiningDate = new Date($scope.employee.JoiningDate);
				$scope.employee.Dob = new Date($scope.employee.Dob);
				$scope.employee.Mobile = new Date($scope.employee.Mobile);
				$scope.employee.Zip = new Date($scope.employee.Zip);
			}, function (error) {
				console.log('Oops! Something went wrong while fetching the data.')
			});

		}
		$scope.populateRecords = function () {

			var currentEmployee;
			var loc = window.location.href;
			if (loc.split('id=').length > 1) {
				currentEmployee = loc.split('id=').pop();
				$scope.getAllEmployeesById(currentEmployee);
			}
		}

		//	debugger
		$scope.saveManagers = function () {
			//	debugger;
			var employeeData = {
				image: $scope.employee.image,
				FirstName: $scope.employee.FirstName,
				LastName: $scope.employee.LastName,
				FirstName: $scope.employee.FirstName,
				Active: $scope.employee.Active,
				UserName: $scope.employee.UserName,
				Password: $scope.employee.Password,
				//RePassword: $scope.employee.RePassword,
				Mobile: $scope.employee.Mobile,
				Address1: $scope.employee.Address1,
				Address2: $scope.employee.Address2,
				City: $scope.employee.City,
				State: $scope.employee.State,
				Zip: $scope.employee.Zip,
				Dob: $scope.employee.Dob,
				JoiningDate: $scope.employee.JoiningDate,
				Role: $scope.employee.Role


			};
			var saveManagers = APIService.saveManagers(employeeData);
			saveManagers.then(function (data) {
				alert("save succefuly");
				window.location.href = '/AddNewManager';
			}, function (error) {
				console.log('Oops! Something went wrong while saving the data.')
			})
		};


		$scope.updateManagers = function () {
			var EmployeeData = {
				Id: $scope.employee.Id,
				FirstName: $scope.employee.FirstName,
				LastName: $scope.employee.LastName,
				//Active: $scope.employee.Active,
				UserName: $scope.employee.UserName,
				//Password: $scope.employee.Password,
				Mobile: $scope.employee.Mobile,
				Address1: $scope.employee.Address1,
				Address2: $scope.employee.Address2,
				City: $scope.employee.City,
				State: $scope.employee.State,
				Zip: $scope.employee.Zip,
				Dob: $scope.employee.Dob,
				JoiningDate: $scope.employee.JoiningDate,
				Role:$scope.employee.Role

			};


			var updateManagers = APIService.updateManagers(EmployeeData.Id, EmployeeData);

			updateManagers.then(function (EmployeeData) {
				alert("Updated successfully");
				window.location.href = '/AddNewManager';
			}, function (error) {
				console.log('Oops! Something went wrong while saving the data.')
			})
		};

	};



	AddManagerCtrl.$inject = ["$scope", "APIService", "$location"];
			angular.module("APIModule").controller('AddManagerCtrl', AddManagerCtrl);
})();




