let validName = false;
let validEmail = false;
let validAge = false;

function validateName() {
    let name = document.getElementById("name").value;
    if (name.trim() === "") {
        document.getElementById("nameMsg").innerText = "Name cannot be empty";
        validName = false;
    } else {
        document.getElementById("nameMsg").innerText = "Valid name";
        validName = true;
    }
}

function validateEmail() {
    let email = document.getElementById("email").value;
    if (email.includes("@")) {
        document.getElementById("emailMsg").innerText = "Valid email";
        validEmail = true;
    } else {
        document.getElementById("emailMsg").innerText = "Email must contain @";
        validEmail = false;
    }
}

function validateAge() {
    let age = document.getElementById("age").value;
    if (age > 18) {
        document.getElementById("ageMsg").innerText = "Valid age";
        validAge = true;
    } else {
        document.getElementById("ageMsg").innerText = "Age must be greater than 18";
        validAge = false;
    }
}

function saveData() {
    if (validName && validEmail && validAge) {
        sessionStorage.setItem("userName", document.getElementById("name").value);
        sessionStorage.setItem("userEmail", document.getElementById("email").value);
        sessionStorage.setItem("userAge", document.getElementById("age").value);
        document.getElementById("finalMsg").innerText = "Registration Successful";
    } else {
        document.getElementById("finalMsg").innerText = "Please correct errors before submitting";
    }
}