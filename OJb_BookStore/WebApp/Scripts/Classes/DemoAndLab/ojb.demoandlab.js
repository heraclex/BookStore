;
(function ($, Ojb, undefined) {
    Ojb.DemoAndLab = {
        list1Subscribed: false,
        list2Subscribed: false,

        init: function () {
            Ojb.DemoAndLab.registerEvent();
        },

        registerEvent: function () {
            $('#btnShowPopup').click(Ojb.DemoAndLab.showPopup);
            $('#btnHidePopup').click(Ojb.DemoAndLab.hidePopup);
            $('#btnSunmit').click(Ojb.DemoAndLab.submit);
        },
        
        showPopup: function () {
            // incase has children
            if ($('#container').children().length > 0) {
                $("#container").children().show();
            } else {
                Helpers.ajaxHelper.getHtml({
                    url: Helpers.resolveUrl("/DemoAndLab/Popup"),
                    async: false,
                    cache: false,
                    success: function (data) {
                        Ojb.DemoAndLab.renderPopup(data);
                    },
                    error: function () {
                        alert('fail');
                    },
                    callback: function () {
                        alert('do something');
                    }
                });
            }
            //    Helpers.ajaxHelper.getJson({
            //    url: Helpers.resolveUrl("Controller/Action"),
            //    async: false,
            //    cache: false,
            //    success: function() {
            //        window.close();
            //    },
            //    error: function() {
            //        alert('fail');
            //    },
            //    callback: function() {
            //        alert('do something');
            //    }
            //});
        },

        hidePopup: function () {
            // $('#container').empty();
            $("#container").children().hide();
        },
        
        renderPopup: function (htmlData) {
            $('#container').append(htmlData);
            $('#List1').change(Ojb.DemoAndLab.list1Change);
            $('#List2').change(Ojb.DemoAndLab.list2Change);
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
            var value2 = $('#List2').val();

            // triger to List 1 if List 2 change
            $('#List1').val(value2).trigger('change');
        },
        
        submit: function () {
            var persons = new Array();
            var ids = new Array();
            var names = new Array();
            for (var i = 0; i < 2; i++) {
                ids.push(i);
                names.push("person: " + i);
                persons.push({ ids: i, name: "person: " + i });
            }

            var demo = {
                Persons: persons,
                Ids: ids,
                //Names: names,
                Description: "demo",
                aaa: "sdasdadasds"
            };
            Helpers.ajaxHelper.postJson({
                    url: Helpers.resolveUrl("DemoAndLab/Submit"),
                async: false,
                cache: false,
                // contentType: 'application/json',
                data: demo,
                success: function() {
                    alert('sucess');
                },
                error: function() {
                    alert('fail');
                }
            });
        }
    };
})(jQuery, window.Ojb = window.Ojb || {});

