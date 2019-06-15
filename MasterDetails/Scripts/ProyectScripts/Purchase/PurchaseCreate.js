

$("#AddButton").click(function () {

    createdRowPurchase();

});


function createdRowPurchase() {

    var selectedItem = getSeleltedItem();

    var index = $("#PurchaseDetailsTable").children("tr").length;

    var sl = index;

    var indexCell = "<td style ='display:none'><input type='hidden' id='index" + index + "'name='PurchaseDetailses.Index' value='" + index + "'  /></td>";

    var SerialCell = "<td>" + (++sl) + "</td>";

    var ItemNameCell = "<td><input type='hidden' id='ItemName" + index + "' name='PurchaseDetailses[" + index + "].Name' value='" + selectedItem.ItemName + "'/>" + selectedItem.ItemName + " </td>";
    
    var ItemQtyCell = "<td><input type='hidden' id='ItemQty" + index + "' name='PurchaseDetailses[" + index + "].Qty' value='" + selectedItem.ItemQty + "'/>" + selectedItem.ItemQty + " </td>";

    var ItemPriceCell = "<td><input type='hidden' id='ItemPrice" + index + "' name='PurchaseDetailses[" + index + "].Price' value='" + selectedItem.ItemPrice + "'/>" + selectedItem.ItemPrice + " </td>";

    var createdNewRow = "<tr>" + indexCell + SerialCell + ItemNameCell + ItemQtyCell + ItemPriceCell + "</tr>";

    console.log(ItemNameCell);
    console.log(ItemQtyCell);
    console.log(ItemPriceCell);

    $("#PurchaseDetailsTable").append(createdNewRow);

    //$("#ItemName").val('');
    $("#ItemQty").val('');
    $("#ItemPrice").val('');


}

function getSeleltedItem() {

    var TipoProductoId = $("#myselect").val();
    var TipoProductoName = $("#myselect option:selected").text();

    var itemName = $("#ItemName").val();
    var itemQty = $("#ItemQty").val();
    var itemPrice = $("#ItemPrice").val();

    console.log(itemName);


    var item = {

        "ItemName": TipoProductoId,
        "ItemName": TipoProductoName,
        "ItemName": itemName,
        "ItemQty": itemQty,
        "ItemPrice": itemPrice

    }

    return item;
}

