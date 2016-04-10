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
					route: '/fork-me'
				}
			];

			$scope.go = function (path) {
				$location.path(path);
			};

			$scope.toggleMenu = function() {
				$mdSidenav('left').toggle();
			}

		}
	};
}
]);