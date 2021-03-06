﻿$(function () {

    LoadQuotationGrid();
    $("#divQuotationGrid").bootstrapTable('hideColumn', 'configtype');
    $("#divQuotationGrid").bootstrapTable('hideColumn', 'id');
    $('#table').bootstrapTable('resetWidth');

})

function LoadQuotationGrid()
{
    var curRow = {};
    var price = new Array(15, 23, 35, 89, 191)
    $.selectArray =
    {
        "hardware1": [{ value: "1", text: "ADM A10-5800K(盒)" }, { value: "2", text: "ADM A11-5800K(盒)" }, { value: "3", text: "ADM A12-5800K(盒)" }],
        "hardware2": [{ value: "1", text: "内存1" }, { value: "2", text: "内存2" }, { value: "3", text: "内存3" }],
        "hardware3": [{ value: "1", text: "显卡1" }, { value: "2", text: "显卡2" }, { value: "3", text: "显卡3" }],
        "quatity": [{ value: "1", text: "1" }, { value: "2", text: "2" }, { value: "3", text: "3" }, { value: "4", text: "4" }, { value: "5", text: "5" }]
    }
    $('#divQuotationGrid').bootstrapTable({
        idField:"id",
        url: '/HardWareQuotation/GetJsonData',
        groupBy: true,
        clickToSelect: true,
        groupByField: "configtype",
        onClickRow: function (row, $element) {
            curRow = row;
        },
        sortStable: true,
        sortName: "id",
        sortOrder:"asc",
        showFooter: true,
        footerStyle:function footerStyle(value, row, index) {
            return {
                css: { "font-weight": "bold", "font-size": "20px" }
            }
        },
        showExport:true,
        exportDataType:"all",
        exportTypes: ['pdf', 'csv', 'excel', 'doc'],
        rowStyle:function rowStyle(row, index) {
            return {
                css: { "font-size": "20px" }
            }
        },
        exportOptions:{
            "autotable": {
                "styles": { "rowHeight": 20, "fontSize": 20},
                "headerStyles": { "fillColor": 255, "textColor": 0 },
                "alternateRowStyles": { "fillColor": [60, 69, 79], "textColor": 255 }
            }
        },
        columns: [{
            field: 'id',
            title: 'ID',
        }, {
            field: 'configtype',
            title: 'configtype'
        }, {
            field: 'name',
            title: '名称',
            falign:'right',
            footerFormatter: function (value) {
                var count = 0;
                for (var i in value) {
                    count += value[i].amount;
                }
                return '总价:￥'+count;
            }
        },
            {
                field: 'hardware',
                title: '品牌规格型号',
                editable: {
                    type: 'select',
                    mode: 'inline',
                    source: {}
                }
            },

            {
                field: 'price',
                title: '单价'
            },

            {
                field: 'quatity',
                title: '数量',
                editable: {
                    type: 'select',
                    mode: 'inline',
                    source: {}
                }
            },

            {
                field: 'amount',
                title: '合计',
                
          
            }
        ],
        onEditableSave: function (field, row, oldValue, $el) {
            //alert(price[row[field] - 1]);
            //alert(row["quatity"]);
            if (field === 'hardware') {
                row["amount"] = price[row[field]-1] * row["quatity"];
                $("#divQuotationGrid").bootstrapTable('updateByUniqueId', { index: row["id"], row: row });
            }

            if (field === 'quatity') {
                row["amount"] = price[row["hardware"]-1] * row[field];
                $("#divQuotationGrid").bootstrapTable('updateByUniqueId', { index: row["id"], row: row });
            }
        }

    });

  
}