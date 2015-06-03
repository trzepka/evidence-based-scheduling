var phonecatServices = angular.module('tasksServices', ['ngResource']);

phonecatServices.factory('Task', ['$resource',
  function ($resource) {
      return $resource('api/tasks/', {}, {
          query: { method: 'GET', isArray: true },
          userSchedules: { method: 'GET', isArray: true, url: 'api/tasks/userSchedules' }
      });
  }]);