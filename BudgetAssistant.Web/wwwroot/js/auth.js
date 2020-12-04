var loginForm = document.getElementById("login");
var registerForm = document.getElementById("register");
var backBtn = document.getElementById("btn");

function login() {
    loginForm.style.display = "block";
    registerForm.style.display = "none";
    backBtn.style.left = "0";
}

function register() {
    registerForm.style.display = "block";
    loginForm.style.display = "none";
    backBtn.style.left = "110px";
}