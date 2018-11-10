(function () {
    angular.module('app').controller('app.views.Customers.index', [
        '$scope', '$uibModal', 'abp.services.app.customer',
        function ($scope, $uibModal, customerService) {
            var vm = this;

            vm.customers = [];

            function getCustomers() {
                customerService.getAll({}).then(function (result) {
                    vm.customers = result.data.items;
                });
            }

            vm.openCustomerCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/Customers/createModal.cshtml',
                    controller: 'app.views.Customers.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getCustomers();
                });
            };

            vm.openCustomerEditModal = function (customer) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/Customers/editModal.cshtml',
                    controller: 'app.views.Customers.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return customer.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getCustomers();
                });
            }

            vm.delete = function (customer) {
                abp.message.confirm(
                    "Delete customer '" + customer.customername + "'?",
                    function (result) {
                        if (result) {
                            customerService.delete({ id: customer.id })
                                .then(function () {
                                    abp.notify.info("Deleted customer: " + customer.customername);
                                    getCustomers();
                                });
                        }
                    });
            }

            vm.refresh = function() {
                getCustomers();
            };

            getCustomers();
        }
    ]);
})();