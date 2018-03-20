app.service("APIService", function ($http) {
	var baseUrl = 'http://localhost:60383/';

	this.GetEmployee = function () {
		var url = baseUrl + 'api/employees';
		return $http.get(url).then(function (response) {
			return response.data;
		});
	};


	this.GetLogin = function () {
		var url = baseUrl + 'api/getlogin';
		return $http.get(url).then(function (response) {
			return response.data;
		});
	};
	

	this.getEmployeeById = function (employeeID) {
		return $http({
			method: "get",
			url: baseUrl + 'api/employees/' + employeeID
		});
	}
	

	this.saveEmployees = function (Employee) {
		return $http({
			method: 'post',
			data: Employee,
			url: baseUrl + 'api/employees'
		});
	};


	

	//this.updateEmployees = function (employee) {
	//	var response = $http({
	//		method: "post",
	//		url: "api/employees/",
	//		data: employee,
	//		dataType: "json"
	//	});
	//	return response;
	//}

	this.updateEmployees = function (id, EmployeeData) {
		
		return $http({
			method: 'put',
			data: EmployeeData,
			url: baseUrl + 'api/employees/' + id

		});
	}
	this.deleteEmployees = function (Id) {
		var url = baseUrl + 'api/employees/' + Id;
		return $http({
			method: 'delete',
			data: Id,
			url: url
		});
	}
	//-------------------------------------manager api----------------


	//this.authService = function (data) {
	//	debugger;
	//	return $http({
	//		method: 'get',

	//		data: data,
	//		url: baseUrl + 'api/getlogin'
		
					
	//			});
	//		}
		
	this.loginEmployees = function (data) {
		debugger;
		return  $http({
			method: "get",
			data: data,
			url: baseUrl + 'api/getlogin',
					
		});
	}  
	this.saveManager = function (Employee) {
		return $http({
			method: 'post',
			data: Employee,
		});
	};



	this.GetManagerById = function (id) {
		debugger;
		return $http({
			method: "get",
			url: baseUrl + 'api/employees/' + id + '/managers'
		});
	}

	this.getManagers = function () {
	//	debugger;
		return $http({
			method: "get",
			url: baseUrl + 'api/managers'
		});
	};

	this.assignManager = function (request) {
	//	debugger;
		return $http({
			method: "post",
			url: baseUrl + 'api/employees/' + request.EmployeeId + '/managers/' + request.ManagerId +'/assign'
		});
	};


	this.updateAssignManager = function (request) {
	//	debugger;
		return $http({
			method: "put",
			url: baseUrl + 'api/employees/' + request.EmployeeId + '/managers/' + request.ManagerId + '/assign'
		});
	};
//--------------------------
	this.deactivateEmployees = function (id) {
		debugger;
		var url = baseUrl + 'api/employees/' + id +'/deactivate';
		return $http({
			method: "put",
			data: id,
			url: url
		});
	}

	this.ActivateEmployee = function (id) {
		debugger;
		var url = baseUrl + 'api/employees/' + id + '/activate';
		return $http({
			method: "put",
			data: id,
			url: url
		});
	}
	//this.deactivateEmployees = function (request) {

	//	return $http({
	//		method: "put",
	//		url: baseUrl + '/employees/' + id +'/deactivate'
	//	});
	//}


	this.saveManagers = function (Employee) {
		
		return $http({
			method: 'post',
			data: Employee,
			url: baseUrl + 'api/manager'
		});
	};
	this.updateManagers = function (id,EmployeeData) {

		return $http({
			method: 'put',
			data: EmployeeData,
			url: baseUrl + 'api/manager/' + id

		});
	}

	//this.updateManager = function (id, EmployeeData) {

	//	return $http({
	//		method: 'put',
	//		data: EmployeeData,
	//		url: baseUrl + 'api/manager/' + id

	//	});
	//}




});