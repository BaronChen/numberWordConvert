app.controller('sidenavDirectiveController', ['$state', '$location', function ($state, $location) {

	this.isActive = function (routeName) {
		return $state.current.name === routeName;
	}

	this.go = function (menuItem) {
		if (menuItem.externalLink) {
			window.location.href = menuItem.externalLink;
		}
		$state.go(menuItem.routeName);
	};

}]);