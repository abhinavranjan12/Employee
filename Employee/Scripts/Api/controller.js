app.controller('APIController', function ($scope, APIService, $location) {
	$scope.employee = {};
	$scope.managers = [];


	$scope.back = function () {
		window.location.href = '/AddNewManager';
	}
	

	$scope.getAllEmployees = function () {
		APIService.GetEmployee().then(function (data) {
			$scope.employees = data;
		}, function (error) {
			console.log('Oops! Something went wrong while fetching the data.')
		});

	}
	//$scope.populateRecordsData = function () {

	//	var currentEmployee;
	//	var loc = window.location.href;
	//	if (loc.split('id=').length > 1) {
	//		currentEmployee = loc.split('id=').pop();
	//		$scope.getDataManagerById(currentEmployee);
	//	}
	//}
	$scope.login = function () {
		debugger
		APIService.loginEmployees().then(function (data) {

			if (data.UserName == employees.UserName && data.Password == employees.Password) {
				window.location.href = '/Home';
				$scope.employees = data
			}
		}, function (error) {
			console.log('Oops! Something went wrong while fetching the data.')
		});

	}

	$scope.getAllEmployeesById = function (id) {
		APIService.getEmployeeById(id).then(function (data) {
			$scope.employee = data.data;
		$scope.employee.JoiningDate = new Date($scope.employee.JoiningDate)
			$scope.employee.Dob = new Date($scope.employee.Dob)
		}, function (error) {
			console.log('Oops! Something went wrong while fetching the data.')
		});

	}

	$scope.getEmployeeIdFromUrl = function (next) {
		var loc = window.location.href;
		if (loc.split('id=').length > 1) {
			currentEmployee = loc.split('id=').pop();
			next(currentEmployee);
		}
	}
	
	$scope.populateRecords = function () {
	
		var currentEmployee;
		var loc = window.location.href;
		if (loc.split('id=').length > 1) {
			currentEmployee = loc.split('id=').pop();
			$scope.getAllEmployeesById(currentEmployee);
		}
	}

	$scope.clicked = function () {
		window.location.href = '/Home';
	}


	var submit = function () {

		if (!scope.employee.FirstName == null && !scope.employee.FirstName == "") {
			alert("First name field is empty");
		} else if (!$scope.employee.UserName && !$scope.employee.UserName) {
			alert("UserName field is empty");
		} else if (!$scope.employee.Password && !$scope.employee.Password) {
			alert("Password field is empty")
		} else {
			$scope.saveEmployees();
			alert("data inserted successfully");
		}
	};

	$scope.saveEmployees = function () {
	//	debugger;
		var employeeData = {
			image: $scope.employee.image,
			FirstName: $scope.employee.FirstName,
			LastName: $scope.employee.LastName,
			//FirstName: $scope.employee.FirstName,
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
		var saveEmployees = APIService.saveEmployees(employeeData);
		saveEmployees.then(function (data) {
			alert("save succefuly");
			window.location.href = '/Home';
		}, function (error) {
			console.log('Oops! Something went wrong while saving the data.')
		})
	};
	
	$scope.updateEmployees = function () {
		var EmployeeData = {
			Id: $scope.employee.Id,
			FirstName: $scope.employee.FirstName,
			LastName: $scope.employee.LastName,
			FirstName: $scope.employee.FirstName,
			Active: $scope.employee.Active,
			UserName: $scope.employee.UserName,
			//Password: $scope.employee.Password,
			Mobile: $scope.employee.Mobile,
			Address1: $scope.employee.Address1,
			Address2: $scope.employee.Address2,
			City: $scope.employee.City,
			State: $scope.employee.State,
			Zip: $scope.employee.Zip,
			Dob: $scope.employee.Dob,
			JoiningDate: $scope.employee.JoiningDate

		};
	

		var updateEmployees = APIService.updateEmployees(EmployeeData.Id, EmployeeData);

		updateEmployees.then(function (EmployeeData) {
			alert("Updated successfully");
			window.location.href = '/Home';
		}, function (error) {
			console.log('Oops! Something went wrong while saving the data.')
			})
	};





	$scope.deleteEmployees = function (Id) {
		var dlt = APIService.deleteEmployees(Id);
		dlt.then(function (data) {
			alert("deleted successfully");
			window.location.href = '/Home';
		}, function (error) {
			console.log('Oops! Something went wrong while deleting the data.')
		})
	};
	
	$scope.getManagers = function () {
		APIService.getManagers().then(function (data) {
			$scope.managers = data.data;
		}, function (error) {
			console.log('Oops! Something went wrong while fetching the data.')
		});

	}


	$scope.getDataManagerById = function (id) {
		//debugger;
		APIService.GetManagerById(id).then(function (data) {
			$scope.managers = data.data;
			//	$scope.employee.JoiningDate = new Date($scope.employee.JoiningDate)
			//	$scope.employee.Dob = new Date($scope.employee.Dob)
		}, function (error) {
			console.log('Oops! Something went wrong while fetching the data.')
		});

	}
	//----------------------------------------------------------------------------------------------File Upload------------
	//var app = angular.module('plunkr', [])
	//app.controller('UploadController', function ($scope, fileReader) {
	//	$scope.imageSrc = "";

	//	$scope.$on("fileProgress", function (e, progress) {
	//		$scope.progress = progress.loaded / progress.total;
	//	});
	//});
	
	//app.directive("ngFileSelect", function (fileReader, $timeout) {
	//	return {
	//		scope: {
	//			ngModel: '='
	//		},
	//		link: function ($scope, el) {
	//			function getFile(file) {
	//				fileReader.readAsDataUrl(file, $scope)
	//					.then(function (result) {
	//						$timeout(function () {
	//							$scope.ngModel = result;
	//						});
	//					});
	//			}

	//			el.bind("change", function (e) {
	//				var file = (e.srcElement || e.target).files[0];
	//				getFile(file);
	//			});
	//		}
	//	};
	//});

	//app.factory("fileReader", function ($q, $log) {
	//	var onLoad = function (reader, deferred, scope) {
	//		return function () {
	//			scope.$apply(function () {
	//				deferred.resolve(reader.result);
	//			});
	//		};
	//	};

	//	var onError = function (reader, deferred, scope) {
	//		return function () {
	//			scope.$apply(function () {
	//				deferred.reject(reader.result);
	//			});
	//		};
	//	};

	//	var onProgress = function (reader, scope) {
	//		return function (event) {
	//			scope.$broadcast("fileProgress", {
	//				total: event.total,
	//				loaded: event.loaded
	//			});
	//		};
	//	};

	//	var getReader = function (deferred, scope) {
	//		var reader = new FileReader();
	//		reader.onload = onLoad(reader, deferred, scope);
	//		reader.onerror = onError(reader, deferred, scope);
	//		reader.onprogress = onProgress(reader, scope);
	//		return reader;
	//	};

	//	var readAsDataURL = function (file, scope) {
	//		var deferred = $q.defer();

	//		var reader = getReader(deferred, scope);
	//		reader.readAsDataURL(file);

	//		return deferred.promise;
	//	};

	//	return {
	//		readAsDataUrl: readAsDataURL
	//	};
	//});



	//$scope.OnActive = function (id) {
	//	var dlt = APIService.ActivateEmployee(id);
	//	dlt.then(function (data) {
	//		if (data.checked) {
	//			alert("Activate employees successfully");
	//			window.location.href = '/Home';
	//			//deactivateEmployeeById(id);
	//			activateEmployee(id);
	//		} else {
	//			console.log('Oops! Something went wrong while deleting the data.')
	//		}
			
	//	})
	//};
	//$scope.OnDeActive = function (id) {
	//	var dlt = APIService.deactivateEmployees(id);
	//	dlt.then(function (data) {
	//		if (data.checked) {
	//			alert("Deactivate employees successfully");
	//			window.location.href = '/Home';
	//			//deactivateEmployeeById(id);
	//			activateEmployee(id);
	//		}else {
	//			console.log('Oops! Something went wrong while deleting the data.')
	//		}

	//	})
	//};
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
			Role: $scope.employee.Role

		};


		var updateManagers = APIService.updateManagers(EmployeeData.Id, EmployeeData);

		updateManagers.then(function (EmployeeData) {
			alert("Updated successfully");
			window.location.href = '/AddNewManager';
		}, function (error) {
			console.log('Oops! Something went wrong while saving the data.')
		})
	};


	$scope.deactivateEmployeeById = function (id) {
		debugger;
		var dlt = APIService.deactivateEmployees(id);
		dlt.then(function (data) {
			alert("Activate employees successfully");
			window.location.href = '/Home';
		}, function (error) {
			console.log('Oops! Something went wrong while deleting the data.')
		})
	};

	$scope.activateEmployee = function (id) {
		debugger;
		var dlt = APIService.ActivateEmployee(id);
		dlt.then(function (data) {
			alert("deactivate employees successfully");
			window.location.href = '/Home';
		}, function (error) {
			console.log('Oops! Something went wrong while deleting the data.')
		})
	};

//	$scope.deactivateEmployeeById = function () {
//		debugger;
//		var EmployeeData = {
//			Id: $scope.employee.Id,

//			Active: $scope.employee.Active
//		};

//	var deactivateEmployeeById = APIService.deactivateEmployees(EmployeeData.Id, EmployeeData);

//	deactivateEmployeeById.then(function (EmployeeData) {
//		alert("Updated successfully");
//		window.location.href = '/Home';
//	}, function (error) {
//		console.log('Oops! Something went wrong while saving the data.')
//	})
//};




	$scope.populateManagerAssignPage = function () {
	//	debugger;
		$scope.getManagers();
		//$scope.getDataManagerById();
	

	}
	

	$scope.saveManager = function () {
		//debugger;
		var employeeManager = {
			Id: $scope.employeeManager.ManagerId,

			PrimaryManager: $scope.employeeManager.PrimaryManager
		};

	
		$scope.getEmployeeIdFromUrl(function (id) {
			$scope.employeeManager.EmployeeId = id;
			APIService.assignManager($scope.employeeManager).then(function (data) {
				alert("save successfully");
				window.location.href = '/Home';
			}, function (error) {
				console.log('Oops! Something went wrong while saving the data.')
			})
		})

		
	};

	$scope.updateManager = function () {
	//	debugger
		var employeeManager = {
			Id: $scope.employeeManager.ManagerId,

			PrimaryManager: $scope.employeeManager.PrimaryManager
		};

		$scope.getEmployeeIdFromUrl(function (id) {
			$scope.employeeManager.EmployeeId = id;
			APIService.updateAssignManager($scope.employeeManager).then(function (data) {
				alert("Update successfully");
				window.location.href = '/Home';
				//var updateManager = APIService.updateAssignManager(employeeManager.Id, employeeManager);

				//updateManager.then(function (EmployeeData) {
				//	alert("Assign Manager successfully");
				//	window.location.href = '/Home';
			}, function (error) {
				console.log('Oops! Something went wrong while saving the data.')
			})
		})
	};
	
	$scope.loginOrOut = function () {
		setLoginLogoutText();
		var isAuthenticated = authService.user.isAuthenticated;
		if (isAuthenticated) { //logout 
			authService.logout().then(function () {
				$location.path('/');
				return;
			});
		}
		redirectToLogin();
	};

	function redirectToLogin() {
		var path = '/login' + $location.$$path;
		$location.replace();
		$location.path(path);
	}
});