
(function () {

    var app = angular.module('SocialModule');
    /*
    Service function should return an object with methods
    to expose. Here is our service function.
    */
    var myServiceFunc = function ($http) {

        var myClientAPI = {};

        myClientAPI.getPosts = function () {
            return $http({
                method: 'GET',
                url: '/api/Values/GetAllPosts'
            });
        };
        myClientAPI.getRecentPosts = function (maxid) {
            return $http({
                method: 'GET',
                url: '/api/Values/GetRecentPosts?id=' + maxid
            });
        };

        myClientAPI.verifyUser = function (user) {
            return $http.post('/api/Values/VerifyUser', user);
        }

        return myClientAPI;
    }; //end of myServiceFunc

    //Register service function in factory with a name
    app.factory('SocialService', myServiceFunc);
})();