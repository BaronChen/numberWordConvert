app.directive('sidenavDirective', ['$location', '$mdSidenav', function ($location, $mdSidenav) {

	return {
		restrict: 'E',
		scope: {
		},
		templateUrl: 'app/directives/sidenav/sidenavDirective.html',
		link: function ($scope, element, attrs) {

			$scope.menuItems = [
				{
					title: 'Converter',
					route: '/converter'
				},
				{
					title: 'API',
					route: '/api-doc'
				},
				{
					title: 'About',
					route: '/about'
				},
				{
					title: 'Fork Me!',
					externalLink: 'https://github.com/BaronChen/numberWordConvert'
				}
			];

			$scope.go = function (menuItem) {
				if (menuItem.externalLink) {
					window.location.href = menuItem.externalLink;
				}
				$location.path(menuItem.route);
			};

			$scope.toggleMenu = function() {
				$mdSidenav('left').toggle();
			}

		}
	};
}
]);