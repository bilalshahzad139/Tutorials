

(function () {
    //Get 'SocialModule'
    var app = angular.module("SocialModule");

    //Create a new controller
    app.controller("HomeCtrl", function ($scope, $http) {
        $scope.message = "Welcome on my Book!";
        $scope.posts = [];
        $scope.user = {};

        $scope.verify = function () {

            $http.post(
                 '/api/Values/VerifyUser', $scope.user).success(function (data) {

                     if (data == true) {
                         $scope.showerrormsg = false;
                     }
                     else {
                         $scope.showerrormsg = true;
                     }
                 });
        };

        $scope.getPosts = function () {
            $http({
                method: 'GET',
                url: '/api/Values/GetAllPosts'
            }).then(function successCallback(response) {
                $scope.posts = response.data;

            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
        }

        $scope.deleteMe = function (obj) {
            var ind = $scope.posts.indexOf(obj.p);
            $scope.posts.splice(ind, 1);
        }
    });
})();

