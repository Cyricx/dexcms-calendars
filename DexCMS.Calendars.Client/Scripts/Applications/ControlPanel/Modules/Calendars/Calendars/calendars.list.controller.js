define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarsListCtrl', [
        '$scope',
        'Calendars',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, Calendars, $window, dexcmsSettings) {
            $scope.title = "View Calendars";

            $scope.table = {
                columns: [
                    { property: 'calendarID', title: 'ID' },
                    { property: 'title', title: 'Title' },
                    { property: 'isActive', title: 'Active?' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/calendars/calendars/_calendars.list.buttons.html'
                    }
                ],
                defaultSort: 'calendarID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            Calendars.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Calendars'
            };

            Calendars.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});