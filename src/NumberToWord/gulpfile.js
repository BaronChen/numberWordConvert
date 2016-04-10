/// <binding BeforeBuild='build-dev' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var gutil = require('gulp-util');
var del = require('del');
var sq = require('gulp-sequence');


gulp.task('default', function () {
    // place code for your default task here
});

gulp.task('clean-wwwroot', function(done) {
	gutil.log('Cleaning JavaScript...');
	del(['./wwwroot/**/*.js', './wwwroot/**/*.js.map', './wwwroot/index.html','./wwwroot/app/**', '!./wwwroot/lib/**/*']).then(function() {
		done();
	});
});

gulp.task('copy-dev', function () {
	gutil.log('Copying js files for DEV...');
	gulp.src(['./app/**/*'], { base: 'app' }).pipe(gulp.dest('./wwwroot/app'));
});

gulp.task('build-index-dev', function () {
	gutil.log('Copying index.html for dev...');
	gulp.src('./index.html').pipe(gulp.dest('./wwwroot'));
});

gulp.task('build-dev', sq('clean-wwwroot', 'build-index-dev', 'copy-dev'));