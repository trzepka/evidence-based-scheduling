var App = {};

var taskPlanningApp = angular.module('taskPlanningApp', [
  'ngRoute',
  'planningControllers',
  'tasksServices'
]);

taskPlanningApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider
        .when('/tasks', {
            templateUrl: 'Partial/task-list.html',
            controller: 'taskCtrl'
        })
        .when('/', {
            templateUrl: 'Partial/user-schedule.html',
            controller: 'userScheduleCtrl'
        })
        .otherwise({
            redirectTo: '/'
        });
  }]);

var planningControllers = angular.module('planningControllers', []);