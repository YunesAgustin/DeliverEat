var app = angular.module("app", ['ngRoute']);

// configura la app
app.config(function ($routeProvider) {

    // ref angular ruteo; configuracion del ruteo del cliente
    $routeProvider.
        when('/AgregarProducto',
        {
            templateUrl: '/_AgregarProducto.html'
        }).
        when('/Pago',
        {
            templateUrl: '/_Pago.html'
        }).
        when('/PedidoRealizado',
        {
            templateUrl: '/_PedidoRealizado.html'
        }).
        otherwise(
        {
            redirectTo: '/AgregarProducto'  //si no se encuentra la ruta en los when anteriores lo redirige a /inicio
        });
});

app.service('myService', function ($timeout) {
    //sin utilizar
    this.Alert = function (dialogText, dialogTitle) {
        var alertModal = $('<div id="myModal" class="modal fade" tabindex="-1" role="dialog"><div class="modal-dialog"><div class="modal-content" style="width: 80%;"><div class="modal-header"><h3>' + (dialogTitle || 'Atención') + '</h3><button type="button" class="close alerta" data-dismiss="modal" style="height:auto; width:auto">×</button></div><div class="modal-body"><p>' + dialogText + '</p></div><div class="modal-footer"><button class="btn alerta" data-dismiss="modal">Cerrar</button></div></div></div></div>');
        $timeout(function () { alertModal.modal(); });
    };
})

app.controller("appController", function ($scope, $http, myService, fileReader) {
    $scope.inicializar = function () {
        //producto
        $scope.detallePedido = {
        };

        //pago
        $scope.pago = {
        };

        //pedido
        $scope.pedido = {
            detallePedido: $scope.detallePedido,
            pago: $scope.pago,
            idCliente: 1
        };
    }

    $scope.redirect = function (pagina) {
        window.location.href = '#/' + pagina;
    }

    //inicializacion
    $scope.inicializar();
    //redireccion para que no se pueda arrancar desde la pagina del pago sin haber cargado el producto antes
    $scope.redirect('AgregarProducto');

    //REGISTRAR PEDIDO
    $scope.registrarPedido = function () {
        $http.post('/api/Pedidos/', $scope.pedido).then(function (response) {
            $scope.redirect('PedidoRealizado');
            $scope.inicializar();
            return;
        });
        //myService.Alert("Por favor, comproba que hayas ingresado bien los datos de la tarjeta.", "Algo salio mal...");
    }


    //MONTOS
    $scope.calcularMontos = function () {
        $scope.pago.total = parseInt($scope.detallePedido.monto) + 30;
        if ($scope.pago.total > parseInt($scope.pago.pagoCon)) {
            return false;
        }
        $scope.pago.vuelto = parseInt($scope.pago.pagoCon) - parseInt($scope.pago.total);
        return true;
    }
    //FIN MONTOS

    //FECHAS
    $scope.formatoFecha = function (campo) {
        var RegExPattern = /^\d{1,2}\/\d{1,2}\/\d{2,4}$/;
        if ((campo.match(RegExPattern)) && (campo != '')) {
            return true;
        } else {
            return false;
        }
    }

    $scope.existeFecha = function (fecha) {
        var fechaf = fecha.split("/");
        var d = fechaf[0];
        var m = fechaf[1];
        var y = fechaf[2];
        return m > 0 && m < 13 && y > 0 && y < 99999 && d > 0 && d <= (new Date(y, m, 0)).getDate();
    }

    $scope.fechaMayorActual = function (date) {
        var x = new Date();
        var fecha = date.split("/");
        x.setFullYear(fecha[2], fecha[1] - 1, fecha[0]);
        var today = new Date();

        if (x >= today)
            return true;
        else
            return false;
    }

    $scope.validarFecha = function (fecha) {
        if (fecha == undefined) {
            return true;
        } else {
            if ($scope.formatoFecha(fecha)) {
                if ($scope.existeFecha(fecha)) {
                    if ($scope.fechaMayorActual(fecha)) {
                        return true;
                    }
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
    }

    $scope.estaVigente = function (fecha) {
        if (fecha != undefined) {
            var fechaf = fecha.split("/");
            var m = fechaf[0];
            var y = "20" + fechaf[1];
            var date = new Date();
            var mm = date.getMonth() + 1;
            var yy = date.getFullYear();
            return (m >= mm && m < 13 && y == yy) || (m > 0 && m < 13 && y > yy);
        }
        return true;
    }

    $scope.esHoy = function (date) {
        if ($scope.validarFecha(date)) {
            var fecha = date.split("/");
            var d = fecha[0];
            var m = fecha[1];
            var y = fecha[2];
            var hoy = new Date();
            return d == hoy.getDate() && (m == hoy.getMonth() + 1) && y == hoy.getFullYear();
        }
        return false;
    }

    $scope.validarHora = function (hora) {
        if (hora != undefined) {
            var horaf = hora.split(":");
            var h = horaf[0];
            var m = horaf[1];
            if ($scope.esHoy($scope.pedido.fechaEntrega)) {
                var date = new Date();
                var hh = date.getHours();
                var mm = date.getMinutes();
                return ((h == hh && m > mm && mm <= 59) || (h > hh && h < 24 && m <= 59));
            } else {
                return h < 24 && m <= 59;
            }
        }
        return true;
    }

    $scope.fechasValidas = function () {
        //vencimiento tarjeta
        if ($scope.idTipoPago == 2) {
            if (!$scope.estaVigente($scope.pago.fechaVencimiento)) {
                return false;
            }
        }
        //fecha entrega
        if ($scope.loAntesPosible) {
            return true;
        } else {
            if ($scope.validarFecha($scope.pedido.fechaEntrega)) {
                if ($scope.pedido.horaEntrega != undefined) {
                    if ($scope.validarHora($scope.pedido.horaEntrega)) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return true;
                }
            } else {
                return false;
            }
        }
    }
    //FIN FECHAS

    $scope.validaciones = function () {
        return $scope.fechasValidas() && $scope.calcularMontos();
    }

    //IMAGEN
    $scope.imageSrc = "";

    $scope.$on("fileProgress", function (e, progress) {
        $scope.progress = progress.loaded / progress.total;
    });
    //FIN IMAGEN
});

app.directive("ngFileSelect", function (fileReader, $timeout) {
    return {
        scope: {
            ngModel: '='
        },
        link: function ($scope, el) {
            function getFile(file) {
                fileReader.readAsDataUrl(file, $scope)
                  .then(function (result) {
                      $timeout(function () {
                          $scope.ngModel = result;
                      });
                  });
            }

            el.bind("change", function (e) {
                var file = (e.srcElement || e.target).files[0];
                getFile(file);
            });
        }
    };
});

app.factory("fileReader", function ($q, $log) {
    var onLoad = function (reader, deferred, scope) {
        return function () {
            scope.$apply(function () {
                deferred.resolve(reader.result);
            });
        };
    };

    var onError = function (reader, deferred, scope) {
        return function () {
            scope.$apply(function () {
                deferred.reject(reader.result);
            });
        };
    };

    var onProgress = function (reader, scope) {
        return function (event) {
            scope.$broadcast("fileProgress", {
                total: event.total,
                loaded: event.loaded
            });
        };
    };

    var getReader = function (deferred, scope) {
        var reader = new FileReader();
        reader.onload = onLoad(reader, deferred, scope);
        reader.onerror = onError(reader, deferred, scope);
        reader.onprogress = onProgress(reader, scope);
        return reader;
    };

    var readAsDataURL = function (file, scope) {
        var deferred = $q.defer();

        var reader = getReader(deferred, scope);
        reader.readAsDataURL(file);

        return deferred.promise;
    };

    return {
        readAsDataUrl: readAsDataURL
    };
});