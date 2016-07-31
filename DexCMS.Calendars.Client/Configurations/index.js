var cpNavigation = require('./controlpanel.calendars.navigation'),
    cpRoutes = require('./controlpanel.calendars.routes');

module.exports = function (appPath, overrides) {
    overrides = overrides || {};
    overrides.navigation = overrides.navigation || {};

    var settings = [];
    settings.push(cpNavigation(appPath, overrides.navigation));
    settings.push(cpRoutes(appPath));
    return settings;
};