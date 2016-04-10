'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngMaterial', 'ngAria', 'ngMessages', 'ngMdIcons']);

app.config(['$routeProvider', '$locationProvider', '$mdIconProvider','$mdThemingProvider',
  function ($routeProvider, $locationProvider, $mdIconProvider, $mdThemingProvider) {
  	$routeProvider.
      when('/converter', {
      	templateUrl: 'app/views/converter.html',
      	controller: 'converterController',
      	controllerAs: 'vm'
      }).
      otherwise({
      	redirectTo: '/'
      });

  	$locationProvider.html5Mode(true);

	$mdIconProvider.defaultIconSet("/app/assets/svg/avatars.svg", 128)
		  .icon("menu", "/app/assets/svg/menu.svg", 24);

	$mdThemingProvider.theme('default')
			 .primaryPalette('cyan')
			 .accentPalette('light-blue');


  }]);