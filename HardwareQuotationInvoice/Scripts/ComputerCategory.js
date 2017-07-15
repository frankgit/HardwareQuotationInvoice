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
        uniqueId: "Id",
        url: '/ComputerCategory/GetJsonData',
        toolbar: "#toolbar",
        clickEdit:true,
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
                title: '名称',
                editable:'input'
            }, 
        
            {
                field: 'OrderPriorityId',
                title: '优先级',
                editable: 'input'
            }
        ]
        
    });
}



function getIdSelections() {
    return $.map($table.bootstrapTable('getSelections'), function (row) {
        return row.Id
    });
}

function UpdateComputerCategory()
{
    $('#modelLoading').modal('show');
    $.ajax({
        url: "/ComputerCategory/Update",
        type: 'post',
        data: {
            qq:'dd'
        },        
        success: function (data) {

            $('#modelLoading').modal('hide');
        },
        error: function()
        {
            alert("失败");
        }

    });

    $('#myModal').modal('hide')
}