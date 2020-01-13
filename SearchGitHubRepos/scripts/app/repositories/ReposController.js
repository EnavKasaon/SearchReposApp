app.controller('searchReposController', ['$scope', '$http', 'CommonSrv', function ($scope, $http, CommonSrv) {
    $scope.name = 'Angular ';
    var repositories = [];
    var term = $scope.searchTerm;
    var repoURL = "http://localhost:58610/Repositories/GetRepositories";
    CommonSrv.showAlert("test", true);

    //$rootScope.CommonSrv = CommonSrv;


    $scope.resultCall = function (term) {
        $http({
            url: repoURL,
            method: "GET",
            params: { term: term }
        })
      .then(function (response) {
          $scope.repositories = response.data;
          console.log("Print Repos Array:");
      });
        console.log($scope.repositories);
    };

}]);
