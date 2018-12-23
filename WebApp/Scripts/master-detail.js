
$(function () {
    var orderUrl = '@Url.Action("getOrders", "Home")';
    var table = $("#ordersTable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": false,
        "orderMulti": false,
        "ajax": {
            "url": orderUrl,
            "type": "POST",
            "datatype": "json"
        },
        "columns": [

            { "data": "customerName", "name": "customerName", "autoWidth": true },
            { "data": "address", "name": "address", "autoWidth": true },
            { "data": "orderDate", "name": "orderDate", "autoWidth": true },
            { "data": null, "name": "Action", "defaultContent": '<a href="#" class="editItem">Edit Order</a>', "autoWidth": true }
        ]
    });

    var saveUrl = '@Url.Action("saveOrder", "Home", new { area=""})';

    $("#addNewItem").click(function (e) {
        e.preventDefault();
        $("#customerName").val('');
        $("#address").val('');
        $("#orderMasterId").val('');
        $("#detailsTable tbody tr").remove();
        $("#saveOrder").html("Save Order");
        $('#newOrderModal').modal('show');
    });

    $("#addMore").click(function (e) {
        e.preventDefault();
        $('#orderDetailsModal').modal('show');
    });

    $("#addToList").click(function (e) {
        e.preventDefault();
        if ($.trim($("#productName").val()) == "" || $.trim($("#price").val()) == "" || $.trim($("#quantity").val()) == "") return;
        var productName = $("#productName").val(),
            price = $("#price").val(),
            quantity = $("#quantity").val(),
            detailsTableBody = $("#detailsTable tbody");
        var productItem = '<tr><td>' + productName + '</td><td>' + price + '</td><td>' + quantity + '</td><td>' + (parseFloat(price) * parseInt(quantity)) + '</td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
        detailsTableBody.append(productItem);
        clearItem();
    });

    function clearItem() {
        $("#productName").val('');
        $("#price").val('');
        $("#quantity").val('');
    }

    function saveOrder(data) {
        return $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: saveUrl,
            data: data
        });
    }

    function getOrder(id) {
        return $.ajax({
            type: 'GET',
            url: '@Url.Action("getSingleOrder", "Home", new { area = "" })',
            data: "orderId=" + id
        });
    }

    function getSingleOrderDetail(id) {
        return $.ajax({
            type: 'GET',
            url: '@Url.Action("getSingleOrderDetail", "Home", new { area = "" })',
            data: "id=" + id
        });
    }

    function deleteOrderItem(id) {
        return $.ajax({
            type: 'POST',
            url: '@Url.Action("deleteOrderItem", "Home", new { area = "" })',
            data: "id=" + id
        });
    }

    $(document).on('click', 'a.deleteItem', function (e) {
        e.preventDefault();
        var $self = $(this);
        if ($(this).attr('data-itemId') == "0") {
            $(this).parents('tr').css("background-color", "#FF3700").fadeOut(800, function () {
                $(this).remove();
            });
        } else {
            $.when(deleteOrderItem($(this).attr('data-itemId'))).then(function (res) {
                $self.parents('tr').css("background-color", "#FF3700").fadeOut(800, function () {
                    $(this).remove();
                });
            }).fail(function (err) {
            });
        }
    });
    $("#saveOrder").click(function (e) {
        e.preventDefault();
        var orderArr = [];
        orderArr.length = 0;
        $.each($("#detailsTable tbody tr"), function () {
            orderArr.push({
                ProductName: $(this).find('td:eq(0)').html(),
                Quantity: $(this).find('td:eq(2)').html(),
                Amount: $(this).find('td:eq(1)').html()
            });
        });

        var data = JSON.stringify({
            CustomerName: $("#customerName").val(),
            Address: $("#address").val(),
            OrderDetails: orderArr
        });
        $.when(saveOrder(data)).then(function (response) {
            console.log(response);
        }).fail(function (err) {
            console.log(err);
        });
    });

    $(document).on("click", '.editItem', function (e) {
        var data = table.row($(this).parents('tr')).data();
        //console.log(data);
        e.preventDefault();
        var id = data.masterId;
        $.when(getOrder(id)).then(function (res) {
            var detArr = [];
            $("#customerName").val(res.result.CustomerName);
            $("#address").val(res.result.Address);
            $("#orderMasterId").val(res.result.MasterId);
            $.each(res.result.OrderDetails, function (i, v) {
                detArr.push('<tr><td>' + v.ProductName + '</td><td>' + v.Amount + '</td><td>' + v.Quantity + '</td><td>' + (parseFloat(v.Amount) * parseInt(v.Quantity)) + '</td><td><a data-itemId="' + v.DetailId + '" href="#" class="deleteItem">Delete</a> | <a href="#" data-itemId="' + v.DetailId + '" class="editDetail">Edit</a></td></tr>')
            });
            $("#detailsTable tbody").append(detArr);
            $("#saveOrder").html("Save Update");
            $('#newOrderModal').modal('show');

        }).fail(function (err) {
            console.log(err);
        });
    });

    $(document).on("click", '.editDetail', function (e) {
        e.preventDefault();
        var id = $(this).attr("data-itemid");
        $.when(getSingleOrderDetail(id)).then(function (res) {
            var detArr = [],
                data = res.result;
            $("#detailId").val(data.DetailId);
            $("#productName").val(data.ProductName);
            $("#price").val(data.Amount);
            $("#quantity").val(data.Quantity);

            $('#orderDetailsModal').modal('show');
        }).fail(function (err) {
            console.log(err);
        });
    });

});
