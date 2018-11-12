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
            customerService.listAll()
                .then(function (result) {
                    vm.customers = result.data;
                });
        }
        getCustomers();

        //Open Modal to create new customer
        vm.openModelforNew = function () {
            $('#myModal').modal('show')
            vm.showSubmit = true;
            vm.showEdit = false;
            vm.showID = false;
            vm.customer.CustomerName = '';
            vm.customer.PhoneNumber = '';
        }
        //Open Modal to update new customer data
        vm.openModalforUpdate = function (data) {
            $('#myModal').modal('show')
            vm.showSubmit = false;
            vm.showEdit = true;
            vm.entity = data;
            vm.customer.Id = data.id;
            vm.customer.CustomerName = data.customerName;
            vm.customer.PhoneNumber = data.phoneNumber;
        }

        //save data
        vm.save = function () {
            abp.ui.setBusy();
            customerService.create(vm.customer)
                .then(function () {
                    abp.notify.info(App.localize('Thêm thành công'));
                    $('#myModal').modal('hide');
                    $uibModalInstance.close();
                }).finally(function () {
                    abp.ui.clearBusy();
                    getCustomers();
                });
        };



        vm.edit = function (data) {
            abp.ui.setBusy();
            customerService.update(vm.customer)
                .then(function () {
                    abp.notify.info(App.localize('Sửa thành công '));
                    $('#myModal').modal('hide'); 
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
        vm.delete = function (id,customerName) {
            abp.message.confirm(
                "Xóa Customer '" + customerName + "'?",
                function (result) {
                    if (result) {
                        var x = { id };
                        abp.ui.setBusy();
                        customerService.delete(x)
                            .then(function () {
                                abp.notify.info(App.localize('Delete Customer ' + customerName +' Thành công'));
                                $uibModalInstance.close();
                            }).finally(function () {
                                abp.ui.clearBusy();
                                getCustomers();
                            })
                    }
                });
            
        }

    }
})();