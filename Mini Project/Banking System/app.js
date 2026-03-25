const user = JSON.parse(localStorage.getItem("loggedInUser"));

if (!user) {
    window.location.href = "html/login.html";
}

document.addEventListener("DOMContentLoaded", () => {
    showProfile();
    loadTransactions();
});

function showProfile() {
    document.getElementById("profileInfo").innerHTML = `
        Name: ${user.name} <br>
        Account No: ${user.accountNumber}
    `;

    document.getElementById("balance").innerText = "₹ " + user.balance;
}

function updateUser(newBalance) {

    let users = JSON.parse(localStorage.getItem("users"));

    users = users.map(u => {
        if (u.userId === user.userId) {
            u.balance = newBalance;
        }
        return u;
    });

    localStorage.setItem("users", JSON.stringify(users));

    user.balance = newBalance;
    localStorage.setItem("loggedInUser", JSON.stringify(user));
}

function deposit() {

    let amount = parseFloat(document.getElementById("amount").value);

    if (isNaN(amount) || amount <= 0) {
        alert("Enter valid amount");
        return;
    }

    let newBalance = user.balance + amount;

    updateUser(newBalance);
    addTransaction("Deposit", amount);

    document.getElementById("amount").value = "";
    showProfile();
    loadTransactions();
}

function withdraw() {

    let amount = parseFloat(document.getElementById("amount").value);

    if (isNaN(amount) || amount <= 0) {
        alert("Enter valid amount");
        return;
    }

    if (amount > user.balance) {
        alert("Insufficient Balance");
        return;
    }

    let newBalance = user.balance - amount;

    updateUser(newBalance);
    addTransaction("Withdraw", amount);

    document.getElementById("amount").value = "";
    showProfile();
    loadTransactions();
}

function addTransaction(type, amount) {

    let transactions = JSON.parse(localStorage.getItem("transactions")) || [];

    transactions.push({
        userId: user.userId,
        type: type,
        amount: amount,
        date: new Date().toLocaleDateString()
    });

    localStorage.setItem("transactions", JSON.stringify(transactions));
}

function loadTransactions() {

    let transactions = JSON.parse(localStorage.getItem("transactions")) || [];

    let list = document.getElementById("transactionList");
    list.innerHTML = "";

    transactions
        .filter(t => t.userId === user.userId)
        .reverse()
        .forEach(t => {

            let badgeColor = t.type === "Deposit" ? "success" : "danger";

            list.innerHTML += `
                <div class="card mb-2 shadow-sm">
                    <div class="card-body d-flex justify-content-between">
                        <div>
                            <h6>${t.type}</h6>
                            <small class="text-muted">${t.date}</small>
                        </div>
                        <span class="badge bg-${badgeColor}">
                            ₹ ${t.amount}
                        </span>
                    </div>
                </div>
            `;
        });
}

function filterTransactions() {

    let selectedDate = document.getElementById("filterDate").value;

    let transactions = JSON.parse(localStorage.getItem("transactions")) || [];

    let list = document.getElementById("transactionList");
    list.innerHTML = "";

    transactions
        .filter(t => 
            t.userId === user.userId &&
            new Date(t.date).toISOString().split("T")[0] === selectedDate
        )
        .forEach(t => {

            let badgeColor = t.type === "Deposit" ? "success" : "danger";

            list.innerHTML += `
                <div class="card mb-2 shadow-sm">
                    <div class="card-body d-flex justify-content-between">
                        <div>
                            <h6>${t.type}</h6>
                            <small class="text-muted">${t.date}</small>
                        </div>
                        <span class="badge bg-${badgeColor}">
                            ₹ ${t.amount}
                        </span>
                    </div>
                </div>
            `;
        });
}

function logout() {
    localStorage.removeItem("loggedInUser");
    window.location.href = "login.html";
}