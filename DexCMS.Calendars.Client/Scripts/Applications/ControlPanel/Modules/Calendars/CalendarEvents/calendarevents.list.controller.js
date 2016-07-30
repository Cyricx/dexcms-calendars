define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarEventsListCtrl', [
        '$scope',
        'CalendarEvents',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        '$filter',
        function ($scope, CalendarEvents, DTOptionsBuilder, DTColumnBuilder, $compile, $window, $filter) {
            $scope.title = "View Calendar Events";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return CalendarEvents.getList();
            }).withBootstrap().withOption('createdRow', createdRow)
            .withOption('aaSorting', [2, 'desc']);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('calendarEventID').withTitle('ID'),
                DTColumnBuilder.newColumn('title').withTitle('Title'),
                DTColumnBuilder.newColumn('startDate').withTitle('Start').renderWith(dateHtml),
                DTColumnBuilder.newColumn('endDate').withTitle('End').renderWith(dateHtml),
                DTColumnBuilder.newColumn('calendarEventTypeName').withTitle('Type'),
                DTColumnBuilder.newColumn('calendarEventStatusName').withTitle('Status'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }
            function dateHtml(data, type, full, meta) {
                if (data != null) {
                    if (!full.isAllDay) {
                        return $filter('date')(data, "MM/dd/yyyy h:mm a");
                    } else {
                        return $filter('date')(data, "MM/dd/yyyy");
                    }
                } else {
                    return null;
                }

            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="calendarevents/:id({id:' + data.calendarEventID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.calendarEventID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    CalendarEvents.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});