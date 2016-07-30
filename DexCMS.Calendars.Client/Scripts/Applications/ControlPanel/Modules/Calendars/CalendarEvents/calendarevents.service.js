define([
    'controlpanel-app',
    'angular',
], function (app, angular) {
    app.service('CalendarEvents', [
        '$resource',
        '$http',
        'DexCmsDateCleaner',
        function ($resource, $http, DateCleaner) {
            var baseUrl = '../api/calendarEvents';

            var _forServer = function (item) {
                var adjustedItem = angular.copy(item);

                adjustedItem.startDate = DateCleaner.preServerProcess(adjustedItem.startDate);

                if (adjustedItem.endDate) {
                    adjustedItem.endDate = DateCleaner.preServerProcess(adjustedItem.endDate);
                }

                return adjustedItem;
            };

            var _fromServer = function (item) {
                item.startDate = DateCleaner.correctTimeZone(item.startDate);
                if (item.endDate) {
                    item.endDate = DateCleaner.correctTimeZone(item.endDate);
                }
            }

            return {
                //Create new record
                createItem: function (item) {
                    var request = $http({
                        method: "post",
                        url: baseUrl,
                        data: _forServer(item)
                    });
                    return request;
                },
                //Get Single Records
                getItem: function (id) {
                    return $http.get(baseUrl + "/" + id).then(function (response) {
                        _fromServer(response.data);
                        return response;
                    });
                },
                //Get All 
                getList: function () {
                    return $resource(baseUrl).query().$promise.then(function (response) {
                        angular.forEach(response, function (data) {
                            _fromServer(data);
                        });
                        return response;
                    });
                },
                //Update the Record
                updateItem: function (id, item) {
                    var request = $http({
                        method: "put",
                        url: baseUrl + "/" + id,
                        data: _forServer(item)
                    });
                    return request;
                },
                //Delete the Record
                deleteItem: function (id) {
                    var request = $http({
                        method: "delete",
                        url: baseUrl + "/" + id
                    });
                    return request;
                },
            }
        }
    ]);
});