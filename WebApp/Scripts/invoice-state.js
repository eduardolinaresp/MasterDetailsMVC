const Item = function (id, name, price) {
    this.id = id;
    this.name = name;
    this.price = price;
}

$(document).ready(function () {
    const ITEM_QTY = $("#itemQty");
    const ITEM_COST = $("#itemCost");
    
    const addItemBtn = $("#btnAddItem");
    const createForm = $("#invoiceCreateForm");

    const invoiceItems = [];

    function getSelectedItem() {
        const SELECTED_ITEM = $("#itemsDropDown option:selected");
        const valStr = SELECTED_ITEM.val();
        const valArr = valStr.split('|');
        const price = parseFloat(valArr[1]);
        const id = parseInt(valArr[0]);
        const name = SELECTED_ITEM.text();
        return new Item(id, name, price);
    }

    function clearItemForm() {
        ITEM_COST.text('');
        ITEM_QTY.val(undefined);
    }

    //compute cost of the selected item after qauntity input change and update UI
    ITEM_QTY.change(function (e) {
        const selectedItem = getSelectedItem();
        console.log(selectedItem);
        const cost = (e.target.value * selectedItem.price).toFixed(2);
        ITEM_COST.text(cost);
        console.log(`new cost value: ${cost}`);
    });

    createForm.submit(function (e) {
        for (let i = 0; i < invoiceItems.length; i++) {
            const itemId = `<input type="hidden" name="InvoiceChildren[${i}].ItemId" value="${invoiceItems[i].id}" />`;
            const qty = `<input type="hidden" name="InvoiceChildren[${i}].Quantity" value="${invoiceItems[i].qty}" />`;
            const cost = `<input type="hidden" name="InvoiceChildren[${i}].Cost" value="${invoiceItems[i].cost}" />`;
            createForm.append(itemId);
            createForm.append(qty);
            createForm.append(cost);
        }
    });

    //add selected item into list and update the UI.
    addItemBtn.click(function (e) {
        const selectedItem = getSelectedItem();
        const qty = ITEM_QTY.val();
        const cost = (qty * selectedItem.price).toFixed(2);

        
        const item = {
            ...selectedItem,
            qty,
            cost
        }

        invoiceItems.push(item);
        totalCost = 0;
        invoiceItems.forEach(function (item) {
            totalCost += parseFloat(item.cost);
        });

        //update table
        const ntr = `<tr><td>${selectedItem.name}</td><td>${selectedItem.price}</td><td>${qty}</td><td>${cost}</td></tr>`;
        $("#orderItemsTable>tbody").append(ntr);

        //update footer items count
        $("#orderItemsCount").text(invoiceItems.length);

        $("#orderItemsCost").text(totalCost);

        clearItemForm();
        e.preventDefault();
    });
})