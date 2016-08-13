define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarEventTypesListCtrl', [
        '$scope',
        'CalendarEventTypes',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, CalendarEventTypes, $window, dexcmsSettings) {
            $scope.title = "View Event Types";

            $scope.table = {
                columns: [
                    { property: 'calendarEventTypeID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'isActive', title: 'Active?' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/calendars/calendareventtypes/_calendareventtypes.list.buttons.html'
                    }
                ],
                defaultSort: 'calendarEventTypeID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            CalendarEventTypes.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Calendar-Event-Types'
            };

            CalendarEventTypes.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});