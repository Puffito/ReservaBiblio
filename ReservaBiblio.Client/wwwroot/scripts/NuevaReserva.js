let newReservation = document.getElementById("newReservation");

if (newReservation != null) {
    newReservation.addEventListener("click", (e) => {
        location.href = "/novaReserva"
    });
}