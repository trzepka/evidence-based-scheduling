'use strict';

App.appModule
    .factory('Task', ['$resource',
        function ($resource) {
            return $resource('api/tasks/', {}, {
                query: { method: 'GET', isArray: true },
                userSchedules: { method: 'GET', isArray: true, url: 'api/tasks/userSchedules' }
            });
        }]);

App.appModule
.factory('Auth', function ($http, $cookieStore) {

    var accessLevels = routingConfig.accessLevels
        , userRoles = routingConfig.userRoles
        , currentUser = $cookieStore.get('user') || { username: '', role: userRoles.public };

    $cookieStore.remove('user');

    function changeUser(user) {
        angular.extend(currentUser, user);
    }

    return {
        authorize: function (accessLevel, role) {
            if (role === undefined) {
                role = currentUser.role;
            }

            return accessLevel.bitMask & role.bitMask;
        },
        isLoggedIn: function (user) {
            if (user === undefined) {
                user = currentUser;
            }
            return user.role.title === userRoles.user.title || user.role.title === userRoles.admin.title;
        },
        login: function (user, success, error) {
            $http.post("/api/auth/login", user).success(function (user) {
                changeUser(user);
                success(user);
            }).error(error);
        },
        logout: function (success, error) {
            $http.post('/api/auth/logout').success(function () {
                changeUser({
                    username: '',
                    role: userRoles.public
                });
                success();
            }).error(error);
        },
        accessLevels: accessLevels,
        userRoles: userRoles,
        user: currentUser
    };
});