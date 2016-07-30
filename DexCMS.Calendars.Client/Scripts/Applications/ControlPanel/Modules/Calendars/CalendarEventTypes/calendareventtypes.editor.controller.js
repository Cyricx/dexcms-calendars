define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarEventTypesEditorCtrl', [
        '$scope',
        'CalendarEventTypes',
        '$stateParams',
        '$state',
        function ($scope, CalendarEventTypes, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Event Type";

            $scope.currentItem = {};

            if (id != null) {
                CalendarEventTypes.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.calendarEventTypeID) {
                    CalendarEventTypes.updateItem(item.calendarEventTypeID, item).then(function (response) {
                        $state.go('calendareventtypes');
                    });
                } else {
                    CalendarEventTypes.createItem(item).then(function (response) {
                        $state.go('calendareventtypes');
                    });
                }
            }
        }
    ]);
});