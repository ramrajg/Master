/**
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    System.config({
        paths: {
            // paths serve as alias
            'npm:': 'node_modules/'
        },
        // map tells the System loader where to look for things
        map: {
            // our app is within the app folder
            'app': 'app',

            // angular bundles
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
            '@progress/kendo-angular-dropdowns': 'npm:@progress/kendo-angular-dropdowns',
            '@progress/kendo-angular-popup': 'npm:@progress/kendo-angular-popup',
            '@progress/kendo-popup-common': 'npm:@progress/kendo-popup-common',
            '@progress/kendo-angular-resize-sensor': 'npm:@progress/kendo-angular-resize-sensor',
            '@progress/kendo-angular-l10n': 'npm:@progress/kendo-angular-l10n',
            '@telerik/kendo-dropdowns-common': 'npm:@telerik/kendo-dropdowns-common',
            '@progress/kendo-angular-buttons': 'npm:@progress/kendo-angular-buttons',
            '@progress/kendo-angular-intl': 'npm:@progress/kendo-angular-intl',
            '@progress/kendo-angular-layout': 'npm:@progress/kendo-angular-layout',
            '@progress/kendo-angular-inputs': 'npm:@progress/kendo-angular-inputs',
            '@telerik/kendo-inputs-common': 'npm:@telerik/kendo-inputs-common',
            '@progress/kendo-angular-dialog': 'npm:@progress/kendo-angular-dialog',
            '@telerik/kendo-draggable': 'npm:@telerik/kendo-draggable',
            '@telerik/kendo-intl': 'npm:@telerik/kendo-intl',
            
            '@angular/animations': 'npm:@angular/animations/bundles/animations.umd.js',
            // other libraries
            'rxjs': 'npm:rxjs',
            'angular-in-memory-web-api': 'npm:angular-in-memory-web-api/bundles/in-memory-web-api.umd.js'
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            app: {
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: 'systemjs-angular-loader.js'
                    }
                }
            },
            rxjs: {
                defaultExtension: 'js'
            },
            '@progress/kendo-angular-dropdowns': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },

            '@progress/kendo-angular-popup': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },
            '@progress/kendo-angular-common': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },
            '@progress/kendo-angular-resize-sensor': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },
            '@progress/kendo-popup-common': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },
            '@progress/kendo-angular-l10n': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },
            '@progress/kendo-angular-buttons': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },
            '@progress/kendo-angular-intl': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },

            '@telerik/kendo-dropdowns-common': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },
            '@telerik/kendo-inputs-common': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },
            '@telerik/kendo-draggable': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },
            '@telerik/kendo-intl': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },

            

            '@progress/kendo-angular-layout': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },

            '@progress/kendo-angular-inputs': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            },

            '@progress/kendo-angular-dialog': {
                main: './dist/npm/main.js',
                defaultExtension: 'js'
            }

        }
    });
})(this);
