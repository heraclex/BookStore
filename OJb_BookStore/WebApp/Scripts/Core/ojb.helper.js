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
                setTimeout($.unblockUI, 2000);
                // $.unblockUI();
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
                    message: '<img width="54" height="55" src="' + this.getRootUrl() + 'Content/Images/loader.gif" />'
                };

                //this.mask = {
                //    css: {
                //        border: 'none',
                //        padding: '15px',
                //        backgroundColor: '#000',
                //        '-webkit-border-radius': '10px',
                //        '-moz-border-radius': '10px',
                //        opacity: .5,
                //        color: '#fff'
                //    },
                //    // message: 'Please wait ....'
                //    message: '<img width="54" height="55" src="' + this.getRootUrl() + 'Content/Images/loader.gif" />'
                //};
                
                $.blockUI(this.mask);
            }

            $.ajax({
                url: url,
                data: options.data,//JSON.stringify(options.data),
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
    
    Helpers.DataCore = Helpers.extend({
        serializeJson: function (data) {
            return JSON.stringify(data);
        },
    });
    Helpers.dataHelper = new Helpers.DataCore();

    $.fn.extend({
        placeholder: function () {
            var $input = $(this);
            if (typeof document.createElement("input").placeholder == 'undefined') {
                $input.val($input.attr('placeholder'));
                $input.focus(function () {
                    if ($input.val() == $input.attr('placeholder')) {
                        $input.val('');
                    }
                }).blur(function () {
                    if ($input.val() == '') {
                        $input.val($input.attr('placeholder'));
                    }
                });
            }
        },
        isExpandable: function () {
            var element = this[0];
            if (Helpers.isNull(element) === false && element.tagName.toLowerCase() == 'textarea' && $(element).attr('expandable') !== undefined) {
                return true;
            }
            return false;
        },
        collapse: function () {
            var textarea = this[0];
            var textbox = textarea.textbox;
            var value = $(textarea).val();
            textbox.val(value.replace("\r\n", "\n").split("\n")[0]).show();
            textbox.attr("title", value);
            $(textarea).hide();
        },
        expand: function () {
            var element = this[0];

            if ($(this).isExpandable()) {
                var value = $(element).val();
                var isRedacted = $(element).attr("redacted") !== undefined;
                var id = $(element).attr("id");
                var textbox = element.textbox;
                if (textbox) {
                    textbox.updatePosition();
                    textbox.show();
                    $(this).hide(); //incase text area disable focus not work
                    //textbox.focus();
                } else {
                    $(element).attr("id", id + "_textarea");
                    textbox = element.textbox = $('<input type="text" id="' + id + '"/>');
                    var zIndex = 10002;
                    textbox.css('text-overflow', 'ellipsis')
                        //.width($(element).width())
                        //.css('position', 'absolute')
                    .css('float', 'left') //make sure redacted icon on the right
                        .css('z-index', zIndex)
                        .val(value.replace("\r\n", "\n").split("\n")[0])
                        .attr("title", value)
                        .focus(function (e) {
                            e.preventDefault();
                            $(this).hide();
                            $(element).show();
                            $(element).focus();
                        });

                    if (!isRedacted) {
                        //    textbox.css('position', 'absolute');
                        textbox.css("width", "100%");
                    }
                    if ($(element).attr("disabled") !== undefined) textbox.attr("disabled", true);
                    textbox.updatePosition = function () {
                        //$(this).css('top', $(element).position().top)
                        //    .css('left', $(element).position().left);
                    };
                    textbox.updatePosition();
                    textbox.show();

                    $(element).removeAttr("disabled"); //make sure it'll be serialized

                    $(element).parent().prepend(textbox);
                    $(this).hide();

                }
            }
            return this;
        },
        textExpandable: function () {
            Helpers.textExpandable(this);
            return this;
        },

        textExpandableFocus: function () {
            Helpers.textExpandableFocus(this);
            return this;
        },

        // Serialize to Json for data Form
        serializeJson: function () {
            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name] !== undefined) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            return o;
        },

        //focus on the first text input element in the context element calling this function
        firstFocus: function () {
            var $input = $(this).find('input[type="text"]:first'),
                $button = $('button', this),
                $close = $(".close", $(this));

            if ($input.length > 0) {
                $input.focus();
                $input.select();
            } else {
                if ($button.length > 0) $button.focus().select();
                else $close.focus().select();
            }
            return this;
        },

        center: function () {
            this.css("position", "absolute")
                .css('margin-left', '0px')
                .css('margin-top', '0px')
                .css("top", Math.max(0, (($(window).height() - this.outerHeight()) / 2) + $(window).scrollTop()) + "px")
                .css("left", Math.max(0, (($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft()) + "px");
            return this;
        },
        horizontalCenter: function () {
            this.css("position", "fixed")
                .css('margin-left', '0px')
                .css("left", Math.max(0, (($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft()) + "px");
            return this;
        },
        isValidEndDate: function (startDatePickerAttr) {
            var input = $(this);
            if (!startDatePickerAttr) {
                startDatePickerAttr = 'startDatePicker';
            }
            var kendoDatePickerAttr = 'kendoDatePicker';
            if (typeof input.attr(startDatePickerAttr) !== 'undefined') {
                var startPicker = $('#' + input.attr(startDatePickerAttr)).data(kendoDatePickerAttr),
                    endPicker = input.data(kendoDatePickerAttr),
                    endDate = endPicker.value(),
                    startDate = startPicker.value(),
                    number = null,
                    isValidDate = kendo.parseDate(startDate) !== null && kendo.parseDate(endDate) !== null;
                if (!startDate) {
                    number = Date.parse($(startPicker.element).val());
                    if (!isNaN(number)) {
                        startDate = new Date(number);
                        startPicker._old = startPicker._value = startDate;
                    }
                }
                if (!endDate) {
                    number = Date.parse($(endPicker.element).val());
                    if (!isNaN(number)) {
                        endDate = new Date(number);
                        endPicker._old = endPicker._value = endDate;
                    }
                }
                if (isValidDate && startDate && endDate) {
                    return startDate <= endDate;
                }
                return true;
            }
            return true;
        },
        overlay: function (image, checked) {
            var element = this[0],
                top = $(this).position().top,
                left = $(this).position().left;
            element.overlays = element.overlays || [];
            image
                //.css('position', top == 0 && left == 0 ? 'static' : 'absolute')
                .css('z-index', $(this).css('z-index') + 1)
                //.css('top', top)
                //.css('left', left) 
                .css('display', 'none')
                .appendTo($(this).parent());
            element.overlays.push(image);
            if (checked) {
                image.checked = checked;
            } else {
                image.checked = null;
            }
            return this;
        },
        handleOverlayClick: function () {
            var element = this[0],
                $element = $(element);
            if (!$element.parent().hasClass("redacted") && typeof $element.attr('disabled') == 'undefined') {
                $element.unbind('keyup').bind('keyup', function (e) {
                    if (e.keyCode == 32) {//SPACE
                        $element.siblings('.img-checkbox:visible').click();
                        $(element).click();
                    }
                });
            }

            $.each(element.overlays, function (i, image) {
                if (typeof $element.attr('disabled') == 'undefined') {

                    if (!image.parent().hasClass("redacted")) { //if redacted not allow click

                        image.unbind('click').click(function (e) {
                            if (typeof $element.attr('disabled') !== 'undefined') {
                                return this;
                            }
                            var events = $._data(element, 'events'),
                                clickHandlers = events ? $._data(element, 'events').click : null;
                            if (clickHandlers && clickHandlers.length > 0) {
                                $element.attr('checked', image.checked);
                            }
                            $(element).click();
                            if ((image.checked && !$(element).attr('checked')) || (!image.checked && $element.attr('checked'))) {
                                $element.attr('checked', image.checked);
                            }
                            if (image.checked) {
                                var display = element.overlays[1].css('display');
                                element.overlays[0].css('display', display);
                                element.overlays[1].hide();
                            } else {
                                var display = element.overlays[0].css('display');
                                element.overlays[0].hide();
                                element.overlays[1].css('display', display);
                            }
                        });
                    } else { //process for Redacted check box
                        $element.bind("valueChanged", function (e) { //this event use only for Redacted Updatable checkbox
                            if ($element.attr("redacted") === undefined) return;
                            if ($element.is(":checked")) {
                                element.overlays[0].css('display', 'block');
                                element.overlays[1].hide();
                            } else {
                                element.overlays[0].hide();
                                element.overlays[1].css('display', 'block');
                            }
                            $element.change();
                        });
                    }
                } else {
                    element.overlays[0].unbind('click');
                    element.overlays[1].unbind('click');
                }
            });
            return this;
        },
        imageCheckBox: function () {
            var uncheckAll = function () {

            };
            this.each(function (index, element) {
                if ($(element).is(':checkbox')) {
                    if (!element.customized) {
                        var rootUrl = Helpers.ajaxHelper.getRootUrl(),
                            imagePath = rootUrl + 'Content/Images/',
                            checkedImage = $('<span id="tick_on">&nbsp;</span>').addClass('img-checkbox').addClass('tick_on'),
                            uncheckedImage = $('<span id="tick_off">&nbsp;</span>').addClass('img-checkbox').addClass('tick_off');
                        $(element).overlay(checkedImage).overlay(uncheckedImage, true).addClass('opacity0');
                        element.customized = true;
                    }
                    if ($(element).is(':checked')) {
                        element.overlays[0].show();
                        element.overlays[1].hide();
                    } else {
                        element.overlays[0].hide();
                        element.overlays[1].show();
                    }
                    $(element).handleOverlayClick();
                }
            });
            return this;
        },
        customizeCheckBoxes: function () {
            return Helpers.customizeCheckBoxes(this);
        },
        popupBoxExtension: function (opts) {
            var def = {
                baseUrl: '',
                overlay: 'overlay',
                close: '.close',
                help: '.helplink',
                cssClass: 'popup-box',
                loading: Helpers.resolveUrl('Content/images/loader.gif'),
                closeCallback: function () { },
                isAjax: true,
                isAnimated: true,
                isDeferred: false,
                data: null,
                isDisableCloseButton: false,
                isCheckDitry: false,
                workAround: true,
                top: '50%',
                left: '50%'
            },
                originalModel = {},
                confirmPopup = null,
                o = $.extend(def, opts),
                _this = this,
                overlay = $('<div id="' + o.overlay + '"></div>'),
                loading = $('<img src="' + o.loading + '" id="loader"></div>'),
                outterpo = o.cssClass,
                innerpo = 'popup-box-inner',
                outterWrap = this.outterWrap = this.outterWrap || $('<div class="' + outterpo + ' popup"></div>'),
                inner_wrap = this.inner_wrap = this.inner_wrap || $('<div class="' + innerpo + '"></div>'),
                url = o.baseUrl;

            this.init = function () {
                if (typeof Civica !== 'undefined' && typeof Civica.RegionManager !== 'undefined') {
                    Civica.RegionManager.unbindKeyUp();
                }
                originalModel = {};
                if (Helpers.isIphone()) {
                    o.left = '0';
                }
                if (o.isDeferred === false) {
                    _this.open(url);
                } else {
                    _this.deferredOpen(url);
                }
                if (typeof Civica !== 'undefined') {
                    Civica.currentPopup = _this;
                }
            };

            this.hasSaveButton = function () {
                return $('.button-funcs:visible:contains("Save")', inner_wrap).length > 0;
            },

            this.invokeSave = function () {
                var $buttonFunc = $('.button-funcs:visible', inner_wrap);
                var $saveBtn = $('a:contains("Save")', $buttonFunc);
                // For case pop up contain two button Save , Save and Add
                if ($saveBtn.length > 1) {
                    $saveBtn.each(function () {
                        var invokeSave = $(this).hasClass('saveandaddgroup');
                        if (!invokeSave) {
                            $(this).click();
                        }
                    });
                }
                    // For case normal
                else {
                    $('a:contains("Save")', $buttonFunc).click();
                }
                //$('.button-funcs:visible:contains("Save")', inner_wrap).click();
            },

            this.event = function () {

            };

            this.checkIsDirty = function () {
                var $form = $('form:first', inner_wrap),
                    dirtyModel = $.trim($form.serialize());
                //work around for kendoDropdownlist bug
                if (o.workAround === true) {
                    //                    return !(originalModel.replaceAll("=0&", "=&") === dirtyModel.replaceAll("=0&", "=&"));
                    return !(Helpers.replaceAll(originalModel, "=0&", "=&") === Helpers.replaceAll(dirtyModel, "=0&", "=&"));
                }
                return !(originalModel === dirtyModel);
            },

            this.updateOriginalModel = function () {
                var $form = $('form:first', inner_wrap);
                originalModel = $.trim($form.serialize());

            },

            this.open = function (url) {
                var _heightpo, _widthpo, mrt, mrl,
                    attrs = this.getAttributes();

                $.each(attrs, function (i, data) {
                    if (i == 'href' || i == 'data-rel') {
                        if (data != '') {
                            o.baseUrl = data;
                        }
                    }
                });

                loading.appendTo('body');
                if ($('#overlay:visible').length === 0) {
                    overlay.appendTo('body');
                } else {
                    overlay = $('#overlay:visible');
                }
                outterWrap.append(inner_wrap).appendTo('body');
                var pobox = this.pobox = outterWrap,
                    poinbox = this.poinbox = inner_wrap;
                this.overlay = overlay;

                if (o.isAjax === true) {
                    Helpers.ajaxHelper.ajax({
                        type: "GET",
                        url: url,
                        cache: false,
                        success: function (result) {
                            poinbox.empty().append(result);
                            loading.detach();
                            _heightpo = pobox.height(), _widthpo = pobox.width(), mrt = parseInt(_heightpo / 2), mrl = parseInt(_widthpo / 2);
                            if (Helpers.isIphone()) {
                                mrl = 0;
                                mrt = 0;
                            }
                            pobox.css({
                                top: o.top,
                                left: o.left,
                                'margin-left': -mrl + 'px',
                                'margin-top': -mrt + 'px'
                            });

                            var scanDataGrid = setInterval(function () {
                                if (pobox.find('table').length > 0) {
                                    var widthReal = pobox.width();
                                    if (widthReal > 0) {
                                        if (widthReal > 1000) {
                                            pobox.width(1000);
                                            pobox.css({
                                                'margin-left': '-500px'
                                            }).show();
                                        } else {
                                            pobox.width(widthReal);
                                            mrl = parseInt(widthReal / 2);
                                            if (Helpers.isIphone()) {
                                                mrl = 0;
                                                mrt = 0;
                                            }
                                            pobox.css({
                                                'margin-left': -mrl + 'px'
                                            }).show();
                                        }
                                        clearInterval(scanDataGrid);
                                        Helpers.firstFocus(poinbox, true);
                                    }
                                } else {
                                    mrl = parseInt(_widthpo / 2);
                                    if (Helpers.isIphone()) {
                                        mrl = 0;
                                    }
                                    pobox.css({
                                        'margin-left': -mrl + 'px'
                                    }).show();
                                    clearInterval(scanDataGrid);
                                    Helpers.firstFocus(poinbox, true);
                                }
                            }, 200);


                            if (typeof o.callback === 'function') {
                                if (o.callbackOptions) {
                                    o.callback.apply({
                                        pobox: pobox,
                                        overlay: overlay
                                    }, [o.callbackOptions]);
                                } else {
                                    o.callback();
                                }
                            }
                            _this.updateOriginalModel();
                            _this.close();
                        }
                    });
                } else {
                    setTimeout(function () {
                        loading.detach();
                    }, 1000);
                    poinbox.empty().append(o.data);
                    _heightpo = pobox.height(), _widthpo = pobox.width(), mrt = parseInt(_heightpo / 2), mrl = parseInt(_widthpo / 2);
                    if (Helpers.isIphone()) {
                        mrl = 0;
                    }
                    pobox.css({
                        top: o.top,
                        left: o.left,
                        'margin-left': -mrl + 'px',
                        'margin-top': -mrt + 'px'
                    }).show();
                    if (typeof o.callback === 'function') {
                        if (o.callbackOptions) {
                            o.callback.apply({
                                pobox: pobox,
                                overlay: overlay
                            }, [o.callbackOptions]);
                        } else {
                            o.callback();
                        }
                    }
                    _this.close();
                    _this.updateOriginalModel();
                    Helpers.firstFocus(poinbox);
                }
                overlay.show();
            };

            this.deferredOpen = function (url) {
                var _heightpo, _widthpo, mrt, mrl,
                    attrs = this.getAttributes();

                $.each(attrs, function (i, data) {
                    if (i == 'href' || i == 'data-rel') {
                        if (data != '') {
                            o.baseUrl = data;
                        }
                    }
                });
                if ($('#overlay:visible').length === 0) {
                    overlay.appendTo('body');
                } else {
                    overlay = $('#overlay:visible');
                }
                outterWrap.append(inner_wrap).appendTo('body');
                var pobox = this.pobox = outterWrap,
                    poinbox = this.poinbox = inner_wrap;
                this.overlay = overlay;

                if (o.isAjax === true) {
                    Helpers.ajaxHelper.ajax({
                        type: "GET",
                        url: url,
                        cache: false,
                        success: function (result) {
                            if (typeof result === 'undefined' || result === null || result === '' || result.nodeName === '#document') {
                                //Do nothing
                                loading.detach();
                                return;
                            } else {
                                overlay.appendTo('body').show();
                                $(outterWrap).html(inner_wrap).appendTo('body');
                                pobox = $('.' + outterpo), poinbox = $('.' + innerpo);
                                setTimeout(function () {
                                    loading.detach();
                                }, 1000);
                                poinbox.empty().append(result);
                                _heightpo = pobox.height(), _widthpo = pobox.width(), mrt = parseInt(_heightpo / 2), mrl = parseInt(_widthpo / 2);
                                if (Helpers.isIphone()) {
                                    mrl = 0;
                                    mrt = 0;
                                }
                                pobox.css({
                                    top: o.top, left: o.left,
                                    'margin-left': -mrl + 'px',
                                    'margin-top': -mrt + 'px'
                                }).show();
                                if (typeof o.callback === 'function') {
                                    if (o.callbackOptions) {
                                        o.callback.apply({
                                            pobox: pobox,
                                            overlay: overlay
                                        }, [o.callbackOptions]);
                                    } else {
                                        o.callback();
                                    }
                                }
                                Helpers.firstFocus(poinbox, true);
                                _this.updateOriginalModel();
                                _this.close();
                            }
                        }
                    });
                } else {
                    $(outterWrap).html(inner_wrap).appendTo('body');
                    pobox = $('.' + outterpo), poinbox = $('.' + innerpo);
                    setTimeout(function () {
                        loading.detach();
                    }, 1000);
                    poinbox.empty().append(o.data);
                    _heightpo = pobox.height(), _widthpo = pobox.width(), mrt = parseInt(_heightpo / 2), mrl = parseInt(_widthpo / 2);
                    if (Helpers.isIphone()) {
                        mrl = 0;
                        mrt = 0;
                    }
                    pobox.css({
                        top: o.top,
                        left: o.left,
                        'margin-left': -mrl + 'px',
                        'margin-top': -mrt + 'px'
                    }).show();
                    if (typeof o.callback === 'function') {
                        if (o.callbackOptions) {
                            o.callback.apply({
                                pobox: pobox,
                                overlay: overlay
                            }, [o.callbackOptions]);
                        } else {
                            o.callback();
                        }
                    }
                    Helpers.firstFocus(poinbox, true);
                    _this.updateOriginalModel();
                    _this.close();
                }
            };

            this.hide = function () {
                outterWrap.hide();
            };
            this.show = function () {
                outterWrap.show();
            };
            this.close = function () {
                var close = this.pobox.find(o.close),
                    that = this,
                    confirmTemplate = '<div id="" class="popup-box-head accent-colour-background clearfix">' + '<div id="dirtyPopupContent" class="box-title normal-text left"> Confirm</div>' + '<div class="button-funcs right">' + '<a id="pop-close" class="close" title="Close" href="#">Close</a>' + '</div>' + '</div>' + '<div class="popup-box-content">Do you wish to save the changes you have made before leaving this screen?</div>' + '<div class="YNButton clearfix" id="dirtyPopupButton">' + '<button id="btnYes" class="active-background active-text btn" title="Yes" type="button">Yes</button>' + '<button id="btnNo" class="active-background active-text btn" title="NO" type="button">No</button>' + '</div>';
                if (o.isDisableCloseButton === false) {
                    close.on('click', function (e) {
                        var $this = $(this);
                        e.preventDefault();
                        o.closeCallback();
                        if (_this.hasSaveButton() === false || _this.checkIsDirty() === false) {
                            if (typeof Civica !== 'undefined' && typeof Civica.RegionManager !== 'undefined') {
                                Civica.RegionManager.bindKeyUp();
                            }
                            that.pobox.remove();
                            that.overlay.detach();
                            while ($('#overlay').length > 0) {
                                $('#overlay').remove();
                            }
                        } else {
                            that.hide();
                            var confirmPopup = $('</a>').popupBoxExtension({
                                isAjax: false,
                                data: confirmTemplate,
                                cssClass: 'dirty-popup-box',
                                isDisableCloseButton: true,

                                callback: function () {
                                    var popup = this;

                                    $('#dirtyPopupButton #btnYes').focus().unbind('click').click(function () {
                                        confirmPopup.pobox.remove();
                                        that.show();
                                        that.invokeSave();
                                    }).focus();

                                    $('.dirty-popup-box .close:visible').off('click').on('click', function () {
                                        confirmPopup.pobox.remove();
                                        that.show();
                                    });

                                    $('#dirtyPopupButton #btnNo').off('click').on('click', function () {
                                        confirmPopup.pobox.remove();
                                        that.pobox.remove();
                                        that.overlay.detach();
                                    });
                                    $('#dirtyPopupButton #btnYes').focus();
                                },
                                callbackOptions: {}
                            });
                        }
                    });
                }
                this.pobox.keyup(function (e) {

                    if (e.keyCode == 27) {

                        if (o.escapeKeyDown && typeof (o.escapeKeyDown) == "function") {
                            o.escapeKeyDown.apply(that, [e]);
                        }
                        if (close.length) {
                            close.click();
                        } else {
                            that.pobox.remove();
                            that.overlay.detach();
                        }
                        e.stopPropagation(); //stop bubling event, missing this dirty popup will keep showing.
                        if (typeof Civica !== 'undefined' && typeof Civica.RegionManager !== 'undefined') {
                            Civica.RegionManager.bindKeyUp();
                        }
                        e.preventDefault();
                    } else if (e.keyCode == 13) {
                        if (o.enterKeyDown && typeof (o.enterKeyDown) == "function") {
                            o.enterKeyDown.apply(that, [e]);
                        }

                        e.preventDefault();
                    }
                    else if (e.keyCode == 112) {
                        e.preventDefault();
                        var help = $(this).find(o.help);
                        if (typeof help !== 'undefined') help[0].click();
                    }
                });
            };
            if (this.init) {
                this.init();
            }

            return this;
        }
    });

})(jQuery);