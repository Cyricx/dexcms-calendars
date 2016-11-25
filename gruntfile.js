/// <binding BeforeBuild='clean' AfterBuild='copy' />
module.exports = function (grunt) {
    //Configuration setup
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        copy: {
            domain: {
                expand: true,
                cwd: 'DexCMS.Calendars/bin/Release/',
                src: ['DexCMS.Calendars.dll'],
                dest: 'dist/'
            },
            mvc: {
                expand: true,
                cwd: 'DexCMS.Calendars.Mvc/bin/Release/',
                src: ['DexCMS.Calendars.Mvc.dll'],
                dest: 'dist/'
            },
            webapi: {
                expand: true,
                cwd: 'DexCMS.Calendars.WebApi/bin/Release/',
                src: ['DexCMS.Calendars.WebApi.dll'],
                dest: 'dist/'
            }
        },
        clean: {
            build: ["dist"]
        }
    });

    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-clean');

    grunt.registerTask('default', ['clean', 'copy']);
};
