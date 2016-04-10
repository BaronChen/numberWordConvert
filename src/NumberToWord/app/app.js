'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngMaterial', 'ngAria']);

app.config(['$routeProvider', '$locationProvider', '$mdIconProvider',
  function ($routeProvider, $locationProvider, $mdIconProvider) {
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

	var rootUrl = 'http://localhost:12975';

  	$mdIconProvider.defaultIconSet("/app/assets/svg/avatars.svg", 128)
		.icon("menu",  "/app/assets/svg/menu.svg", 24)

  }]);