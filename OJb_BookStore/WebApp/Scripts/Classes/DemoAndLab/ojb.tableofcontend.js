;
(function ($, Ojb, undefined) {
    Ojb.DemoAndLab_Table = {
        personList: new Array(),

        init: function (data) {
            Ojb.DemoAndLab_Table.personList = data;
            Ojb.DemoAndLab_Table.renderPersonTable();
            $('#btnSunmit').click(Ojb.DemoAndLab_Table.submit);
        },

        renderPersonTable: function() {
            // Select body table
            var items = Ojb.DemoAndLab_Table.personList;
            var tableBody = $('#data-table-a > tbody');
            if (tableBody.children().length > 0) {
                tableBody.empty();
            }
            var dataRowsHtml = '';
            for (var i = 0; i < items.length; i++) {
                dataRowsHtml += '<tr>';
                dataRowsHtml += '<td>' + items[i].Id + '</td>';
                dataRowsHtml += '<td>' + items[i].Name + '</td>';
                //dataRowsHtml += '<td><input ' +
                //    'type="checkbox" name="personSelect" id="checkbox_' + items[i].Id + '" value="' + items[i].Id + '"' +
                //    'onchange="'+ Ojb.DemoAndLab_Table.onCheck +'"/></td>';
                dataRowsHtml += '<td><input ' +
                    'type="checkbox" name="personSelect" id="checkbox_' + items[i].Id + '" value="' + items[i].Id + '"/></td>';
                dataRowsHtml += '</tr>';
            }
            tableBody.append(dataRowsHtml);
            
            $("[name='personSelect']").change(Ojb.DemoAndLab_Table.onChange);
        },
        
        onChange: function () {
            var value = this.value;
            var items = Ojb.DemoAndLab_Table.personList;
            for (var i = 0; i < items.length; i++) {
                if (items[i].Id == value) {
                    items[i].IsSelected = this.checked;
                    break;
                }
            }
        },
        
        submit: function () {
            var dataSubmit = Helpers.dataHelper.serializeJson(Ojb.DemoAndLab_Table.personList);
            Helpers.ajaxHelper.postJson({
                url: Helpers.resolveUrl("DemoAndLab/SubmitList"),
                async: false,
                cache: false,
                data: dataSubmit,
                success: function () {
                    alert('sucess');
                },
                error: function () {
                    alert('fail');
                }
            });
        }
    };
})(jQuery, window.Ojb = window.Ojb || {});

