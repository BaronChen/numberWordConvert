'use strict';
app.service("converterService", ['$http', '$q', function ($http, $q) {
	
	this.getWordsFromNumber = function(number) {

		var data = { "number": number };

		return $http({
			method: 'Post',
			url: '/api/intword/number-to-word',
			data: data
		});
	}

	this.getNumberFromWords = function (word) {

		var data = { "word": word };

		return $http({
			method: 'Post',
			url: '/api/intword/word-to-number',
			data: data
		});
	}


}]);