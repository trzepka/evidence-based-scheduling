App.appModule.controller('userScheduleCtrl', ['$scope', 'Task',
    function ($scope, Task) {
        $scope.showUnestimatedTasks = true;
        $scope.showUnassignedTasks = true;
        var userSchedules = Task.userSchedules(function() {
            $scope.userScheduleGraph = new App.UserScheduleGraph("user-schedule-graph", userSchedules, $scope.showUnassignedTasks);
            $scope.userScheduleGraph.draw();
        });

        $scope.toggleUnassignedTasks = function () {
            $scope.userScheduleGraph.showUnassignedTasks = $scope.showUnassignedTasks;
        };
    }]);