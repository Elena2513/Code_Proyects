var Busqueda = {

    ToList_Detenido: function () {
        $.ajax({
            url: baseUrl + "/Busqueda/Listado_DatosDetenido",
            dataType: "JSON",
            type: "GET",
            data: {
                tipo: $("#busqueda-tipo").val(),
                descripcion: $("#busqueda-descripcion").val(),
               
            },
            beforeSend: function () {
                $("#modal-loading").modal();
            }

        }).done(function (response) {

            $("#modal-loading").modal("hide");

            console.log(response);
           

            if (response != "") {
                html = "";

                $.each(response, function (index, value) {

                    html += "<tr>";
                    html += "<td><img src='" + value.Foto + "' width='150px' height='150px'/></td>";
                    html += "<td>" + value.NombreCompleto + "</td>";
                    html += "<td>" + value.Cedula + "</td>";
                    html += "<td>" + json2Date(value.FechaRegistro) + "</td>";
                    html += "<td>" + value.Estructura + "</td>";
                    html += "<td><a class='btn btn-warning btn-datos text-light' data-index='" + value.Idno + "' >Ver Reporte</a></td>";
                    html += "</tr>";

                });

                $("#table-result-detenido").html(html);
                $("#listBusNombre").DataTable();
            }
            else {
                MensajeGuardado("No se encontro resultado");

            }
            
            
        });
    },

}

//FICHA O REPORTE DEL DETENIDO
function Cargar_ReporteDetenido(Idno) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_DetalleDetenido",
        type: "GET",
        data: {
            Idno: Idno
        },
        dataType: "JSON",
        beforeSend: function () {
            $("modal-data-preview").modal();
        }

    }).done(function (response) {

        $("data-title").text("Datos Personales");

        html = "<div class='text-xs-center'>";
        html += "<h1 style='margin:0px; padding:0px;'>POLICIA NACIONAL</h1>";
        html += "<h2 style='margin:0px; padding:0px;'>" + response.Estructura + "</h2>";
        html += "<h4 style='margin:0px; padding:0px;'> Datos y Movimiento del Detenido </h4>";
        html += "</div>";

        html += "</br>";

        html += "<div class='modal-body' syle='height:400px;'>"; //inicio body

        html += "<ul class='nav nav-tabs'>"; //inicio ul
        html += "<li class='nav-item'>"; //li de datos detenido
        html += "<a class='nav-link active' id='base-tab1' data-toggle='tab' aria-controls='tab1' href='#tab1' aria-expanded='true'> Datos Personales </a>";
        html += "</li>"; //fin li de datos detenido

        html += "<li class='nav-item'>"; //li delitos
        html += "<a class='nav-link' id='base-tab2' data-toggle='tab' aria-controls='tab2' href='#tab2' aria-expanded='false'> Delitos </a>";
        html += "</li>";  //fin li delitos

        html += "<li class='nav-item'>"; //li delitos
        html += "<a class='nav-link' id='base-tab3' data-toggle='tab' aria-controls='tab3' href='#tab3' aria-expanded='false'> Movimientos </a>";
        html += "</li>";  //fin li delitos

        html += "</ul>"; //fin ul

        //agregar los datos en cada uno de los tab
        html += "<div class='tab-content px-1 pt-1'>"; //inicio tab
        html += "<div role='tabpanel' class='tab-pane active' id='tab1' aria-expanded='true' aria-labelledby='base-tab1'>"; //inicio tab1

        ///*INICIO DATOS DEL DETENIDO*/
        html += "<div class='row'>";

        html += "<div class='col-md-8 col-sm-8 col-lg-8'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='2'>DATOS PERSONALES</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";

        html += "<tr>";
        html += "<th>Nacionalidad</th><td colspan='3'>" + response.Nacionalidad + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Identificación</th><td colspan='3'>" + response.Cedula + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Primer Nombre</th><td colspan='3'>" + response.Nombre1 + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Segundo Nombre</th><td colspan='3'>" + response.Nombre2 + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Primer Apellido</th><td colspan='3'>" + response.Apellido1 + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Segundo Apellido</th><td colspan='3'>" + response.Apellido2 + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Alias</th><td colspan='3'>" + response.Alias + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Fecha Ingreso</th><td colspan='3'>" + json2Date(response.FechaRegistro) + "</td>";
        html += "</tr>";
        html += "</table>";
        html += "</div>";

        html += "<div class='col-md-4 col-sm-4 col-lg-4'>";
        html += "<img src='" + response.Foto + "' width='228px' height='304px'/>";
        html += "</div>";
        html += "</div>";  //final de lo datos del detenido

        //OTRO DATOS
        html += "<div class='row'>";

        html += "<div class='col-md-6 col-sm-6 col-lg-6 ' >";
        html += "<table class='table'>";
        html += "<tr>";
        html += "<th>Ocupacion</th><td colspan='3'>" + response.Ocupacion + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Nivel Academico</th><td colspan='3'>" + response.NivelAcademico + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Centro de Trabajo</th><td colspan='3'>" + response.CentroTrabajo + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Direccion Trabajo</th><td colspan='3'>" + response.DireccionCentroTrabajo + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Estado Civil</th><td colspan='3'>" + response.EstadoCivil + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Nombre Conyuge</th><td colspan='3'>" + response.NombreConyuge + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Dirección Conyuge</th><td colspan='3'>" + response.DireccionConyuge + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Ojos</th><td colspan='3'>" + response.Ojos + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Estatura</th><td colspan='3'>" + response.Estatura + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Peso</th><td colspan='3'>" + response.Peso + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Fecha Nacimiento</th><td colspan='3'>" + json2Date(response.FechaNac) + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Edad</th><td colspan='3'>" + response.Edad + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Familiar Notificar</th><td colspan='3'>" + response.FamiliarNotificar + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Departamento</th><td colspan='3'>" + response.Depto + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Delegación</th><td colspan='3'>" + response.Estructura + "</td>";
        html += "</tr>";
        html += "</table>";
        html += "</div>";

        html += "<div class='col-md-6 col-sm-6 col-lg-6'>";
        html += "<table class='table'>";
        html += "<tr>";
        html += "<th>Nombre Padre</th><td colspan='3'>" + response.NombrePadre + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Nombre Madre</th><td colspan='3'>" + response.NombreMadre + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Dirección</th><td colspan='3'>" + response.Direccion + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Señas Particulares</th><td colspan='3'>" + response.SenasParticulares + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Ubicación Señas Particulares</th><td colspan='3'>" + response.UbicaSenas + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Familiar Cercano</th><td colspan='3'>" + response.FamiliarCercano + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Dirección Familiar Cercano</th><td colspan='3'>" + response.DireccionFamiliarCercano + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Piel</th><td colspan='3'>" + response.Piel + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Complexión</th><td colspan='3'>" + response.Complexion + "</td>";
        html += "</tr>";
        html += "<tr>";
        html += "<th>Observación</th><td colspan='3'>" + response.Observaciones + "</td>";
        html += "</tr>";
        html += "</table>";
        html += "</div>";

        html += "</div>"; //fin de otros datos



        html += "</div>"; //fin tab1


        html += "<div class='tab-pane' id='tab2' aria-labelledby='base-tab2'>"; //inicio tab2

        ///DELITO ACTUAL
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='9'>ACTUAL</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Detención</th>";
        html += "<th>Delito</th>";
        html += "<th>Investigador</th>";
        html += "<th>Lugar Detenciòn</th>";
        html += "<th>Celda</th>";
        html += "<th>Tipo Detención</th>";
        html += "<th>Motivo Detención</th>";
        html += "<th>Codigo</th>";
        html += "<th>Hora Detención</th>";
        html += "</tr>";

        $.each(response.DelitoActivo, function (index1, value1) {
            html += "<tr>";
            html += "<td>" + json2Date(value1.FechaDetencion) + "</td>";
            html += "<td>" + value1.Delito + "</td>";
            html += "<td>" + value1.Investigador + "</td>";
            html += "<td>" + value1.LugarDetencion + "</td>";
            html += "<td>" + value1.Celda + "</td>";
            html += "<td>" + value1.TipoDetencion + "</td>";
            html += "<td>" + value1.MotivoDetencion + "</td>";
            html += "<td>" + value1.Codigo + "</td>";
            html += "<td>" + value1.HoraDetencion + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>";


        ////DELITOS ANTECEDENTE
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='9'>ANTECEDENTE</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Detención</th>";
        html += "<th>Delito</th>";
        html += "<th>Investigador</th>";
        html += "<th>Lugar Detenciòn</th>";
        html += "<th>Celda</th>";
        html += "<th>Tipo Detención</th>";
        html += "<th>Motivo Detención</th>";
        html += "<th>Codigo</th>";
        html += "<th>Hora Detención</th>";
        html += "</tr>";

        $.each(response.Delito, function (index2, value2) {
            html += "<tr>";
            html += "<td>" + json2Date(value2.FechaDetencion) + "</td>";
            html += "<td>" + value2.Delito + "</td>";
            html += "<td>" + value2.Investigador + "</td>";
            html += "<td>" + value2.LugarDetencion + "</td>";
            html += "<td>" + value2.Celda + "</td>";
            html += "<td>" + value2.TipoDetencion + "</td>";
            html += "<td>" + value2.MotivoDetencion + "</td>";
            html += "<td>" + value2.Codigo + "</td>";
            html += "<td>" + value2.HoraDetencion + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>";


        html += "</div>"; //fin tab2

        html += "<div class='tab-pane' id='tab3' aria-labelledby='base-tab3'>"; //inicio tab3


        //MOVIMIENTOS DEL DETENIDO
        //baja de presunto
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Baja de Presunto</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Registro</th>";
        html += "<th>Motivo Observa</th>";
        html += "</tr>";

        $.each(response.BajaPresunto, function (index3, value3) {
            html += "<tr>";
            html += "<td>" + json2Date(value3.FechaRegistro) + "</td>";
            html += "<td>" + value3.MotivoObserva + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin baja de presunto

        //orden de libertad
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Orden de Libertad</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Registro</th>";
        html += "<th>Orden Libertad</th>";
        html += "<th>NoExpediente</th>";
        html += "<th>Jefe Autoriza</th>";
        html += "<th>Motivo Libertad</th>";
        html += "</tr>";

        $.each(response.OrdenLibertad, function (index4, value4) {
            html += "<tr>";
            html += "<td>" + json2Date(value4.FechaRegistro) + "</td>";
            html += "<td>" + value4.OrdenLibertad + "</td>";
            html += "<td>" + value4.NoExpediente + "</td>";
            html += "<td>" + value4.JefeAutoriza + "</td>";
            html += "<td>" + value4.MotivoLibertad + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin orden de libertad

        //asistencia al juzgado
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Asistencia a Juzgado</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Registro</th>";
        html += "<th>No Asunto</th>";
        html += "<th>Juzgado</th>";
        html += "<th>Ubicación</th>";
        html += "<th>Procesos</th>";
        html += "<th>Motivo Juzgado</th>";
        html += "</tr>";

        $.each(response.AsistenciaJuzgado, function (index5, value5) {
            html += "<tr>";
            html += "<td>" + json2Date(value5.FechaRegistro) + "</td>";
            html += "<td>" + value5.NoAsunto + "</td>";
            html += "<td>" + value5.Juzgado + "</td>";
            html += "<td>" + value5.Ubicacion + "</td>";
            html += "<td>" + value5.Procesos + "</td>";
            html += "<td>" + value5.MotivoJuzgado + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin asistencia al juzgado


        //traslado al sistema penitenciario
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Traslado al Sistema Penitenciario</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Registro</th>";
        html += "<th>Oficial Entrega</th>";
        html += "<th>Oficial Recibe</th>";
        html += "<th>Motivo Traslado</th>";
        html += "</tr>";

        $.each(response.TrasladoSPN, function (index6, value6) {
            html += "<tr>";
            html += "<td>" + json2Date(value6.FechaRegistro) + "</td>";
            html += "<td>" + value6.OficialEntrega + "</td>";
            html += "<td>" + value6.OficialRecibe + "</td>";
            html += "<td>" + value6.MotivoTraslado + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin traslado al sistema penitenciario

        //traslado a otra delegacion
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Traslado a Otra Delegacion</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Registro</th>";
        html += "<th>Orden Traslado</th>";
        html += "<th>No Expediente</th>";
        html += "<th>Jefe Autoriza</th>";
        html += "<th>Oficial Traslada</th>";
        html += "<th>Oficial Recibe</th>";
        html += "<th>Motivo Traslado</th>";
        html += "</tr>";

        $.each(response.TrasladoDelegacion, function (index7, value7) {
            html += "<tr>";
            html += "<td>" + json2Date(value7.FechaRegistro) + "</td>";
            html += "<td>" + value7.OrdenTraslado + "</td>";
            html += "<td>" + value7.NoExpedienteT + "</td>";
            html += "<td>" + value7.JefeAutorizaT + "</td>";
            html += "<td>" + value7.OficialET + "</td>";
            html += "<td>" + value7.OficialRT + "</td>";
            html += "<td>" + value7.MotivoTD + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin traslado a otra delegacion

        //traslado de celda
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Traslado de Celda</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Registro</th>";
        html += "<th>Motivo Observa</th>";
        html += "<th>Celda Actual</th>";
        html += "<th>Celda Destino</th>";
        html += "<th>Motivo Celda</th>";
        html += "</tr>";

        $.each(response.TrasladoCelda, function (index8, value8) {
            html += "<tr>";
            html += "<td>" + json2Date(value8.FechaRegistro) + "</td>";
            html += "<td>" + value8.MotivoObservaTC + "</td>";
            html += "<td>" + value8.CeldaActual + "</td>";
            html += "<td>" + value8.CeldaDestino + "</td>";
            html += "<td>" + value8.MotivoCelda + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin traslado de celda

        //asistencia medica
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Asistencia Medica</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Registro</th>";
        html += "<th>Nombre Doctor</th>";
        html += "<th>Valoracion Medica</th>";
        html += "</tr>";

        $.each(response.AsistenciaMedica, function (index9, value9) {
            html += "<tr>";
            html += "<td>" + json2Date(value9.FechaRegistro) + "</td>";
            html += "<td>" + value9.NombreDoctor + "</td>";
            html += "<td>" + value9.ValoracionMedica + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin asistencia medica

        //valoracion medica IML
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Valoracion Medica IML</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Registro</th>";
        html += "<th>Forence</th>";
        html += "<th>Valoracion</th>";
        html += "<th>IML</th>";
        html += "</tr>";

        $.each(response.ValoracionMedica, function (index10, value10) {
            html += "<tr>";
            html += "<td>" + json2Date(value10.FechaRegistro) + "</td>";
            html += "<td>" + value10.ForenceA + "</td>";
            html += "<td>" + value10.Valoracion + "</td>";
            html += "<td>" + value10.IML + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin valoracion medica IML

        //reunion colectiva
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Reunion Colectiva</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tr>";


        html += "<tr>";
        html += "<th>Fecha Registro</th>";
        html += "<th>Motivo Observa</th>";
        html += "</tr>";

        $.each(response.ReunionColectiva, function (index11, value11) {
            html += "<tr>";
            html += "<td>" + json2Date(value11.FechaRegistro) + "</td>";
            html += "<td>" + value11.MotivoObservaRC + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin reunion colectiva

        html += "</div>"; //fin tab3

        html += "</div>"; //fin tab
        html += "</div>"; //fin body


        $("#data-preview").html(html);
        $("#modal-data-preview").modal();
    });
}