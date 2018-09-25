var gulp = require('gulp'),
    config = require('./appsettings');

var rootFolder = 'wwwroot/'; 

gulp.task('build', [
    'copy:general-files',
    'copy:project-files'
]);

gulp.task('copy:general-files', function () {
    return gulp.src(rootFolder + 'general/**')
        .pipe(gulp.dest(rootFolder));
});

gulp.task('copy:project-files', ['copy:general-files'], function () {
    console.log('project - ' + config.Project);

    var base = rootFolder + '/' + config.Project;

    return gulp.src([
        base + '/**'
        ])
        .pipe(gulp.dest(rootFolder));
});