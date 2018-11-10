(function () {
    "use strict"
    var app = angular.module("app");
    app.component("customerList", {
        templateUrl: "~/App/Main/views/Customers/customer.cshtml",
        controllerAs: "vm",
        controller: ['abp.services.app.customer',Controller]
    });
    function Controller(customerService) {  
        var vm = this;
        vm.customers = [];
        vm.showSubmit = true;
        vm.showEdit = false;
        vm.customer = {
            CustomerName: '',
            PhoneNumber:''
        }


        //get all customer data from database
        function getCustomers() {
            debugger
            customerService.getAll({})
                .then(function (result) {
                    vm.customers = result.data.items;
                });
        }
        getCustomers();

        //Open Modal to create new customer
        vm.openModelforNew = function () {
            $('#myModal').modal('show')
            vm.showSubmit = true;
            vm.showEdit = false;
            vm.customer.CustomerName = '';
            vm.customer.PhoneNumber = '';
        }
        //Open Modal to update new customer data
        vm.openModalforUpdate = function (data) {
            $('#myModal').modal('show')
            vm.showSubmit = false;
            vm.showEdit = true;
            vm.entity = data;
        }

        //save data
        vm.save = function () {
            abp.ui.setBusy();
            customerService.create(vm.customer)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    abp.ui.clearBusy();
                    getCustomers();
                });
        };
        vm.cancel = function () {
            $uibModalInstance.dismiss({});
        };
        vm.refresh = function () {
            getCustomers();
        };
        vm.delete = function (customer) {
            abp.message.confirm(
                "Delete customer '" + customer.CustomerName + "'?",
                function (result) {
                    if (result) {
                        customerService.delete({ id: customer.id })
                            .then(function () {
                                abp.notify.info("Deleted customer: " + customer.CustomerName);
                                getCustomers();
                            });
                    }
                });
        }

    }
})();