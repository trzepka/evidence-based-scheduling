planningControllers.controller('taskCtrl',['$scope', 'Task',  function ($scope, Task) {
    $scope.tasks = Task.query();
}]);