app.directive('sidenavDirective', ['$location', '$mdSidenav', '$route', function ($location, $mdSidenav, $route) {

	return {
		restrict: 'E',
		scope: {
		},
		templateUrl: 'app/directives/sidenav/sidenavDirective.html',
		link: function ($scope, element, attrs) {
			$scope.$route = $route; 
			$scope.menuItems = [
				{
					title: 'Converter',
					route: '/converter',
					icon: 'loop',
					routeName: 'converter'
				},
				{
					title: 'API',
					route: '/api-doc',
					icon: 'wifi_tethering',
					routeName: 'apiDoc'
				},
				{
					title: 'About',
					route: '/about',
					icon: 'person',
					routeName: 'about'

				},
				{
					title: 'Fork Me!',
					externalLink: 'https://github.com/BaronChen/numberWordConvert',
					icon: 'github-circle',
					routeName: 'Fork'
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

			$scope.isActive = function(routeName)
			{
				return $route.current.name === routeName;
			}
		}
	};
}
]);