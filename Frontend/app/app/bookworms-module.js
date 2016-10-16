(function () {
    'use strict';

    console.log(angular);
    angular.module('bookworms', ['ui.router'])
        .config(function ($stateProvider, $urlRouterProvider) {     
            $urlRouterProvider.otherwise('/home');
            $stateProvider
                .state('home', {
                    url: '/home',
                    templateUrl: 'app/home/home.html',
                    controller: 'HomeController',
                    controllerAs: 'home'
                });
        })
        .constant('BASE_URL', 'http://localhost:54968');

} ());