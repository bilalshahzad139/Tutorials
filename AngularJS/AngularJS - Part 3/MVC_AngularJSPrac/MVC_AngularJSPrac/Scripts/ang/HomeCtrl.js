

(function () {
    //Get 'SocialModule'
    var app = angular.module("SocialModule");

    //Create a new controller
    app.controller("HomeCtrl", function ($scope, $http, $document,
                                            $interval, SocialService) {
        $scope.message = "Welcome on my Book!";
        $scope.posts = [];
        $scope.user = {};

        $document.ready(function () {
            $scope.getPosts();
        });
        $interval(function () {
            //here logic to get max id
            var maxId = $scope.posts.length;
            SocialService.getRecentPosts(maxId).then(function (response) {
                for (var i = 0; i < response.data.length; i++) {
                    //unshift pushes element at top of array
                    $scope.posts.unshift(response.data[i]);
                }
            });
        }, 2000);

        $scope.verify = function () {
            SocialService.verifyUser($scope.user).then(function (response) {

                if (response.data == true) {
                    $scope.showerrormsg = false;
                }
                else {
                    $scope.showerrormsg = true;
                }
            });
        };

        $scope.getPosts = function () {
            SocialService.getPosts().then(function (response) {
                $scope.posts = response.data;
            });
        }

        $scope.deleteMe = function (obj) {
            var ind = $scope.posts.indexOf(obj.p);
            $scope.posts.splice(ind, 1);
        }
    });
})();

