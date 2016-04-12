app.directive('sidenavDirective', ['$location', '$mdSidenav', '$state', function ($location, $mdSidenav, $state) {

	return {
		restrict: 'E',
		scope: {
		},
		controller: 'sidenavDirectiveController',
		controllerAs: 'ctrl',
		bindToController: true,
		templateUrl: 'app/directives/sidenav/sidenavDirective.html',
		link: function ($scope, element, attrs) {
			$scope.$state = $state;

			$scope.currentStateName = $state.current.name;

			$scope.toggleMenu = function () {
				$mdSidenav('left').toggle();
			}

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

		
		}
	};
}
]);