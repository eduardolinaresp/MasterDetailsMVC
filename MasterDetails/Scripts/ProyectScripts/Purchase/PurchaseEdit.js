

$(document).ready(function () {

    $("#AddButton").click(function () {

        createdRowPurchase();

    });


    buscar(1);
});

function createdRowPurchase() {

    var selectedItem = getSeleltedItem();

    var index = $("#PurchaseDetailsTable").children("tr").length;

    var sl = index;

    var indexCell = "<td style ='display:none'><input type='hidden' id='index" + index + "'name='PurchaseDetailses.Index' value='" + index + "'  /></td>";

    var SerialCell = "<td>" + (++sl) + "</td>";

    var ItemNameCell = "<td><input type='hidden' id='ItemName" + index + "' name='PurchaseDetailses[" + index + "].Name' value='" + selectedItem.ItemName + "'/>" + selectedItem.ItemName + " </td>";


    console.log(selectedItem.ItemName);

    var ItemQtyCell = "<td><input type='hidden' id='ItemQty" + index + "' name='PurchaseDetailses[" + index + "].Qty' value='" + selectedItem.ItemQty + "'/>" + selectedItem.ItemQty + " </td>";

    var ItemPriceCell = "<td><input type='hidden' id='ItemPrice" + index + "' name='PurchaseDetailses[" + index + "].Price' value='" + selectedItem.ItemPrice + "'/>" + selectedItem.ItemPrice + " </td>";

    var createdNewRow = "<tr>" + indexCell + SerialCell + ItemNameCell + ItemQtyCell + ItemPriceCell + "</tr>";

    console.log(ItemNameCell);
    console.log(ItemQtyCell);
    console.log(ItemPriceCell);

    $("#PurchaseDetailsTable").append(createdNewRow);

    $("#ItemName").val('');
    $("#ItemQty").val('');
    $("#ItemPrice").val('');


}

function getSeleltedItem() {

    var itemName = $("#ItemName").val();
    var itemQty = $("#ItemQty").val();
    var itemPrice = $("#ItemPrice").val();

    console.log(itemName);


    var item = {

        "ItemName": itemName,
        "ItemQty": itemQty,
        "ItemPrice": itemPrice

    }

    return item;
}


function buscar(page) {

    var encode_json = "{'id':'" + $("#txtOrderId").val() + "'}";

    var resp;
    var sl = 0;
    $.ajax({
        type: "POST",
        url: "../GetDetalleRows",
        data: encode_json,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (data) {
            var row = "";
            $.each(data, function (index, item) {
                row += "<tr><td>" + (++sl) + "</td><td><input type='hidden' id='ItemName" + item.id + "' name='PurchaseDetailses[" + item.id + "].Name' value='" + item.Name + "'/>" + item.Name + "</td><td><input type='hidden' id='ItemName" + item.id + "' name='PurchaseDetailses[" + item.id + "].Qty' value='" + item.Qty + "'/>" + item.Qty + "</td><td><input type='hidden' id='ItemName" + item.id + "' name='PurchaseDetailses[" + item.id + "].Price' value='" + item.Price + "'/>" + item.Price + "</td></tr>";

                console.log(row);
            });
           // $("#PurchaseDetailsTable").html(row);
            $("#PurchaseDetailsTable").append(row);
            
        },
        error: function (result) {
            alert("Error");
        }

    });

    //row += "<tr><td>" + (++sl) + "</td><td><input type='hidden' id='ItemName" + item.id + "' name='PurchaseDetailses[" + item.id + "].Name' value='" + item.Name + "'/>" + item.Name + "</td><td><input type='hidden' id='ItemName" + item.id + "' name='PurchaseDetailses[" + item.id + "].Qty' value='" + item.Qty + "'/>" + item.Qty + "</td><td><input type='hidden' id='ItemName" + item.id + "' name='PurchaseDetailses[" + item.id + "].Price' value='" + item.Price + "'/>" + item.Price + "</td></tr>";

    //row += "<tr><td style ='display:none'><input type='hidden' id='ItemId" + item.id + "'name='PurchaseDetailses.Id' value='" + item.id + "'  /></td><td>" + (++sl) + "</td><td>" + item.Name + "</td><td>" + item.Qty + "</td><td>" + item.Price + "</td></tr>";
   // window.location.href = "../GetDetalleRows?id=5";

  
};

