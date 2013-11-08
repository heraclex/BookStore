requirejs.config({
    paths: {
        'text': 'framework/amd/text',
        'durandal': 'framework/durandal',
        'plugins': 'framework/durandal/plugins',
        'transitions': 'framework/durandal/transitions',
        'knockout': '../Scripts/knockout-2.1.0',
        'bootstrap': '../Scripts/bootstrap',
        'jquery': '../Scripts/jquery-2.0.3'
    },
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
       }
    }
});

define(['durandal/system', 'durandal/app', 'durandal/viewLocator'],  function (system, app, viewLocator) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'Durandal Starter Kit';

    app.configurePlugins({
        router:true,
        dialog: true,
        widget: true
    });

    app.start().then(function() {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();

        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell', 'entrance');
    });
});