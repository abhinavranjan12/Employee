(function () {
	function ManagerController($scope, ManagerService, $location) {

		$scope.employees = {};
		$scope.login = function () {
		//	debugger
			ManagerService.LoginEmployees($scope.employees).then(function (data) {
				if ($scope.employees.UserName === data.UserName && $scope.employees.Password === data.Password && data.Role == 'Admin') {
					$('.LoginOrOut').hide();
					window.location.href = '/AdminHome';

					//$scope.employees = data
				} else if ($scope.employees.UserName === data.UserName && $scope.employees.Password === data.Password && data.Role == 'Manager') {
					window.location.href = '/AddEmployees';
				}
			}, function (error) {
				console.log("Error Login Again");
				window.location.href = '/UserLogin';
				console.log('Oops! Something went wrong while fetching the data.')
			});
		}	
	};
	
	ManagerController.$inject = ["$scope", "ManagerService", "$location"];
	angular.module("APIModule").controller('ManagerController', ManagerController);
})();













