function changeToLoginForm() {
    const loginForm = document.getElementById("login");
    const registroForm = document.getElementById("registro");
    const loginButton = document.getElementById("loginButton");
    const registroButton = document.getElementById("registroButton");
    registroForm.classList.add("oculto");
    loginForm.classList.remove("oculto");
    registroButton.classList.remove("buttonOn");
    loginButton.classList.add("buttonOn");
    const title = document.getElementById("formTitle");
    title.innerText = "Inicie sesión";
}

function changeToRegisterForm() {
    const registroForm = document.getElementById("registro");
    const loginForm = document.getElementById("login");
    const registroButton = document.getElementById("registroButton");
    const loginButton = document.getElementById("loginButton");
    loginForm.classList.add("oculto");
    registroForm.classList.remove("oculto");
    loginButton.classList.remove("buttonOn");
    registroButton.classList.add("buttonOn");
    const title = document.getElementById("formTitle");
    title.innerText = "Rexístrese";
}