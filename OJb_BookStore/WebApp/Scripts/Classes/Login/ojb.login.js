;
(function ($, Ojb, undefined) {
    Ojb.Login = {
        list1Subscribed: false,
        list2Subscribed: false,

        init: function () {
            Ojb.Login.registerEvent();
        },

        registerEvent: function () {
            $('#List1').change(Ojb.Login.list1Change);
            $('#List2').change(Ojb.Login.list2Change);
        },

        list1Change: function () {
            if (Ojb.Login.list2Subscribed) {
                var value2 = $('#List2').val();
                $('#List1').val(value2);
                Ojb.Login.list2Subscribed = false;
                return;
            }
            
            Ojb.Login.list1Subscribed = true;
            var value = $('#List1').val();
            
            // triger to List 2 if List 1 change
            $('#List2').val(value).trigger('change');
        },
        
        list2Change: function () {
            if (Ojb.Login.list1Subscribed) {
                var value1 = $('#List1').val();
                $('#List2').val(value1);
                Ojb.Login.list1Subscribed = false;
                return;
            }
            
            Ojb.Login.list2Subscribed = true;
            var value2= $('#List2').val();

            // triger to List 1 if List 2 change
            $('#List1').val(value2).trigger('change');
        },

    };
})(jQuery, window.Ojb = window.Ojb || {});
