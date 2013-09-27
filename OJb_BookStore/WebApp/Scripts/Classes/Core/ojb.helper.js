(function ($) {
    UtilityClass = function () { };

    UtilityClass.prototype = {
        init: UtilityClass,

        isNull: function (element) {
            return (typeof element === "undefined" || element === null);
        },

        isNullOrEmpty: function (element) {
            return (Helpers.isNull(element) || element === '');
        },

        rootUrl: function () {
            return $('#rootUrl').val();
        },

        resolveUrl: function (url) {
            return Helpers.rootUrl() + url;
        },

        //get url from controller, action
        urlBuilder: function (controller, action, params) {
            var SLASH = '/';
            var QUESTION_MASK = '?';
            var rootUrl = Helpers.rootUrl;
            var url;
            if (rootUrl === '/') {
                url = SLASH + controller + SLASH + action + QUESTION_MASK + params;
            } else {
                url = rootUrl + SLASH + controller + SLASH + action + QUESTION_MASK + params;
            }

            return url;
        },

        //extend from an object
        extend: function (protobj, skipBaseConstructor) {
            protobj = protobj || {};
            var subClass = null;
            var baseConstructor = this;
            if (typeof (baseConstructor) != "function") {
                baseConstructor = this.init;
            }

            if (protobj.init) {
                subClass = function () {
                    if (!skipBaseConstructor) {
                        baseConstructor.apply(this, arguments);
                    }
                    protobj.init.apply(this, arguments);
                };
            } else {
                subClass = function () {
                    if (!skipBaseConstructor) {
                        baseConstructor.apply(this, arguments);
                    }
                };
                protobj.init = baseConstructor;
            }
            subClass.prototype = subClass.prototype || {};
            $.extend(true, subClass.prototype, this.prototype, protobj);
            subClass.extend = this.extend;
            return subClass;
        },
    };

    Helpers = new UtilityClass();

    //Core functions
    Helpers.AjaxCore = Helpers.extend({
        JSONCONTENTTYPE: 'application/json',
        JSON: 'json',
        HTML: 'html',
        POST: 'POST',
        GET: 'GET',
        SLASH: '/',
        AND: '&',
        QUESTION_MARK: '?',

        //called when an ajax request is completed
        ajaxComplete: function () {
            if (this.mask) {
                $.unblockUI();
                this.mask = null;
            }
        },

        getRootUrl: function () {
            var rootUrl = Helpers.rootUrl();
            if (/\/.+/.test(rootUrl)) {
                rootUrl = rootUrl + this.SLASH;
            }
            return rootUrl;
        },

        //get url from controller, action
        buildUrl: function (controller, action) {
            var rootUrl = this.getRootUrl();
            var url = rootUrl + controller + this.SLASH + action;
            return url;
        },

        //send ajax request
        ajax: function (options) {
            var url = options.url,
                async = (typeof options.async === 'undefined') ? true : options.async,
                traditional = options.traditional == undefined ? false : options.traditional;
            if (!url) {
                url = this.buildUrl(options.controller, options.action);
            }
            if (options.showMask) {
                this.mask = {
                    css: {
                        backgroundColor: 'transparent',
                        border: 'none',
                        zIndex: 10002
                    },
                    // message: '<img width="54" height="55" src="' + rootUrl + 'Content/Images/loader.gif" />'
                };
                $.blockUI(this.mask);
            }

            $.ajax({
                url: url,
                data: JSON.stringify(options.data),
                dataType: options.dataType,
                type: options.type,
                cache: options.cache,
                contentType: options.contentType,
                async: async,
                traditional: traditional,
                context: this,
                success: function (result, textStatus, jqXHR) {
                    var isSuccessful = true;
                    if (result) {
                        if (result.redirect) {
                            window.location = result.redirect;
                            isSuccessful = false;
                        }
                    }
                    if (isSuccessful) {
                        try {
                            options.success.call(this, result);
                        } catch (error) {
                            this.showErrorMessage(error, error);
                        }
                    }
                    this.ajaxComplete();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    if (options != undefined && options.type == "POST") {
                        // // will be implemented later
                    }
                    // this.checkError(jqXHR.responseText, jqXHR, options);
                    this.ajaxComplete();
                }
            });

            return false;
        },

        //send ajax request with data in JSON format and GET verb
        getJson: function (options) {
            var defaultOptions = {
                contentType: this.JSONCONTENTTYPE,
                dataType: this.JSON,
                type: this.GET
            };
            var ajaxOptions = $.extend({}, defaultOptions, options);
            this.ajax(ajaxOptions);
        },

        //send ajax request with data in JSON format and POST verb
        postJson: function (options) {
            var defaultOptions = {
                contentType: this.JSONCONTENTTYPE,
                dataType: this.JSON,
                type: this.POST
            };
            var ajaxOptions = $.extend({}, defaultOptions, options);
            this.ajax(ajaxOptions);
        },

        //send ajax request with data in HTML format and GET verb
        getHtml: function (options) {
            var defaultOptions = {
                dataType: this.HTML,
                type: this.GET
            };
            var ajaxOptions = $.extend({}, defaultOptions, options);
            this.ajax(ajaxOptions);
        },

        //send ajax request with data in HTML format and POST verb
        postHtml: function (options) {
            var defaultOptions = {
                dataType: this.HTML,
                type: this.POST
            };
            var ajaxOptions = $.extend({}, defaultOptions, options);
            this.ajax(ajaxOptions);
        },

        //navigate to a url built from controller, action
        redirectToAction: function (options) {
            var url = this.buildUrl(options.controller, options.action);
            if (options.params) {
                if (options.params.length > 1) options.params.unshift(this.QUESTION_MARK);
                url = url + this.SLASH + options.params.join(this.AND);
            }
            window.location = url;
        }
    });
    Helpers.ajaxHelper = new Helpers.AjaxCore();

})(jQuery);