var $table = $('#divComputerCategoryGrid'),
    $remove = $('#btnRemove');

$(function () {

    InitGrid();

})

function LoadComputerCategoryGrid(data)
{
    $table.bootstrapTable({
        uniqueId: "Id",
        data: data,
        updateUrl:"test/test",
        toolbar: "#toolbar",
        clickEdit: true,
        sortName: "OrderPriorityId",
        sortOrder:"asc",
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
}



function getIdSelections() {
    return $.map($table.bootstrapTable('getSelections'), function (row) {
        return row.Id
    });
}

function InitGrid() {
    $('#modelLoading').modal('show');
    $.ajax({
        url: "/ComputerCategory/GetJsonData",
        dataType: "json",
        type: 'post',
        success: function (data) {
            LoadComputerCategoryGrid(data.Data)
            $('#modelLoading').modal('hide');
        },
        error: function () {
            alert("失败");
        }

    });

    $('#myModal').modal('hide')
}

function InsertComputerCategory()
{
    $('#modelLoading').modal('show');
    $.ajax({
        url: "/ComputerCategory/Update",
        dataType: "json",
        type: 'post',
        data: {
            name: $("#txtCategoryName").val(),
            priority: $("#txtPriority").val()
        },        
        success: function (data) {
            $table.bootstrapTable('load', data.Data);
            $('#modelLoading').modal('hide');
        },
        error: function()
        {
            alert("失败");
        }

    });

    $('#myModal').modal('hide')
}