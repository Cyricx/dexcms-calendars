define([
    'controlpanel-app',
    '../calendars/calendars.service',
    '../calendareventtypes/calendareventtypes.service',
    '../calendareventstatuses/calendareventstatuses.service',
    '../calendareventlocations/calendareventlocations.service',
], function (app) {
    app.controller('calendarEventsEditorCtrl', [
        '$scope',
        'CalendarEvents',
        '$stateParams',
        '$state',
        'Calendars',
        'CalendarEventTypes',
        'CalendarEventStatuses',
        'CalendarEventLocations',
        function ($scope, CalendarEvents, $stateParams, $state, Calendars, CalendarEventTypes, CalendarEventStatuses, CalendarEventLocations) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Calendar Event";

            $scope.currentItem = { isRepeating: false, disabled: false };

            if (id != null) {
                CalendarEvents.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.isAllDay) {
                    item.endDate = null;
                }
                if (item.calendarEventLocationID) {
                    item.location = undefined;
                }
                if (item.calendarEventID) {
                    CalendarEvents.updateItem(item.calendarEventID, item).then(function (response) {
                        $state.go('calendarevents');
                    });
                } else {
                    CalendarEvents.createItem(item).then(function (response) {
                        $state.go('calendarevents');
                    });
                }
            };

            Calendars.getList().then(function (response) {
                $scope.calendars = response;
            });
            CalendarEventTypes.getList().then(function (response) {
                $scope.calendarEventTypes = response;
            });
            CalendarEventStatuses.getList().then(function (response) {
                $scope.calendarEventStatuses = response;
            });
            CalendarEventLocations.getList().then(function (response) {
                $scope.calendarEventLocations = response;
            });
        }
    ]);
});