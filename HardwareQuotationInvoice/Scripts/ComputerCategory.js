var $table = $('#divComputerCategoryGrid'),
    $remove = $('#btnRemove');

$(function () {

    LoadComputerCategoryGrid();
    $("#divQuotationGrid").bootstrapTable('hideColumn', 'id');
    $remove.prop('disabled', true);
    $remove.click(function () {
        var ids = getIdSelections();
        $.each(ids, function (index, value) {
            $table.bootstrapTable('removeByUniqueId', value)
        });

        $remove.prop('disabled', true);
    });

    $table.on('check.bs.table uncheck.bs.table ' +
               'check-all.bs.table uncheck-all.bs.table', function () {
                   $remove.prop('disabled', !$table.bootstrapTable('getSelections').length);

                   // save your data, here just save the current page
                   selections = getIdSelections();
                   // push or splice the selections if you want to save all data selections
               });

})

function LoadComputerCategoryGrid()
{
    $table.bootstrapTable({
        idField: "Id",
        uniqueId: "Id",
        url: '/ComputerCategory/GetJsonData',
        toolbar: "#toolbar",
        groupBy: true,
        clickToSelect: true,
        groupByField: "OrderPriorityId",
        columns: [
            {
                checkbox:true
            },
            {
                field: 'Id',
                title: 'ID',
            },
            {
                field: 'Name',
                title: '名称'
            }, 
        
            {
                field: 'OrderPriorityId',
                title: '优先级',
                falign:'right'
            }
        ]
        
    });
}



function getIdSelections() {
    return $.map($table.bootstrapTable('getSelections'), function (row) {
        return row.Id
    });
}