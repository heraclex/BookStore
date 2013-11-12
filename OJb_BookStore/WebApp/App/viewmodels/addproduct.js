define(function () {
    var addproductViewModel = function () {
        this.displayName = 'Welcome to Add Product Page';
        this.description = 'Add Product';
        this.items = [
            'item 1',
            'item 2',
            'item 3',
            'item 4',
            'item 5'];
    };

    //Note: This module exports a function. That means that you, the developer, can create multiple instances.
    //This pattern is also recognized by Durandal so that it can create instances on demand.
    //If you wish to create a singleton, you should export an object instead of a function.
    //See the "flickr" module for an example of object export.

    return addproductViewModel;
});