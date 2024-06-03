
var Estadistica = {

    ToList_Permanecia: function () {

        $.ajax({
            url: baseUrl + "/Estadistica/Consolidado_Permanencia",
            dataType: "JSON",
            type: "GET",
            data: {
                tipo: 0,                
                inicio: $("#permanencia-inicio").val(),
                final: $("#permanencia-final").val(),
            },
            beforeSend: function () {
                html = "<tr><td colspan = '7' class = 'text-center'><h2> Cargando.... </h2></td></tr>";
                $("#table-result-permanencia").html(html);
            }

        }).done(function (response) {

            html = "";

            $.each(response, function (index, value) {

                html += "<tr>";
                html += "<td><p><a href='#' class='indigo Btn-VerDepartamento' data-index='" + value.Codigo + "'>" + value.Descripcion + "</a></p></td>";
                html += "<td>" + value.Total_Celda + "</td>";
                html += "<td>" + value.Capacidad_Celda + "</td>";
                html += "<td>" + value.Recibido_Turno + "</td>";
                html += "<td>" + value.Egresos_Detenidos + "</td>";
                html += "<td>" + value.Ingreso_Detenidos + "</td>";
                html += "<td>" + value.Detenidos_HombresAdult + "</td>";
                html += "<td>" + value.Detenidos_MujerAdult + "</td>";
                html += "<td>" + value.Detenido_HombreAdolesc + "</td>";
                html += "<td>" + value.Detenido_MujerAdolesc + "</td>";
                html += "<td>" + value.Total_Genero + "</td>";
                html += "<td>" + value.Procs_Investigativo + "</td>";
                html += "<td>" + value.Jlocal_Penal + "</td>";
                html += "<td>" + value.JDistrito_Penal + "</td>";
                html += "<td>" + value.Juzgado_Adolesc + "</td>";
                html += "<td>" + value.Detenido_Condenado + "</td>";
                html += "<td>" + value.Tota_Detenidos + "</td>";
                html += "</tr>";

            });

           
            $("#table-result-permanencia").html(html);
          
        });

    },

    ToListMunicipio_Permanencia: function (codigo) {

        $.ajax({
            url: baseUrl + "/Estadistica/Consolidado_Permanencia",
            dataType: "JSON",
            type: "GET",
            data: {
                tipo: 1,
                codigo: codigo,
                inicio: $("#permanencia-inicio").val(),
                final: $("#permanencia-final").val(),
            },
            beforeSend: function () {
                html = "<tr><td colspan = '7' class = 'text-center'><h2> Cargando.... </h2></td></tr>";
                $("#table-result-permanencia").html(html);
            }

        }).done(function (response) {

            html = "";

            $.each(response, function (index, value) {

                html += "<tr>";
                html += "<td>" + value.Descripcion + "</td>";
                html += "<td>" + value.Total_Celda + "</td>";
                html += "<td>" + value.Capacidad_Celda + "</td>";
                html += "<td>" + value.Recibido_Turno + "</td>";
                html += "<td>" + value.Egresos_Detenidos + "</td>";
                html += "<td>" + value.Ingreso_Detenidos + "</td>";
                html += "<td>" + value.Detenidos_HombresAdult + "</td>";
                html += "<td>" + value.Detenidos_MujerAdult + "</td>";
                html += "<td>" + value.Detenido_HombreAdolesc + "</td>";
                html += "<td>" + value.Detenido_MujerAdolesc + "</td>";
                html += "<td>" + value.Total_Genero + "</td>";
                html += "<td>" + value.Procs_Investigativo + "</td>";
                html += "<td>" + value.Jlocal_Penal + "</td>";
                html += "<td>" + value.JDistrito_Penal + "</td>";
                html += "<td>" + value.Juzgado_Adolesc + "</td>";
                html += "<td>" + value.Detenido_Condenado + "</td>";
                html += "<td>" + value.Tota_Detenidos + "</td>";
                html += "</tr>";

            });
                       
            $("#table-result-permanencia").html(html);
            
        });

    },

    ToList_Consolidado: function () {

        $.ajax({
            url: baseUrl + "/Estadistica/ToList_consolidado",
            dataType: "JSON",
            type: "GET",
            data: {
                Tipo: 0,
                inicio: $("#consolidado-inicio").val(),
                final: $("#consolidado-final").val(),
            },
            beforeSend: function () {
                html = "<tr><td colspan = '7' class = 'text-center'><h2> Cargando.... </h2></td></tr>";
                $("#table-result-consolidado").html(html);
            }

        }).done(function (response) {

            html = "";

            $.each(response, function (index, value) {

                html += "<tr>";
                html += "<td><p><a href='#' class='indigo Btn-VerDepartamento' data-index='" + value.Codigo + "'>" + value.Descripcion + "</a></p></td>";
                html += "<td>" + value.Total + "</td>";
                html += "<td>" + value.Delitos + "</td>";
                html += "<td>" + value.Faltas + "</td>";
                html += "<td>" + value.Hombres + "</td>";
                html += "<td>" + value.Mujeres + "</td>";                              
                html += "</tr>";

            });

           
            $("#table-result-consolidado").html(html);
           
        });

    },

    ToListMunicipio_Consolidado: function (codigo) {

        $.ajax({
            url: baseUrl + "/Estadistica/ToList_consolidado",
            dataType: "JSON",
            type: "GET",
            data: {
                Tipo: 1,
                codigo: codigo,
                inicio: $("#consolidado-inicio").val(),
                final: $("#consolidado-final").val(),
            },
            beforeSend: function () {
                html = "<tr><td colspan = '7' class = 'text-center'><h2> Cargando.... </h2></td></tr>";
                $("#table-result-consolidado").html(html);
            }

        }).done(function (response) {

            html = "";

            $.each(response, function (index, value) {

                html += "<tr>";
                html += "<td>" + value.Descripcion + "</td>";
                html += "<td>" + value.Total + "</td>";
                html += "<td>" + value.Delitos + "</td>";
                html += "<td>" + value.Faltas + "</td>";
                html += "<td>" + value.Hombres + "</td>";
                html += "<td>" + value.Mujeres + "</td>";
                html += "</tr>";

            });


            $("#table-result-consolidado").html(html);

        });

    },

}



/*INDICADORES DE CONTROL DE DETENIDO*/
/*PRINCIPAL*/
function CargarTotales(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_Detenido",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        $("#total-saldo").text(response.Total_Saldo);
        $("#total-egresos").text(response.Total_Egresos);
        $("#total-nacional").text(response.Total_Gnral);
        $("#total-detenido").text(response.Total_Detenidos);
        $("#total-hombrAdult").text(response.Total_HombreAdult);
        $("#total-mujeresAdult").text(response.Total_MujerAdult);
        $("#total-hombrAdolesc").text(response.Total_HombreAdolesc);
        $("#total-mujeresAdolesc").text(response.Total_MujerAdolesc);
        $("#total-extranjero").text(response.Total_Extranjero);
        $("#total-adultoMayor").text(response.Total_AdultoMayor);
        $("#total-detenidoMes").text(response.Total_DetenidoMes);

    });
}

function CargarEgresoIngreso(tipo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_IngresoEgreso",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,            
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {
       
        _data = [];
        Saldo = [];
        Ingresos = [];
        Egresos = [];
        Celda = [];
        html = "";
        totalCeldaSaldo = "";
        CodEstructura = $("#CodEstructura").val();

        $.each(response, function (index, value) {
            totalCeldaSaldo = value.Saldo + value.Celda;

            _data.push({

                type: "column",
                showInLegend: true,
                name: "",
                indexLabel: "{y}",
                dataPoints: [
                    {
                        y: value.Saldo,
                        label: "SALDO ANTERIOR",
                        click: function (event) {
                            if (tipo == 0) {
                                CargarSaldoDpto(tipo, "");
                            }
                            else if (tipo == 1)
                            {
                                CargarSaldoDpto(tipo, "");
                            }
                            else{
                                CargarSaldoEspDeleg(tipo, CodEstructura);
                            }
                        }

                    },
                    {
                        y: value.Ingreso,
                        label: "INGRESOS",
                        click: function (event) {
                            if (tipo == 0) {
                                CargarDelitosIngresos(tipo, "");
                            }
                            else if (tipo == 1) {
                                CargarDelitosIngresos(tipo, "");
                            }
                            else {
                                CargarDelitosIngresos(tipo, CodEstructura);
                            }
                            
                        }

                    },
                    {
                        y: value.Egreso,
                        label: "EGRESOS",
                        click: function (event) {
                            if (tipo == 0) {
                                CargarEgresosMovimiento(tipo, "");
                            }
                            else if (tipo == 1) {
                                CargarEgresosMovimiento(tipo, "");
                            }
                            else{
                                CargarEgresosMovimiento(tipo, CodEstructura);
                            }
                        }

                    },
                    {
                        y: value.Celda,
                        label: "EN CELDA",
                        click: function (event) {
                            CargarCeldaSaldo(tipo);
                            
                        }

                    },

                ]

            });

         
            var chart = new CanvasJS.Chart("chartContainerIngresoEgreso", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: "",
                },
                axisY: {
                    includeZero: true
                },

                subtitles: [{
                   
                    fontColor: "green",
                    fontSize: 20,
                }],

                legend: {
                    cursor: "pointer",
                   
                },
                toolTip: {
                    shared: true,
                   
                },
                data: _data
               
            });

            chart.render();

        });


    });
}

function CargarDpto(tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_Delegaciones",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {

                    if (tipo == 0) {
                        Cargar_Deleg(1, value.Codigo);
                    }
                    else if (tipo == 1) {
                        Cargar_Deleg(1, value.Codigo);
                    }
                    else {
                        Cargar_EspeDeleg(2, value.Codigo);
                    }
                }
            });

            var chart = new CanvasJS.Chart("chartContainerDelegacion", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",                   
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });            
            chart.render();

        });

    });

}

function CargarRangoHoraDia(tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_RangoHoraDia",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        HoraDia = [];
        html = "";
        CodEstructura = $("#CodEstructura").val();

        $.each(response, function (index, value) {

            HoraDia.push({
                label: value.Clasificacion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Clasificacion,
                click: function (event) {
                    if (tipo == 0) {
                        Cargar_RangoDiaDpto(value.Clasificacion, tipo, "");
                    }
                    else if (tipo == 1) {
                        Cargar_RangoDiaDpto(value.Clasificacion, tipo, "");
                    }
                    else {
                        Cargar_RangoDiaEspDeleg(value.Clasificacion, 2, CodEstructura);
                    }
                }
            });

            var chart = new CanvasJS.Chart("chartContainerRangoHoraDia", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "column",                    
                    toolTipContent: "{label}<br/><img src=\" " + sessionStorage.base_url + "img/\"{url}\"\" style=\"width:40px; height:20px;\"> <b>{name}</b> {y}",
                    indexLabel: "{y}",
                    name: "Total",
                    dataPoints: HoraDia,
                }]

            });
            chart.render();

        });

    });

}

function CargarExtranjAdulto(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_ExtranjAdulto",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        _data = [];
        Extranjero = [];
        Adulto = [];
        html = "";
        
        CodEstructura = $("#CodEstructura").val();

        $.each(response, function (index, value) {
            
            _data.push({

                type: "column",
                showInLegend: true,
                name: "",
                indexLabel: "{y}",
                dataPoints: [
                    { 
                        y: value.Extranjero,
                        label: "EXTRANJERO",
                        click: function (event) {
                            if (tipo == 0) {
                                Cargar_ExtranjeroDpto(tipo, "");
                            }
                            else if (tipo == 1) {
                                Cargar_ExtranjeroDpto(tipo, "");
                            }
                            else {
                                Cargar_ExtranjeroDpto(tipo, CodEstructura);
                            }
                        }

                    },
                    {
                        y: value.Adulto,
                        label: "ADULTO MAYOR",
                        click: function (event) {
                            if (tipo == 0) {
                                Cargar_AdultoMayorDepto(tipo, "");
                            }
                            else if (tipo == 1) {
                                Cargar_AdultoMayorDepto(tipo, "");
                            }
                            else {
                                Cargar_AdultoMayorDepto(tipo, CodEstructura);
                            }
                        }                      
                    }, 

                    {
                        y: value.PrisionPreventiva,
                        label: "PRISIÓN PREVENTIVA",
                        click: function (event) {
                            if (tipo == 0) {
                                Cargar_PrisionPreventivaDepto(tipo, ""); //Llamar la fx js
                            }
                            else if (tipo == 1) {
                                Cargar_PrisionPreventivaDepto(tipo, "");
                            }
                            else {
                                Cargar_PrisionPreventivaDepto(tipo, CodEstructura);
                            }
                        }  

                    },
                                       
                ]

            });


            var chart = new CanvasJS.Chart("chartContainerExtranjAdulto", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: "",
                },
                axisY: {
                    includeZero: true
                },

                subtitles: [{

                    fontColor: "green",
                    fontSize: 20,
                }],

                legend: {
                    cursor: "pointer",

                },
                toolTip: {
                    shared: true,

                },
                data: _data

            });

            chart.render();

        });

    });
}


//CLICK
//ESTADO DETENIDO (saldo, ingresos , egresos, celda)

//saldo
function CargarSaldoDpto(tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_SaldoTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            
            Tipo: tipo,
            codigo: codigo
            
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {

                    if (tipo == 0) {
                        CargarSaldoDeleg(1, value.Codigo);
                    }
                    else if (tipo == 2) {

                        CargarSaldoDeleg(2, value.Codigo);
                    }
                    else {
                        CargarSaldoDeleg(1, value.Codigo);
                    }
                    
                }
            });

            var chart = new CanvasJS.Chart("chartContainerSaldoDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-SaldoDeleg").modal();
            chart.render();

        });

    });
}

function CargarSaldoDeleg(tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_SaldoTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {

            Tipo: tipo,
            codigo: codigo

        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    CargarSaldoEspDeleg(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerSaldoDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-SaldoDeleg").modal();
            chart.render();

        });

    });
}

function CargarSaldoEspDeleg(tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_SaldoTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {

            Tipo: tipo,
            codigo: codigo

        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    Cargar_SaldoDetalle(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerSaldoDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-SaldoDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_SaldoDetalle(tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_DetalleSaldo",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,            
        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);
        html = "";

        $.each(response, function (index, value) {

            html += "<li class='list-group-item'>";
            html += "<h3><a href='#' data-toggle='collapse' class='indigo btn-ver' data-index='" + value.Idno + "' >" + value.Nombre + "</a></h3>";
            html += "<h4>" + value.Identificacion + "</h4>";
            html += "<h5>" + value.Delito + "</h5>";
            html += "<h5>" + json2Date(value.Fecha) + "</h5>";
            html += "</li>";

        });

        $("#detalle-saldo").html(html);
        $("#modal-detalle-saldo").modal();

    });

}



//ingresos
function CargarDelitosIngresos(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_DelitosIngresos",
        dataType: "JSON",
        type: "GET",
        data: {
            tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delito = [];
        html = "";
        codigo = "";

        $.each(response, function (index, value) {


            delito.push({
                label: value.Clasificacion, y: value.TOTAL, url: 'caution.png', indexLabel: "\u2605" + value.TOTAL, value: value.Codigo,
                click: function (event) {

                    if (tipo == 0) {
                        CargarIngresosDpto(value.Codigo, tipo, "");
                    }
                    else if (tipo == 1) {
                        CargarIngresosDpto(value.Codigo, tipo, "");
                    }
                    else {
                        CargarIngresosDpto(value.Codigo, tipo, "");
                    }
                    
                }
            });

            var chart = new CanvasJS.Chart("chartContainerDetalleIngresos", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: "",
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "column",
                    toolTipContent: "{label}<br/><img src=\" " + sessionStorage.base_url + "img/\"{url}\"\" style=\"width:40px; height:20px;\"> <b>{name}</b> {y}",
                    indexLabel: "{y}",
                    name: "Total",
                    dataPoints: delito,
                }]

            });
            $("#modal-grafico-detalleIngresos").modal();
            chart.render();

        });


    });
}

function CargarIngresosDpto(clasificacion, tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_IngresosDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Clasificacion: clasificacion,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    if (tipo == 0) {
                        CargarIngresosDeleg(clasificacion, 1, value.Codigo);
                    }
                    else if (tipo == 1) {
                        CargarIngresosEspDeleg(clasificacion, 2, value.Codigo);
                    }
                    else if (tipo == 2) {
                        CargarIngresosEspDeleg(clasificacion, 2, value.Codigo);
                    }
                    
                }
            });

            var chart = new CanvasJS.Chart("chartContainerIngresosDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",                   
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-IngresosDeleg").modal();
            chart.render();

        });

    });
}

function CargarIngresosDeleg(clasificacion, tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_IngresosTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Clasificacion: clasificacion,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {

                    CargarIngresosEspDeleg(clasificacion, 2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerIngresosDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-IngresosDeleg").modal();
            chart.render();

        });

    });
}

function CargarIngresosEspDeleg(clasificacion, tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_IngresosTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Clasificacion: clasificacion,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    Cargar_IngresosDetalle(2, value.Codigo,clasificacion);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerIngresosDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-IngresosDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_IngresosDetalle(tipo, codigo, clasificacion) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_DetalleIngreso",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            clasificacion : clasificacion,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);
        html = "";

        $.each(response, function (index, value) {

            html += "<li class='list-group-item'>";
            html += "<h3><a href='#' data-toggle='collapse' class='indigo btn-ver' data-index='" + value.Idno + "' >" + value.Nombre + "</a></h3>";
            html += "<h4>" + value.Identificacion + "</h4>";
            html += "<h5>" + value.Delito + "</h5>";
            html += "<h5>" + json2Date(value.Fecha) + "</h5>";
            html += "</li>";

        });

        $("#detalle-ingresos").html(html);
        $("#modal-detalle-ingresos").modal();

    });

}


//egresos
function CargarEgresosMovimiento(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_EgresosMovimientos",
        dataType: "JSON",
        type: "GET",
        data: {
            tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        _data = [];        
        libertad = [];
        trasladoSPN = [];
        otros = [];

        html = "";
        
        $.each(response, function (index, value) {
          
            _data.push({

                type: "column",
                showInLegend: true,
                name: "",
                indexLabel: "{y}",
                dataPoints: [
                    {
                        y: value.Libertad,
                        label: "ORDEN DE LIBERTAD",
                        click: function (event) {

                            CargarEgresosDpto(tipo,1,tipo,"");
                        }

                    },
                    {
                        y: value.TrasladoSPN,
                        label: "TRASLADO SPN",
                        click: function (event) {
                            CargarEgresosDpto(tipo,2, tipo, "");
                        }

                    },
                    {
                        y: value.Otros,
                        label: "TRASLADO OTRA DELEGACION",
                        click: function (event) {
                            CargarEgresosDpto(tipo,3, tipo, "");
                        }

                    },

                ]

            });


            var chart = new CanvasJS.Chart("chartContainerEgresoMovimiento", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: "",
                },
                axisY: {
                    includeZero: true
                },

                subtitles: [{
                   
                    fontColor: "green",
                    fontSize: 20,
                }],

                legend: {
                    cursor: "pointer",
                   
                },
                toolTip: {
                    shared: true,
                    
                },
                data: _data

            });

            $("#modal-grafico-egresosMovimiento").modal();
            chart.render();

        });


    });
}

function CargarEgresosDpto(perfil, clasificacion, tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_EgresosDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            perfil: perfil,
            Clasificacion: clasificacion,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    if (perfil == 0 || tipo == 0) {
                        CargarEgresosDeleg(perfil, clasificacion, 1, value.Codigo);
                    }
                    else if (perfil == 1 || tipo == 1) {
                        CargarEgresosDeleg(perfil, clasificacion, 1, value.Codigo);
                    }
                    else {
                        CargarEgresosEspDeleg(2, clasificacion, 2, value.Codigo);
                    }
                    
                }
            });

            var chart = new CanvasJS.Chart("chartContainerEgresosDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-EgresosDeleg").modal();
            chart.render();

        });

    });
}

function CargarEgresosDeleg(perfil, clasificacion, tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_EgresosTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            perfil: perfil,
            Clasificacion: clasificacion,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    CargarEgresosEspDeleg(perfil, clasificacion, 2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerEgresosDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-EgresosDeleg").modal();
            chart.render();

        });

    });
}

function CargarEgresosEspDeleg(perfil, clasificacion, tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_EgresosTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            perfil: perfil,
            Clasificacion: clasificacion,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    Cargar_EgresosDetalle(2, value.Codigo, clasificacion);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerEgresosDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-EgresosDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_EgresosDetalle(tipo, codigo, clasificacion) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_DetalleEgreso",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,            
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
            clasificacion: clasificacion,
        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);
        html = "";

        $.each(response, function (index, value) {

            html += "<li class='list-group-item'>";
            html += "<h3><a href='#' data-toggle='collapse' class='indigo btn-ver' data-index='" + value.Idno + "' >" + value.Nombre + "</a></h3>";
            html += "<h4>" + value.Identificacion + "</h4>";
            html += "<h5>" + value.Delito + "</h5>";
            html += "<h5>" + json2Date(value.Fecha) + "</h5>";
            html += "</li>";

        });

        $("#detalle-egresos").html(html);
        $("#modal-detalle-Egresos").modal();

    });

}


//en celda
function CargarCeldaSaldo(tipo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_IngresoEgreso",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);

        _data = [];
        Saldo = [];
        Celda = [];
        html = "";

        $.each(response, function (index, value) {
            totalCeldaSaldo = value.Saldo + value.Celda;

            _data.push({

                type: "column",
                showInLegend: true,
                name: "",
                indexLabel: "{y}",
                dataPoints: [
                    {
                        y: value.Celda,
                        label: "EN CELDA 2023",
                        click: function (event) {
                            CargarDelitos(0, tipo, "");
                        }

                    },
                   
                ]

            });


            var chart = new CanvasJS.Chart("chartContainerCeldaSaldo", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: "",
                },
                axisY: {
                    includeZero: true
                },

                subtitles: [{
                   
                    fontColor: "green",
                    fontSize: 20,
                }],

                legend: {
                    cursor: "pointer",
                    
                },
                toolTip: {
                    shared: true,
                    
                },
                data: _data

            });

            $("#modal-grafico-CeldaSaldo").modal();
            chart.render();


        });


    });
}

function CargarDelitos(perfil, tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_Delito",
        dataType: "JSON",
        type: "GET",
        data: {
            perfil: perfil,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delito = [];
        html = "";
        codigo = "";

        $.each(response, function (index, value) {


            delito.push({
                label: value.Clasificacion, y: value.TOTAL, url: 'caution.png', indexLabel: "\u2605" + value.TOTAL, value: value.Codigo,
                click: function (event) {

                    Cargar_DelitosDpto(perfil,value.Codigo, tipo, "");

                }
            });

            var chart = new CanvasJS.Chart("chartContainerDelitos", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: "",
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "column",
                    toolTipContent: "{label}<br/><img src=\" " + sessionStorage.base_url + "img/\"{url}\"\" style=\"width:40px; height:20px;\"> <b>{name}</b> {y}",
                    indexLabel: "{y}",
                    name: "Total",
                    dataPoints: delito,
                }]

            });
            $("#modal-grafico-delitos").modal();
            chart.render();

        });


    });

}

function Cargar_DelitosDpto(perfil, clasificacion, tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_CeldaDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            perfil: perfil,
            Clasificacion: clasificacion,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    if (tipo == 0 && perfil == 0) {
                        Cargar_DelitoDeleg(1, clasificacion, 1, value.Codigo);
                    }
                    else if (tipo == 1 && perfil == 1) {
                        Cargar_DelitoDeleg(1, clasificacion, 1, value.Codigo);
                    }
                    else {
                        Cargar_DelitoEspDeleg(2, clasificacion, 2, value.Codigo);
                    }
                    
                }
            });

            var chart = new CanvasJS.Chart("chartContainerDelitoDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",                    
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-delitosDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_DelitoDeleg(perfil, clasificacion, tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_CeldaTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            perfil: perfil,
            Clasificacion: clasificacion,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    Cargar_DelitoEspDeleg(perfil, clasificacion, 2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerDelitoDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",                   
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-delitosDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_DelitoEspDeleg(perfil, clasificacion, tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_CeldaTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            perfil: perfil,
            Clasificacion: clasificacion,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegDelito = [];
        html = "";

        $.each(response, function (index, value) {

            delegDelito.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    Cargar_DelitoDetalle(2, value.Codigo, clasificacion);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerDelitoDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",                    
                    name: "Total",
                    dataPoints: delegDelito,
                }]

            });
            $("#modal-grafico-delitosDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_DelitoDetalle(tipo, codigo, clasificacion) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_DetalleCelda",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
            clasificacion: clasificacion,
        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);
        html = "";

        $.each(response, function (index, value) {

            html += "<li class='list-group-item'>";
            html += "<h3><a href='#' data-toggle='collapse' class='indigo btn-ver' data-index='" + value.Idno + "' >" + value.Nombre + "</a></h3>";
            html += "<h4>" + value.Identificacion + "</h4>";
            html += "<h5>" + value.Delito + "</h5>";
            html += "<h5>" + json2Date(value.Fecha) + "</h5>";
            html += "</li>";

        });

        $("#detalle-celda").html(html);
        $("#modal-detalle-Celda").modal();

    });

}



//DELEGACION
function Cargar_Deleg(tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_TodasDelegaciones",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_EspeDeleg(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",                 
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-deleg").modal();
            chart.render();

        });

    });

}

function Cargar_EspeDeleg(tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_TodasDelegaciones",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo,
                click: function (event) {
                    Cargar_DetalleDelegacion(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",                   
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });
            $("#modal-grafico-deleg").modal();
            chart.render();

        });

    });


}

function Cargar_DetalleDelegacion(tipo, codigo) {

    $.ajax({
        url: baseUrl + "/Estadistica/ToList_DetalleDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);
        html = "";

        $.each(response, function (index, value) {
              
            html += "<li class='list-group-item'>";
            html += "<h3><a href='#' data-toggle='collapse' class='indigo btn-ver' data-index='" + value.Idno + "' >" + value.Nombre + "</a></h3>";
            html += "<h4>" + value.Identificacion + "</h4>";
            html += "<h5>" + value.Delito + "</h5>";
            html += "<h5>" + json2Date(value.Fecha) + "</h5>";
            html += "</li>";

        });

        $("#detalle-delegacion").html(html);
        $("#modal-detalle-delegacion").modal();

    });
    
}


//PERMANENCIA EN CELDA POR RANGO DE DIA
function Cargar_RangoDiaDpto(rango, tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_RangoDiaDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            rango: rango,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_RangoDiaDeleg(rango, 1, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerRangoDiaDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",                   
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-rangoDiaDeleg").modal();
            chart.render();

        });

    });

}

function Cargar_RangoDiaDeleg(rango, tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_RangoDiaTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            rango: rango,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_RangoDiaEspDeleg(rango, 2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerRangoDiaDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-rangoDiaDeleg").modal();
            chart.render();

        });

    });

}

function Cargar_RangoDiaEspDeleg(rango, tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_RangoDiaTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            rango: rango,
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_RangoDiaDetalle(2, value.Codigo, rango);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerRangoDiaDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-rangoDiaDeleg").modal();
            chart.render();

        });

    });

}

function Cargar_RangoDiaDetalle(tipo, codigo, rango) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_DetalleRangoDia",
        dataType: "JSON",
        type: "GET",
        data: {            
            Tipo: tipo,
            codigo: codigo,            
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
            rango: rango
        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);
        html = "";

        $.each(response, function (index, value) {

            html += "<li class='list-group-item'>";
            html += "<h3><a href='#' data-toggle='collapse' class='indigo btn-ver' data-index='" + value.Idno + "' >" + value.Nombre + "</a></h3>";
            html += "<h4>" + value.Identificacion + "</h4>";
            html += "<h5>" + value.Delito + "</h5>";
            html += "<h5>" + json2Date(value.Fecha) + "</h5>";
            html += "</li>";

        });

        $("#detalle-rangoDia").html(html);
        $("#modal-detalle-rangoDia").modal();

    });
}


//EXTRANJERO
function Cargar_ExtranjeroDpto(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_ExtranjeroDeleg",
        dataType: "JSON",
        type: "GET",
        data: {           
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    if (tipo == 0) {
                        Cargar_ExtranjeroDeleg(1, value.Codigo);
                    }
                    else if (tipo == 1) {
                        Cargar_ExtranjeroDeleg(1, value.Codigo);
                    }
                    else {
                        Cargar_ExtranjeroEspDeleg(2, value.Codigo);
                    }
                }
            });

            var chart = new CanvasJS.Chart("chartContainerExtranjeroDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-ExtranjeroDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_ExtranjeroDeleg(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_ExtranjeroTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_ExtranjeroEspDeleg(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerExtranjeroDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-ExtranjeroDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_ExtranjeroEspDeleg(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_ExtranjeroTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_ExtranjeroDetalle(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerExtranjeroDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-ExtranjeroDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_ExtranjeroDetalle(tipo, codigo, rango) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_ExtranjeroDetalle",
        dataType: "JSON",
        type: "GET",
        data: {

            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val()
           
        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);
        html = "";

        $.each(response, function (index, value) {

            html += "<li class='list-group-item'>";
            html += "<h3><a href='#' data-toggle='collapse' class='indigo btn-ver' data-index='" + value.Idno + "' >" + value.Nombre + "</a></h3>";
            html += "<h4>" + value.Identificacion + "</h4>";
            html += "<h5>" + value.Delito + "</h5>";
            html += "<h5>" + json2Date(value.Fecha) + "</h5>";
            html += "<h5>" + value.Nacionalidad + "</h5>";
            html += "</li>";

        });

        $("#detalle-Extranjero").html(html);
        $("#modal-detalle-Extranjero").modal();

    });
}




//ADULTOS MAYORES
function Cargar_AdultoMayorDepto(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_AdultosMayorDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    if (tipo == 0) {
                        Cargar_AdultoMayorDeleg(1, value.Codigo);
                    }
                    else if (tipo == 1) {
                        Cargar_AdultoMayorDeleg(1, value.Codigo);
                    }
                    else {
                        Cargar_AdultoMayorEspDeleg(2, value.Codigo);
                    }
                }
            });

            var chart = new CanvasJS.Chart("chartContainerAdultoMayorDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-AdultoMayorDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_AdultoMayorDeleg(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_AdultosMayorTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_AdultoMayorEspDeleg(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerAdultoMayorDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-AdultoMayorDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_AdultoMayorEspDeleg(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_AdultosMayorTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_AdultoMayorDetalle(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerAdultoMayorDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-AdultoMayorDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_AdultoMayorDetalle(tipo, codigo, rango) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_AdultoMayorDetalle",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val()

        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);
        html = "";

        $.each(response, function (index, value) {

            html += "<li class='list-group-item'>";
            html += "<h3><a href='#' data-toggle='collapse' class='indigo btn-ver' data-index='" + value.Idno + "' >" + value.Nombre + "</a></h3>";
            html += "<h4>" + value.Identificacion + "</h4>";
            html += "<h5>" + value.Delito + "</h5>";
            html += "<h5>" + json2Date(value.Fecha) + "</h5>";
            html += "</li>";

        });

        $("#detalle-AdultoMayor").html(html);
        $("#modal-detalle-AdultoMayor").modal();

    });
}



// PRISIÓN PREVENTIVA
function Cargar_PrisionPreventivaDepto(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_PrisionPreventivaDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    if (tipo == 0) {
                        Cargar_PrisionPreventivaDeleg(1, value.Codigo);
                    }
                    else if (tipo == 1) {
                        Cargar_PrisionPreventivaDeleg(1, value.Codigo);
                    }
                    else {
                        Cargar_PrisionPreventivaDeleg(2, value.Codigo);
                    }
                }
            });
            // Id del modal-body
            var chart = new CanvasJS.Chart("chartContainerPrisionDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });
            //Id de la modal
            $("#modal-grafico-PrisionDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_PrisionPreventivaDeleg(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_PrisionPreventivaTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_PrisionPreventivaEspDeleg(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerPrisionDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-PrisionDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_PrisionPreventivaEspDeleg(tipo, codigo) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_PrisionPreventivaTodasDeleg",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val(),
        },
        beforeSend: function () {

        }

    }).done(function (response) {

        delegacion = [];
        html = "";

        $.each(response, function (index, value) {

            delegacion.push({
                label: value.Descripcion, y: value.Total, url: 'caution.png', indexLabel: "\u2605" + value.Total, value: value.Codigo, click: function (event) {
                    Cargar_PrisionPreventivaDetalle(2, value.Codigo);
                }
            });

            var chart = new CanvasJS.Chart("chartContainerPrisionDeleg", {
                animationEnabled: true,
                zoomEnabled: true,
                exportEnabled: true,
                theme: "light1",
                title: {
                    text: ""
                },
                axisY: {
                    includeZero: true
                },
                data: [{
                    type: "bar",
                    indexLabelFontColor: "#5A5757",
                    indexLabelFontSize: 16,
                    indexLabelPlacement: "outside",
                    name: "Total",
                    dataPoints: delegacion,
                }]

            });

            $("#modal-grafico-PrisionDeleg").modal();
            chart.render();

        });

    });
}

function Cargar_PrisionPreventivaDetalle(tipo, codigo, rango) {
    $.ajax({
        url: baseUrl + "/Estadistica/ToList_PrisionPreventivaDetalle",
        dataType: "JSON",
        type: "GET",
        data: {
            Tipo: tipo,
            codigo: codigo,
            inicio: $("#Estd-inicio").val(),
            final: $("#Estd-final").val()

        },
        beforeSend: function () {

        }

    }).done(function (response) {
        console.log(response);
        html = "";

        $.each(response, function (index, value) {

            html += "<li class='list-group-item'>";
            html += "<h3><a href='#' data-toggle='collapse' class='indigo btn-ver' data-index='" + value.Idno + "' >" + value.Nombre + "</a></h3>";
            html += "<h4>" + value.Identificacion + "</h4>";
            html += "<h5>" + value.Delito + "</h5>";
            html += "<h5>" + json2Date(value.Fecha) + "</h5>";
            html += "</li>";

        });

        $("#detalle-prision").html(html);
        $("#modal-detalle-prision").modal();

    });
}


//FICHA O REPORTE DEL DETENIDO
function Cargar_FichaDetenido(Idno) {

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

        // prision preventiva
        html += "<div class='table-responsive'>";
        html += "<table class='table'>";
        html += "<thead class='thead-default'>";
        html += "<tr>";
        html += "<th colspan='7'>Prisión Preventiva</th>";
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

        $.each(response.PrisionPreventiva, function (index12, value12) {
            html += "<tr>";
            html += "<td>" + json2Date(value12.FechaRegistro) + "</td>";
            html += "<td>" + value12.NoAsunto + "</td>";
            html += "<td>" + value12.Juzgado + "</td>";
            html += "<td>" + value12.Ubicacion + "</td>";
            html += "<td>" + value12.Procesos + "</td>";
            html += "<td>" + value12.MotivoJuzgado + "</td>";
            html += "</tr>";
        });

        html += "</table>";
        html += "</div>"; //fin de prision preventiva

        html += "</div>"; //fin tab3

        html += "</div>"; //fin tab
        html += "</div>"; //fin body


       $("#data-preview").html(html);
       $("#modal-data-preview").modal();
    });
}















