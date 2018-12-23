const Item = function (id, name, price) {
    this.id = id;
    this.name = name;
    this.price = price;
}

const InvoiceChild = function (id, itemId, itemName, quantity, cost, invoiceId) {
    this.Id = id;
    this.ItemId = itemId;
    this.ItemName = itemName;
    this.Quantity = quantity;
    this.Cost = cost;
    this.InvoiceId = invoiceId;
}

$(document).ready(function () {
    const ITEM_QTY = $("#itemQty");
    const ITEM_COST = $("#itemCost");
    const SELECTED_ITEM = $("#itemsDropDown");
    const addItemBtn = $("#btnAddItem");

    function getSelectedItem() {
        const valStr = SELECTED_ITEM.val();
        const valArr = valStr.split('|');
        const price = parseFloat(valArr[1]);
        const id = parseInt(valArr[0]);
        const name = SELECTED_ITEM.text();
        return new Item(id, name, price);
    }

    //compute cost of the selected item after qauntity input change and update UI
    ITEM_QTY.change(function (e) {
        const selectedItem = getSelectedItem();
        console.log(selectedItem);
        const cost = (e.target.value * selectedItem.price).toFixed(2);
        ITEM_COST.text(cost);
        console.log(`new cost value: ${cost}`);
    });

    //add selected item into list and update the UI.
    addItemBtn.click(function (e) {
        const selectedItem = getSelectedItem();
        const qty = ITEM_QTY.val();
        const cost = (qty * selectedItem.price).toFixed(2);

        //const item = new InvoiceItem(undefined, selectedItem.id, selectedItem.name, qty, cost);
        const ntr = `<tr><td>${selectedItem.name}</td><td>${selectedItem.price}</td><td>${qty}</td><td>${cost}</td></tr>`;
        $("#orderItemsTable>tbody").append(ntr);
    });
})