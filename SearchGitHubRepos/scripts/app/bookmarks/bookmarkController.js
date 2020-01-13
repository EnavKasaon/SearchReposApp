app.controller('bookmarkController', ['$scope', '$http', 'CommonSrv', function ($scope, $http, CommonSrv) {
    var bookmarkAddURL = "http://localhost:58610/Bookmarks/AddBookmark";
    var GetAllbookmarkURL = "http://localhost:58610/Bookmarks/GetAll";

    $scope.success = false;
    $scope.allBookmarks = [];
    //$rootScope.CommonSrv = CommonSrv;
    CommonSrv.showAlert("test", true);

    /// Add new Bookmark
    $scope.AddBookmarkCall = function (rep) { 
        $http.post(bookmarkAddURL, rep)
        .then(function (response) {
            $scope.success = true;
            if (response.data == true) {
                var successMessage = "Repository added successfully!";
                var successMessagebool = true;
                window.alert(successMessage);
                //CommonSrv.showAlert(successMessage, successMessagebool);
            }
          console.log(response.data);
      });
    };

    /// Get all saved bookmarks
    $http({
        url: GetAllbookmarkURL,
        method: "GET"
    })
     .then(function (response) {
         $scope.allBookmarks = response.data;
         console.log("Print Bookmarks Array:");
     });


}]);