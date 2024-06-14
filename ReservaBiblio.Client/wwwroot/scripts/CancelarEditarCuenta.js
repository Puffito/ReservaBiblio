let cancel = document.getElementById("CancelarEditarCuenta");

if (cancel != null) {
    cancel.addEventListener("click", (e) => {
        location.href = "/conta"
    });
}