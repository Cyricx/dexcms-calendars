module.exports = function (appPath, overrides) {
    return {
        name: 'ApplicationsControlPanelNavigation',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.navigaion.json',
        options: [
            {
                "title": "Calendar",
                "icon": "fa-calendar",
                "subLinks": [
                    {
                        "title": "Calendars",
                        "href": overrides.calendars || "calendars"
                    },
                    {
                        "title": "Calendar Events",
                        "href": overrides.calendarevents ||  "calendarevents"
                    },
                    {
                        "title": "Event Locations",
                        "href": overrides.calendareventlocations || "calendareventlocations"
                    },
                    {
                        "title": "Event Statuses",
                        "href": overrides.calendareventstatuses || "calendareventstatuses"
                    },
                    {
                        "title": "Event Types",
                        "href": overrides.calendareventtypes || "calendareventtypes"
                    }
                ]
            },
        ]
    };
};