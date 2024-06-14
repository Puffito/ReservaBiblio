let cancel = document.getElementById("CancelarNuevaReserva");

if (cancel != null) {
    cancel.addEventListener("click", (e) => {
        location.href = "/calendario"
    });
}