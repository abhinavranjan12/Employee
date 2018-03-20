app.controller('LoginController', function ($scope, APIService, $location) {


	$scope.getAllEmployees = function () {
		APIService.GetEmployee().then(function (data) {
			$scope.employees = data;
		}, function (error) {
			console.log('Oops! Something went wrong while fetching the data.')
		});

	}
});