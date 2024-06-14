let editAccount = document.getElementById("editarCuenta");

if (editAccount != null) {
    editAccount.addEventListener("click", (e) => {
        location.href = "/editarConta"
    });
}