(function () {
	'use strict';
	function ManagerService($http) {
		var service = {};
		var apiPath = "http://localhost:60383/api";

		function loginEmployees(data) {
			return $http.post(apiPath+'/getlogin', data).then(function (res) {
				console.log(res)
				return res.data;
			}, function (error) {
				console.log(error)
			});
		}
		
		
		service.LoginEmployees = loginEmployees;
		return service;
	}

	angular.module('APIModule').factory('ManagerService', ManagerService);
		ManagerService.$inject = ['$http'];
})();