var gulp = require('gulp');
var browserSync = require('browser-sync').create();
var inject = require('gulp-inject');


gulp.task('watch-css', function () {
    return gulp.src('./app/styles/**/*.css')
        .pipe(gulp.dest('./app/styles'))
        .pipe(browserSync.stream());
});

gulp.task('watch-js', function () {
    return browserSync.reload();
});

gulp.task('inject', function() {
    return gulp.src('./app/index.html')
        .pipe(inject(gulp.src(['./app/**/*.js', './app/**/*.css'])))
        .pipe(gulp.dest('./app'));
});

gulp.task('start', ['inject'], function () {
    browserSync.init({
        server: {
            baseDir: 'app'
        }
    });

    gulp.watch('./app/styles/**/*.css', ['watch-css']);
    gulp.watch('./app/app/*.js', ['watch-js']);
    gulp.watch("app/**/*.html").on('change', browserSync.reload);
});