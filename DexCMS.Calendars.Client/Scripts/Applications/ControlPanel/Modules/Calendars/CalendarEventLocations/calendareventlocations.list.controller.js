define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarEventLocationsListCtrl', [
        '$scope',
        'CalendarEventLocations',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, CalendarEventLocations, $window, dexcmsSettings) {
            $scope.title = "View Event Locations";

            $scope.table = {
                columns: [
                    { property: 'calendarEventLocationID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'isActive', title: 'Active?' },
                    { property: 'displayOrder', title: 'Order' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/calendars/calendareventlocations/_calendareventlocations.list.buttons.html'
                    }
                ],
                defaultSort: 'calendarEventLocationID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            CalendarEventLocations.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Calendar-Event-Locations'
            };

            CalendarEventLocations.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});