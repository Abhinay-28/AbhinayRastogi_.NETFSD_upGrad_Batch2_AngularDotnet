let db;

let request = indexedDB.open("ExpenseDB", 1);

request.onupgradeneeded = function (event) {
    db = event.target.result;
    let store = db.createObjectStore("expenses", {
        keyPath: "id",
        autoIncrement: true
    });
};

request.onsuccess = function (event) {
    db = event.target.result;
};

request.onerror = function () {
    console.log("Database error");
};

function addExpense() {
    let title = document.getElementById("title").value;
    let amount = document.getElementById("amount").value;
    let date = document.getElementById("date").value;

    let transaction = db.transaction(["expenses"], "readwrite");

    transaction.onerror = function () {
        console.log("Transaction failed");
    };

    let store = transaction.objectStore("expenses");

    let data = {
        title: title,
        amount: amount,
        date: date
    };

    let addRequest = store.add(data);

    addRequest.onerror = function () {
        console.log("Insert error");
    };
}

function viewExpenses() {
    let list = document.getElementById("expenseList");
    list.innerHTML = "";

    let transaction = db.transaction(["expenses"], "readonly");

    transaction.onerror = function () {
        console.log("Transaction error");
    };

    let store = transaction.objectStore("expenses");
    let request = store.openCursor();

    request.onerror = function () {
        console.log("Query error");
    };

    request.onsuccess = function (event) {
        let cursor = event.target.result;

        if (cursor) {
            let li = document.createElement("li");
            li.innerHTML =
                cursor.value.title + " - ₹" +
                cursor.value.amount + " - " +
                cursor.value.date +
                ' <button onclick="deleteExpense(' +
                cursor.value.id +
                ')">Delete</button>';

            list.appendChild(li);
            cursor.continue();
        }
    };
}

function deleteExpense(id) {
    let transaction = db.transaction(["expenses"], "readwrite");

    transaction.onerror = function () {
        console.log("Delete transaction error");
    };

    let store = transaction.objectStore("expenses");
    let request = store.delete(id);

    request.onerror = function () {
        console.log("Delete error");
    };

    request.onsuccess = function () {
        viewExpenses();
    };
}