'use strict';

var app = angular.module('myApp', ['ui.router', 'ngMaterial', 'ngAria', 'ngMessages', 'ngMdIcons']);

app.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', '$mdIconProvider', '$mdThemingProvider',
  function ($stateProvider, $urlRouterProvider, $locationProvider, $mdIconProvider, $mdThemingProvider) {
  	$urlRouterProvider.otherwise("/converter");
  	$stateProvider
		.state('converter', {
			url: "/converter",
			templateUrl: 'app/views/converter.html',
			controller: 'converterController',
			controllerAs: 'vm'
		})
		.state('apiDoc', {
			url: "/api-doc",
			templateUrl: 'app/views/api-doc.html',
			controller: 'apiDocController',
			controllerAs: 'vm'
		})
		.state('about', {
			url: "/about",
			templateUrl: 'app/views/about.html',
			controller: 'aboutController',
			controllerAs: 'vm'
		});

  	$locationProvider.html5Mode(true);

  	$mdIconProvider.defaultIconSet("/app/assets/svg/avatars.svg", 128)
		  .icon("menu", "/app/assets/svg/menu.svg", 24);

  	$mdThemingProvider.theme('default')
			 .primaryPalette('cyan')
			 .accentPalette('light-blue');


  }]);