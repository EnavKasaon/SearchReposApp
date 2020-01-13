app.service("CommonSrv", function ($rootScope) {
    this.showAlert = function (message, status) {
        $rootScope.alertMessage = message;
        $rootScope.showAlert = status;
    }
    this.hideAlert = function () {
        $rootScope.showAlert = false;
    }
});