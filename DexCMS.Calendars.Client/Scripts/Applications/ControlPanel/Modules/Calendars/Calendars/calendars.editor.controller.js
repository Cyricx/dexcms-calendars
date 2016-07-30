define([
    'controlpanel-app'
], function (app) {
    app.controller('calendarsEditorCtrl', [
        '$scope',
        'Calendars',
        '$stateParams',
        '$state',
        function ($scope, Calendars, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Calendar";

            $scope.currentItem = {};

            if (id != null) {
                Calendars.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.calendarID) {
                    Calendars.updateItem(item.calendarID, item).then(function (response) {
                        $state.go('calendars');
                    });
                } else {
                    Calendars.createItem(item).then(function (response) {
                        $state.go('calendars');
                    });
                }
            }
        }
    ]);
});