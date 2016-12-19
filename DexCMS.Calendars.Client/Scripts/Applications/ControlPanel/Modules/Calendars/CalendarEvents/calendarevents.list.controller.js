define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarEventsListCtrl', [
        '$scope',
        'CalendarEvents',
        '$window',
        '$filter',
        'dexCMSControlPanelSettings',
        function ($scope, CalendarEvents, $window, $filter, dexcmsSettings) {
            $scope.title = "View Calendar Events";

            var _renderDate = function (value, item) {
                if (value != null) {
                    if (!item.isAllDay) {
                        return $filter('date')(value, "MM/dd/yyyy h:mm a");
                    } else {
                        return $filter('date')(value, "MM/dd/yyyy");
                    }
                } else {
                    return null;
                }
            };

            $scope.table = {
                columns: [
                    { property: 'calendarEventID', title: 'ID' },
                    { property: 'title', title: 'Title' },
                    {
                        property: 'startDate', title: 'Start',
                        dataFunction: _renderDate
                    },
                    {
                        property: 'endDate', title: 'End',
                        dataFunction: _renderDate
                    },
                    { property: 'calendarEventTypeName', title: 'Type' },
                    { property: 'calendarEventStatusName', title: 'Status' },
                    { property: 'isDisabled', title: 'Disabled?' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/calendars/calendarevents/_calendarevents.list.buttons.html'
                    }
                ],
                defaultSort: 'calendarEventID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            CalendarEvents.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Calendar-Events'
            };

            CalendarEvents.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});