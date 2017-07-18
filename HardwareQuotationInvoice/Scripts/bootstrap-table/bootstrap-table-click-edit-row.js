/**
 * @author horken wong <horken.wong@gmail.com>
 * @version: v1.0.0
 * https://github.com/horkenw/bootstrap-table
 * Click to edit row for bootstrap-table
 */

(function ($) {
    'use strict';
    var updateUrl;
    var loadName;
    $.extend($.fn.bootstrapTable.defaults, {
        clickEdit: false,
        updateUrl: "",
        loadName:""
    });


    function updateToServerSide(itemId, data) {
        //alert(trNode[0].length);
        //trNode.addClass('success');
        
        //if (loadName) {
        //    $('#' + loadName).modal('show');
        //}
        //$.ajax({
        //    url: updateUrl,
        //    dataType: "json",
        //    type: 'post',
        //    data: data,
        //    success: function (data) {
        //        $table.bootstrapTable('load', data.Data);
        //        if (loadName) {
        //            $('#' + loadName).modal('hide');
        //        }
        //    },
        //    error: function () {
        //        alert("失败");
        //    }

        //});
    }

    function rowStyle(row, index) {
        var classes = ['active', 'success', 'info', 'warning', 'danger'];

        if (index % 2 === 0 && index / 2 < classes.length) {
            return {
                classes: classes[index / 2]
            };
        }
        return {};
    }

    function setDivision(node, options){
        var $option = $('<option />');
        if(options){
            $(options).each(function(i, v){
                $option.clone().text(v.idxNum + ' ' +v.name).val(v.idxNum).appendTo(node);
            })
        }
        else{
            console.log('Please setup options first!!')
        }
    }

    function clikcToEdit(evt, tarNode){
        var txt = [],inputIndexes = [], table = evt,
            submit = '<button type="button" class="btn btn-primary btn-sm editable-submit"><i class="glyphicon glyphicon-ok"></i></button>',
            cancel = '<button type="button" class="btn btn-default btn-sm editable-cancel"><i class="glyphicon glyphicon-remove"></i></button>';
        tarNode.addClass('warning');
        var replaceData = function () {
            //alert(updateUrl);
           
            var tableTarget = table.$tableBody.find('table');
  
            txt = [];
            inputIndexes = [];
            tarNode.find('td').find('input[type="text"]').each(function(i, td){
                txt.push($(td).eq(0).val());
            });
            tarNode.find('select').each(function(i, td){
                txt.push($('#'+td.id+' option:selected').val());
            });

            tarNode.find('td').each(function (i, td) {
                var inputValueObj = $(td).find('input[type="text"]');
                if (inputValueObj.length > 0) {
                    txt.push(inputValueObj.val());
                    inputIndexes.push(i);
                }
                else {
                    inputValueObj = $(td).find('select')
                    if (inputValueObj.length > 0) {
                        txt.push(inputValueObj.val());
                        inputIndexes.push(i);
                    }

                }

                
            });

            var updateRow = {};
            for (var i = 0; i < inputIndexes.length; i++) {
                updateRow[table.columns[inputIndexes[i]].field] = txt[i];
            }

          
            tableTarget.bootstrapTable('updateRow', {
                index: table.$data.thId,
                row: updateRow
            });
            $('#tooling').remove();
            table.editing = true;
 

            tableTarget.find('tr[data-uniqueid="' + table.$data.itemid + '"]').each(function () {
             
                 $(this).addClass('success');

            });

            //updateToServerSide(table.$data.itemid, updateRow);
              
  
            return false;
        };

        var recoveryData = function () {
            var tableTarget = table.$tableBody.find('table');
            tableTarget.bootstrapTable('updateRow', {
                index: table.$data.thId,
                row: {},
            });
          $('#tooling').remove();
          table.editing = true;
          return false;
        };

        if(table.editing){
            var  rootid = 0;
            table.editing = false;
            table.columns.forEach(function(column, i){
                if (!column.editable) return;

                switch(column.editable){
                    case 'input':
                        var div=$('<div class="editable-input col-md-12 col-sm-12 col-xs-12" style="position: relative;"/>');
                        txt.push(tarNode.find('td').eq(column.fieldIndex).text());
                        div.append($('<input type="text" class="form-control input-sm"/>'));
                        div.append($('<span class="clear"><i class="fa fa-times-circle-o" aria-hidden="true"></i></span>'));
                        tarNode.find('td').eq(column.fieldIndex).text('').append(div);
                        break;
                    case 'select':
                        var select=$('<select id="'+column.field+'">'), options = $.selectArray[column.field];
                        tarNode.find('td').eq(column.fieldIndex).text('').append(select);
                        setDivision($('#'+column.field), options);
                        break;
                    case 'textarea':
                        break;
                    default:
                        console.log(column.fieldIndex+' '+column.editable);
                }

            }, evt);
            for(var i=0, l=txt.length; i<l; i++){
                tarNode.find('input[type="text"]').eq(i).val(txt[i]);
            }
            tarNode.find('td').last().append('<div id="tooling" class="editable-buttons"/>');
            $('.clear').on('click', function(){ $(this).parent().find('input').val('');});
            $(submit).on('click', replaceData).appendTo('#tooling');
            $(cancel).on('click', recoveryData).appendTo('#tooling');
        }
    }

    


    var BootstrapTable = $.fn.bootstrapTable.Constructor,
        _initTable = BootstrapTable.prototype.initTable,
        _initBody = BootstrapTable.prototype.initBody;

    BootstrapTable.prototype.initTable = function(){
        var that = this;
        this.$data = {};
        _initTable.apply(this, Array.prototype.slice.apply(arguments));

        if (!this.options.clickEdit) {
            return;
        }

    };

    BootstrapTable.prototype.initBody = function () {
        var that = this;
        _initBody.apply(this, Array.prototype.slice.apply(arguments));
        
        if (!this.options.clickEdit) {
            return;
        }
        if (this.options.updateUrl)
        {
            updateUrl = this.options.updateUrl;
        }

        if (this.options.loadName)
        {
            loadName = this.options.loadName;
        }
        var table = this.$tableBody.find('table');
        that.editing=true;

        table.on('dbl-click-row.bs.table', function (e, row, $element, field) {
            if(field ==='no') return; //|| field ==='noOld'
            this.$data.thId = $element.data().index;
            this.$data.itemid = $element.data().uniqueid;
            this.$data.divi = parseInt(row.area);
            this.$data.town = parseInt(row.town);           
            clikcToEdit(this, $element);
        }.bind(this));
    };
})(jQuery);
