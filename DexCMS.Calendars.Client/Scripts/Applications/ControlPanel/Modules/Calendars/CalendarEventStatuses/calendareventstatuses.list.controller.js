define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarEventStatusesListCtrl', [
        '$scope',
        'CalendarEventStatuses',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, CalendarEventStatuses, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Event Statuses";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return CalendarEventStatuses.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('calendarEventStatusID').withTitle('ID'),
                DTColumnBuilder.newColumn('name').withTitle('Name'),
                DTColumnBuilder.newColumn('isActive').withTitle('Active?'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="calendareventstatuses/:id({id:' + data.calendarEventStatusID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                if (data.calendarEventCount == 0) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.calendarEventStatusID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    CalendarEventStatuses.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});