;
(function ($, Ojb, undefined) {
    Ojb.NameSpace = function () { };
    Ojb.NameSpace.prototype = {
        
        Name: 'Ojb.NameSpace',
        
        getType: function () {
            return this.Name;
        }
    };
    
})(jQuery, window.Ojb = window.Ojb || {});

;
(function ($, Ojb, undefined) {

    //Ojb.NameSpace.ClassName1 = function () { };
    //Ojb.NameSpace.ClassName1.prototype = {
    //    base: new Ojb.NameSpace(),
    //    Name: 'ClassName1',

    //    getType: function () {
    //        this.base.getType();
    //    }
    //};
    
    Ojb.NameSpace.ClassName1 = function () { };
    Ojb.NameSpace.ClassName1.prototype = {
        base: new Ojb.NameSpace(),

        init: function () {
            alert('Ojb.NameSpace.ClassName1');
            alert(this.base.getType());
        }
    };

})(jQuery, window.Ojb = window.Ojb || {});

;
(function ($, Ojb, undefined) {
    Ojb.NameSpace.ClassName1.Children = {
        base: new Ojb.NameSpace.ClassName1(),

        init: function () {
            alert(this.base.getType());
        }
    };

})(jQuery, window.Ojb = window.Ojb || {});