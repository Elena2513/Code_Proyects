
var Conciliacion = {

    ToList_Conciliacion: function () {
        $.ajax({
            url: baseUrl + "/Conciliacion/Listar_Consolidado",
            dataType: "JSON",
            type: "GET",
            data: {
                tipo: 0,
                inicio: $("#ingreso-inicio").val(),
                final: $("#ingreso-final").val()
            },
            beforeSend: function () {
                html = "<tr><td colspan = '7' class = 'text-center'><h2> Cargando.... </h2></td></tr>";
                $("#table-result-Pendiente").html(html);
            }

        }).done(function (response) {

            html = "";
            item = 0;

            $.each(response, function (index, value) {

                item++;
                html += "<tr>";                
                html += "<td>" + item + "</td>";
                html += "<td>" + value.Carnet + "</td>";
                html += "<td>" + value.DelegacionPolicial + "</td>";
                html += "<td>" + json2Date(value.FechaIngreso) + "</td>";
                html += "<td>" + value.TotalDetenidos + "</td>";
                html += "<td>" + value.RecibidoDia + "</td>";
                html += "<td>" + value.IngresoDelito + "</td>";
                html += "<td>" + value.IngresoFalta + "</td>";
                html += "<td>" + value.IngresoTransito + "</td>";
                html += "<td>" + value.EgresoOrdenLibertad + "</td>";
                html += "<td>" + value.EgresoTrasladoSPN + "</td>";
                html += "<td>" + value.EgresoTrasladoDelegacion + "</td>";               
                html += "</tr>";

            });

            $("#table-result-conciliacion").html(html);
        });
    },

    Save_Conciliar: function () {
        data_Conciliar = [];

        datos = {
            FechaIngreso: $("#ingreso-fecha").val(),
            CodDelegacion: $("#ingreso-delegacion").val(),
            MujerAdolescente: $("#ingreso-MujerAdolesc").val(),
            TotalDetenidos: $("#ingreso-totalDetenido").val(),
            RecibidoDia: $("#ingreso-recibidoDia").val(),
            IngresoDelito: $("#ingreso-delito").val(),
            IngresoFalta: $("#ingreso-falta").val(),
            IngresoTransito: $("#ingreso-transito").val(),
            EgresoOrdenLibertad: $("#ingreso-ordenLibertad").val(),
            EgresoTrasladoSPN: $("#ingreso-trasladoSPN").val(),
            EgresoTrasladoDelegacion: $("#ingreso-trasladoOtraDeleg").val(),
            HombreAdulto: $("#ingreso-hombrAdult").val(),
            MujerAdulta: $("#ingreso-MujerAdult").val(),
            HombreAdolescente: $("#ingreso-hombrAdolesc").val(),
            MujerAdolescente: $("#ingreso-MujerAdolesc").val()
        };

        data_Conciliar.push(datos);
        save(baseUrl + "/Conciliacion/Save", { data_Conciliar: data_Conciliar });
        this.Limpiar();
    },

    Limpiar: function () {

        $("#ingreso-totalDetenido").val("");
        $("#ingreso-recibidoDia").val("");
        $("#ingreso-delito").val("");
        $("#ingreso-falta").val("");
        $("#ingreso-transito").val("");
        $("#ingreso-ordenLibertad").val("");
        $("#ingreso-trasladoSPN").val("");
        $("#ingreso-trasladoOtraDeleg").val("");
        $("#ingreso-hombrAdult").val("");
        $("#ingreso-MujerAdult").val("");
        $("#ingreso-hombrAdolesc").val("");
        $("#ingreso-MujerAdolesc").val("");

    },

    ToList_ReportadoDiferencia: function () {
        $.ajax({
            url: baseUrl + "/Conciliacion/Listar_Diferencia",
            dataType: "JSON",
            type: "GET",
            data: {
                tipo: 1,
                inicio: $("#diferencia-final").val(),
                final: $("#diferencia-final").val(),
            },
            beforeSend: function () {
               
            }

        }).done(function (response) {

            html = "";
            item = 0;

            $.each(response, function (index, value) {
                              
                html += "<tr>";
                html += "<td rowspan='3' class='text-center'>" + value.Descripcion + "</td>";
                html += "<td>Fisico</td>";               
                html += "<td>" + value.Fisico_TotalDetenidos + "</td>";
                html += "<td>" + value.fisico_RecibidoDia + "</td>";
                html += "<td>" + value.Fisico_IngresoDelito + "</td>";
                html += "<td>" + value.Fisico_IngresoFalta + "</td>";
                html += "<td>" + value.Fisico_IngresoTransito + "</td>";
                html += "<td>" + value.Fisico_EgresoLibertad + "</td>";
                html += "<td>" + value.Fisico_EgresoTrasladoSPN + "</td>";
                html += "<td>" + value.Fisico_EgresoTrasladoDeleg + "</td>";
                html += "</tr>";

                html += "<tr>";
                html += "<td>Sicond</td>";                
                html += "<td>" + value.Sicond_TotalDetenidos + "</td>";
                html += "<td>" + value.sicond_RecibidoDia + "</td>";
                html += "<td>" + value.Sicond_IngresoDelito + "</td>";
                html += "<td>" + value.Sicond_IngresoFalta + "</td>";
                html += "<td>" + value.Sicond_IngresoTransito + "</td>";
                html += "<td>" + value.Sicond_EgresoLibertad + "</td>";
                html += "<td>" + value.Sicond_EgresoTrasladoSPN + "</td>";
                html += "<td>" + value.Sicond_EgresoTrasladoDeleg + "</td>";
                html += "</tr>";

                html += "<tr>";
                html += "<td>Diferencia</td>";                
                html += "<td>" + value.Diferencia_TotalDetenidos + "</td>";
                html += "<td>" + value.Diferencia_RecibidoDia + "</td>";
                html += "<td>" + value.Diferencia_IngresoDelito + "</td>";
                html += "<td>" + value.Diferencia_IngresoFalta + "</td>";
                html += "<td>" + value.Diferencia_IngresoTransito + "</td>";
                html += "<td>" + value.Diferencia_EgresoLibertad + "</td>";
                html += "<td>" + value.Diferencia_EgresoTrasladoSPN + "</td>";
                html += "<td>" + value.Diferencia_EgresoTrasladoDeleg + "</td>";
                html += "</tr>";


            });

            $("#table-Reporta-diferencia").html(html);
        });
    },

    ToList_NoReportadoDiferencia: function () {
        $.ajax({
            url: baseUrl + "/Conciliacion/Listar_NoReportaDiferencia",
            dataType: "JSON",
            type: "GET",
            data: {
                tipo: 0,
                inicio: $("#diferencia-final").val(),
                final: $("#diferencia-final").val(),
            },
            beforeSend: function () {

            }

        }).done(function (response) {

            html = "";
            item = 0;

            $.each(response, function (index, value) {

                html += "<tr>";
                html += "<td>" + value.Descripcion + "</td>";
                html += "<td>Sicond</td>";
                html += "<td>" + value.Sicond_TotalDetenidos + "</td>";
                html += "<td>" + value.sicond_RecibidoDia + "</td>";
                html += "<td>" + value.Sicond_IngresoDelito + "</td>";
                html += "<td>" + value.Sicond_IngresoFalta + "</td>";
                html += "<td>" + value.Sicond_IngresoTransito + "</td>";
                html += "<td>" + value.Sicond_EgresoLibertad + "</td>";
                html += "<td>" + value.Sicond_EgresoTrasladoSPN + "</td>";
                html += "<td>" + value.Sicond_EgresoTrasladoDeleg + "</td>";
                html += "</tr>";

            });

            $("#table-NoReporta-diferencia").html(html);
        });
    },
};

function TotalDetenido() {
    let Recibido = $("#ingreso-recibidoDia").val();
    let delito = $("#ingreso-delito").val();
    let falta = $("#ingreso-falta").val();
    let transito = $("#ingreso-transito").val();
    let ordenLibertad = $("#ingreso-ordenLibertad").val();
    let trasladoSPN = $("#ingreso-trasladoSPN").val();
    let trasladoDeleg = $("#ingreso-trasladoOtraDeleg").val();
    let total = 0;
      
    total = parseInt(Recibido) + parseInt(delito) + parseInt(falta) + parseInt(transito) - parseInt(ordenLibertad) - parseInt(trasladoSPN) - parseInt(trasladoDeleg);

    $("#ingreso-totalDetenido").val(total);
}
