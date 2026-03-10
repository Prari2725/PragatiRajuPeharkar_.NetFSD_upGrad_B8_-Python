if (!localStorage.getItem("users")) {
    localStorage.setItem("users", JSON.stringify([]));
}

function login() {

    const username = document.getElementById("username").value.trim();
    const password = document.getElementById("password").value.trim();

    if (!username || !password) {
        alert("Enter username and password");
        return;
    }

    const users = JSON.parse(localStorage.getItem("users")) || [];

    const user = users.find(u =>
        u.name === username && u.password === password
    );

    if (user) {
        localStorage.setItem("loggedInUser", JSON.stringify(user));
        window.location.href = "bankdashboard.html";
    } else {
        alert("Invalid Username or Password!");
    }
}

function register() {

    const name = document.getElementById("regName").value.trim();
    const password = document.getElementById("regPassword").value.trim();
    const balance = parseFloat(document.getElementById("regBalance").value);

    if (!name || !password || isNaN(balance)) {
        alert("Please fill all fields properly.");
        return;
    }

    const users = JSON.parse(localStorage.getItem("users")) || [];

    const userExists = users.some(u => u.name === name);

    if (userExists) {
        alert("Username already exists!");
        return;
    }

    const newUser = {
        userId: Date.now(),
        name: name,
        password: password,
        accountNumber: Math.floor(1000000000 + Math.random() * 9000000000),
        balance: balance
    };

    users.push(newUser);
    localStorage.setItem("users", JSON.stringify(users));

    alert("Registration successful! Please login.");
    window.location.href = "login.html";
}

function logout() {
    localStorage.removeItem("loggedInUser");
    window.location.href = "login.html";
}