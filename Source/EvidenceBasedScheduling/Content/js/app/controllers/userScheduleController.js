App.appModule.controller('userScheduleCtrl', ['$scope', 'Task',
    function ($scope, Task) {
        var userSchedules = Task.userSchedules(function() {
            var userScheduleGraph = new App.UserScheduleGraph("user-schedule-graph", userSchedules);
            userScheduleGraph.draw();
        });
    }]);