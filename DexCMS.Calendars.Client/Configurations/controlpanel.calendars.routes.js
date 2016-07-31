module.exports = function (appPath) {
    return {
        name: 'ApplicationsControlPanelRoutes',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.routes.json',
        options: [
            {
                "name": "calendarEvents",
                "module": "calendars"
            },
            {
                "name": "calendarEventLocations",
                "module": "calendars"
            },
            {
                "name": "calendarEventStatuses",
                "module": "calendars"
            },
            {
                "name": "calendarEventTypes",
                "module": "calendars"
            },
            {
                "name": "calendars",
                "module": "calendars"
            },
        ]
    };
};