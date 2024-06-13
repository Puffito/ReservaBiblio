let newReservation = document.getElementById("newReservation");

if (newReservation != null) {
    newReservation.addEventListener("click", (e) => {
        location.href = "/novaReserva"
    });
}

let editAccount = document.getElementById("editarCuenta");

if (editAccount != null) {
    editAccount.addEventListener("click", (e) => {
        location.href = "/editarConta"
    });
}
