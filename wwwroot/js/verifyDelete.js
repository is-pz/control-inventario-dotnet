window.onload = function (e) {
  let formsDelete = document.querySelectorAll(".form-delete");

  //Se recorren todos los formularios de eliminar
  formsDelete.forEach((form) => {
    form.addEventListener("submit", (e) => {
      e.preventDefault();
      e.stopPropagation();
      //Pregunta para estar seguro de eliminar el registro
      Swal.fire({
        title: "¿Quieres eliminar el registro?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "Cancelar",
        confirmButtonText: "Sí",
      }).then((result) => {
        if (result.isConfirmed) {
          let idForm = e.target.getAttribute("data-id"); //Se obtiene el ID del elemento seleccionado
          document.querySelector(`#form-delete-${idForm}`).submit();//Se envía el formulario de eliminación
        }
      });
    });
  });
};
