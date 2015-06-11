App.appModule.controller(App.names.controllers.taskController.name, ['$scope', 'Task', function ($scope, Task) {
    $scope.tasks = Task.query();
}]);