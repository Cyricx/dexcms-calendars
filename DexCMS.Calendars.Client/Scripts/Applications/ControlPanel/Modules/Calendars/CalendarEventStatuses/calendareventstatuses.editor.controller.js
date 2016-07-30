define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarEventStatusesEditorCtrl', [
        '$scope',
        'CalendarEventStatuses',
        '$stateParams',
        '$state',
        function ($scope, CalendarEventStatuses, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Event Status";

            $scope.currentItem = {};

            if (id != null) {
                CalendarEventStatuses.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.calendarEventStatusID) {
                    CalendarEventStatuses.updateItem(item.calendarEventStatusID, item).then(function (response) {
                        $state.go('calendareventstatuses');
                    });
                } else {
                    CalendarEventStatuses.createItem(item).then(function (response) {
                        $state.go('calendareventstatuses');
                    });
                }
            }
        }
    ]);
});