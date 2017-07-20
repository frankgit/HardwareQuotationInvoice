/**
 * @author zhixin wen <wenzhixin2010@gmail.com>
 * extensions: https://github.com/vitalets/x-editable
 */

(function($) {

    'use strict';

    $.extend($.fn.bootstrapTable.defaults, {
        editable: true,
        onEditableInit: function() {
            return false;
        },
        onEditableSave: function (field, row, oldValue, $el) {
            return false;
        },
        onEditableShown: function (field, row, $el, editable) {
          
            return false;
        },
        onEditableHidden: function (field, row, $el, reason) {
          
            return false;
        }
    });

    $.extend($.fn.bootstrapTable.Constructor.EVENTS, {
        'editable-init.bs.table': 'onEditableInit',
        'editable-save.bs.table': 'onEditableSave',
        'editable-shown.bs.table': 'onEditableShown',
        'editable-hidden.bs.table': 'onEditableHidden'
    });

    var getFieldIndex = function (columns, field) {
        var index = -1;

        $.each(columns, function (i, column) {
            if (column.field === field) {
                index = i;
                return false;
            }
            return true;
        });
        return index;
    };

    var BootstrapTable = $.fn.bootstrapTable.Constructor,
        _initTable = BootstrapTable.prototype.initTable,
        _initBody = BootstrapTable.prototype.initBody;

    BootstrapTable.prototype.initTable = function() {
        var that = this;
        _initTable.apply(this, Array.prototype.slice.apply(arguments));

        if (!this.options.editable) {
            return;
        }

        $.each(this.columns, function(i, column) {
            if (!column.editable) {
                return;
            }

            var editableOptions = {},
                editableDataMarkup = [],
                editableDataPrefix = 'editable-';

            var processDataOptions = function(key, value) {
                // Replace camel case with dashes.
                var dashKey = key.replace(/([A-Z])/g, function($1) {
                    return "-" + $1.toLowerCase();
                });
                if (dashKey.slice(0, editableDataPrefix.length) == editableDataPrefix) {
                    var dataKey = dashKey.replace(editableDataPrefix, 'data-');
                    editableOptions[dataKey] = value;
                }
            };

            $.each(that.options, processDataOptions);

            column.formatter = column.formatter || function(value, row, index) {
                return value;
            };
            column._formatter = column._formatter ? column._formatter : column.formatter;
            column.formatter = function(value, row, index) {
                var result = column._formatter ? column._formatter(value, row, index) : value;

                $.each(column, processDataOptions);

                $.each(editableOptions, function(key, value) {
                    editableDataMarkup.push(' ' + key + '="' + value + '"');
                });

                var _dont_edit_formatter = false;
                if (column.editable.hasOwnProperty('noeditFormatter')) {
                    _dont_edit_formatter = column.editable.noeditFormatter(value, row, index);
                }

                if (_dont_edit_formatter === false) {
                    return ['<a href="javascript:void(0)"',
                        ' data-name="' + column.field + '"',
                        ' data-pk="' + row[that.options.idField] + '"',
                        ' data-value="' + result + '"',
                        editableDataMarkup.join(''),
                        '>' + '</a>'
                    ].join('');
                } else {
                    return _dont_edit_formatter;
                }

            };
        });
    };



   

    BootstrapTable.prototype.initBody = function() {
        var that = this;
        _initBody.apply(this, Array.prototype.slice.apply(arguments));

        if (!this.options.editable) {
            return;
        }

        that.$body.find('a').each(function (index, item) {
            var newEditable = that.columns[getFieldIndex(that.columns, $(item).attr("data-name"))].editable;
            if (newEditable.type != 'select') return;
            var fieldName = $(item).attr("data-name");
            var textAttr = fieldName + $(item).attr("data-pk");

            if ($.selectArray[textAttr] != undefined) {

                newEditable.source = $.selectArray[textAttr];


                $(item).editable(newEditable)
                   .off('save').on('save', function (e, params) {
                       var data = that.getData(),
                           index = $(this).parents('tr[data-index]').data('index'),
                           row = data[index],
                           oldValue = row[fieldName];

                       $(this).data('value', params.submitValue);
                       row[fieldName] = params.submitValue;
                       that.trigger('editable-save', fieldName, row, oldValue, $(this));
                       that.resetFooter();

                   });

                $(item).editable(newEditable)
                    .off('shown').on('shown', function (e, editable) {

                        var data = that.getData();
                        var index = $(this).parents('tr[data-index]').data('index');
                         var row = data[index];
                         that.trigger('editable-shown', fieldName, row, $(this), editable);
                    })


                $(item).editable(newEditable)
                .off('hidden').on('hidden', function(e, reason) {
                            var data = that.getData(),
                                index = $(this).parents('tr[data-index]').data('index'),
                                row = data[index];

                            that.trigger('editable-hidden', fieldName, row, $(this), reason);
                        });
                }
            else {
                if (fieldName == "quatity") {
                    newEditable.source = $.selectArray[fieldName];
                    $(item).editable(newEditable);
                }

            }
        });

        $.each(this.columns, function(i, column) {
            if (!column.editable) {
                return;
            }
            if (column.editable.type == 'select') return;

            that.$body.find('a[data-name="' + column.field + '"]').editable(column.editable)
                .off('save').on('save', function(e, params) {
                    var data = that.getData(),
                        index = $(this).parents('tr[data-index]').data('index'),
                        row = data[index],
                        oldValue = row[column.field];

                    $(this).data('value', params.submitValue);
                    row[column.field] = params.submitValue;
                    that.trigger('editable-save', column.field, row, oldValue, $(this));
                    that.resetFooter();
                });

            that.$body.find('a[data-name="' + +column.field + '"]').editable(column.editable)
                .off('shown').on('shown', function (e, editable) {            
                    var data = that.getData(),
                        index = $(this).parents('tr[data-index]').data('index'),
                        row = data[index];

                    that.trigger('editable-shown', column.field, row, $(this), editable);
                });
            that.$body.find('a[data-name="' + column.field + '"]').editable(column.editable)
                .off('hidden').on('hidden', function(e, reason) {
                    var data = that.getData(),
                        index = $(this).parents('tr[data-index]').data('index'),
                        row = data[index];

                    that.trigger('editable-hidden', column.field, row, $(this), reason);
                });
        });




        this.trigger('editable-init');
    };

})(jQuery);
