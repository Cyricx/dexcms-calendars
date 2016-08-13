define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarEventStatusesListCtrl', [
        '$scope',
        'CalendarEventStatuses',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, CalendarEventStatuses, $window, dexcmsSettings) {
            $scope.title = "View Event Statuses";

            $scope.table = {
                columns: [
                    { property: 'calendarEventStatusID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'isActive', title: 'Active?' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/calendars/calendareventstatuses/_calendareventstatuses.list.buttons.html'
                    }
                ],
                defaultSort: 'calendarEventStatusID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            CalendarEventStatuses.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Calendar-Event-Statuses'
            };

            CalendarEventStatuses.getList().then(function (data) {
                $scope.table.promiseData = data;
            });

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
        }
    ]);
});