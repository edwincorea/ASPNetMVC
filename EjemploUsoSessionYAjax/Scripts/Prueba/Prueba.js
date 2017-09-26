$(function () {
    
    $("#_agregar").click(function () {
        agregarItem();
    });
});

function agregarItem() {
    var idSeleccionado = $("#_items").val();
    var nombreSeleccionado = $('#_items option:selected').text();

    $.ajax(
        {
            method: "POST",
            url: '/Prueba/GuardarItem',
            data: { id: idSeleccionado, nombre: '' + nombreSeleccionado + '' },
            error: function (a, b, c) {
                alert(c);
            }
        }
    ).done(function () {
        MostrarItemsSesion();
    });
}

function MostrarItemsSesion() {
    $.ajax(
       {
           method: "POST",
           url: "/Prueba/ListarItems",
           data: {},
           dataType: "json",
           success: function (data) {
               var contenido = "";
               $("#_agregados").children().remove();
               $.each(data, function (indice, valor) {
                   $("#_agregados").append('<option value="'+valor.Id+'">'+valor.Nombre+'</option>');
               });
           },
           error: function (a, b, c) {
               alert(c);
           }
       }
   );
}