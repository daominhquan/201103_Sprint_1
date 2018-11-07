(function () {
    "use strict"
    var app = angular.module("app");
    app.component("customerList", {
        templateUrl: "~/App/Main/views/Customers/customer.cshtml",
        controllerAs: "vm",
        controller: [Controller]
    });
    function Controller() {
        debugger
        var vm = this;
    }
})();