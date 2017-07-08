$(function () {

    LoadQuotationGrid();
    $("#divQuotationGrid").bootstrapTable('hideColumn', 'configtype');
    $("#divQuotationGrid").bootstrapTable('hideColumn', 'id');

})

function LoadQuotationGrid()
{
    var curRow = {};
    var price = new Array(15, 23, 35)
    $('#divQuotationGrid').bootstrapTable({
        idField:"id",
        url: '/ComputerCategory/GetJsonData',
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
                    source: [{ value: "1", text: "ADM A10-5800K(盒)" }, { value: "2", text: "ADM A11-5800K(盒)" }, { value: "3", text: "ADM A12-5800K(盒)" }]
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
                    source: [{ value: "1", text: "1" }, { value: "2", text: "2" }, { value: "3", text: "3" }, { value: "4", text: "4" }, { value: "5", text: "5" }]
                }
            },

            {
                field: 'amount',
                title: '合计',
                footerFormatter: function (value) {
                    var count = 0;
                    for (var i in value) {
                        count += value[i].amount;
                    }
                    return count;
                }
                
          
            }
        ],
        onEditableSave: function (field, row, oldValue, $el) {
            //alert(price[row[field] - 1]);
            //alert(row["quatity"]);
            if (field == 'hardware') {
                row["amount"] = price[row[field]-1] * row["quatity"];
                $("#divQuotationGrid").bootstrapTable('updateByUniqueId', { index: row["id"], row: row });
            }

            if (field == 'quatity') {
                row["amount"] = price[row["hardware"]-1] * row[field];
                $("#divQuotationGrid").bootstrapTable('updateByUniqueId', { index: row["id"], row: row });
            }
        }

    });

  
}