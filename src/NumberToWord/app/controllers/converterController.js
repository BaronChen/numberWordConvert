app.controller('converterController', ['$scope', 'converterService', function ($scope, converterService) {

	var self = this;
	self.converterService = converterService;

	self.$scope = $scope;

	this.hanldeError = function (response) {
		if (response.data.message) {
			$scope.errorMessage = response.data.message;
		} else {
			$scope.errorMessage = response.message = "Sorry, there is an internal issue...";
		}

		$scope.showError = true;
	};

	this.convertNumberToWords = function () {

		self.converterService.getWordsFromNumber($scope.number)
			.then(
				function (response) {
					$scope.words = response.data.result;
				},
				this.hanldeError
		);
	}

	this.covertWordToNumber = function () {

		self.converterService.getNumberFromWords($scope.words)
			.then(
				function (response) {
					$scope.number = response.data.result;
				},
				this.hanldeError
		);
	}

	this.hideErrorMessage = function() {
		self.$scope.showError = false;
	}

}]);