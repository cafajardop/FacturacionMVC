var UsuarioController = function ($scope, $rootScope, $location, $http, DataHttpService, growl) {

    //Services Catalogo

    //Trae el tipo de documento
    DataHttpService.GetTipo().then(function (data) {
        debugger;
        $scope.TiposDoc = data.data;
        $scope.RespuestaFactura = false;
        $scope.Table3 = false;
        $scope.tablaFactura = false;
        $scope.TablaNoMayor = false;
    });

    DataHttpService.GetTipo().then(function (data) {
        $scope.TiposDoc1 = data.data;
        debugger;
    });

    DataHttpService.GetTipoProducto().then(function (data) {
        $scope.TiposProd = data.data;
    });

    //para traer el campo de precio directamente verificar en el formulario no olvidar
    $scope.GetValorProducto = function () {
        var ListTipProductos = $scope.TiposProd;
        var index=ListTipProductos.findIndex(ListTipProductos => ListTipProductos.ProductoId == $scope.tipoProducto);
        $scope.valor = ListTipProductos[index].precio_venta;
    }

    DataHttpService.GetTipoProducto().then(function (data) {
        $scope.TiposProd = data.data;
    });

    DataHttpService.GetCategoria().then(function (data) {
        $scope.TiposCategoria = data.data;
    });

    //Carga la data de categoria 
    $scope.CargarComboTipCategoria = function () {

        DataHttpService.GetCategoria().then(function (data) {
            $scope.TiposCategoria = data.data;
        });

        DataHttpService.GetTipoProducto().then(function (data) {
            $scope.TiposProd = data.data;
        });
    };

    //Funciones

    //Insertar categoria
    $scope.InsertarCategoria = function () {
        if ($scope.categoria == "" || $scope.categoria == undefined) {
            growl.warning('Debe Ingresar una categoria', { title: 'Atención!' });
            return false;
        }
        var authobj = {};
        authobj.nombreCategoria = $scope.categoria;
        DataHttpService.InsrtCat(authobj).then(function (resp) {
            growl.success('La Categoria ' + authobj.nombreCategoria + ' se a creado correctamente!!', { title: 'Exito!' })
            setTimeout(function () { $scope.categoria = undefined;}, 2000);
            //$.scope.tipoCategoria = undefined;
        }, function (err) {
            $scope.novalido = err;
            });
    }

    //Insertar Producto
    $scope.InsertarProducto = function () {
        if ($scope.tipoCategoria == "" || $scope.tipoCategoria == undefined) {
            growl.error('Debe escoger una categoria', { title: 'Atención!' });
            return false;
        }

        if ($scope.NombreProducto == "" || $scope.NombreProducto == undefined) {
            growl.error('Debe un producto', { title: 'Atención!' });
            return false;
        }

        if ($scope.DesProducto == "" || $scope.DesProducto == undefined) {
            growl.error('Debe ingresar una descripcion del producto', { title: 'Atención!' });
            return false;
        }

        if ($scope.StokProducto == "" || $scope.StokProducto == undefined) {
            growl.error('Debe ingresar el stock del producto', { title: 'Atención!' });
            return false;
        }

        if ($scope.PrecioCompra == "" || $scope.PrecioCompra == undefined) {
            growl.error('Debe ingresar el Precio Compra del producto', { title: 'Atención!' });
            return false;
        }

        if ($scope.PrecioVenta == "" || $scope.PrecioVenta == undefined) {
            growl.error('Debe ingresar el Precio Venta del producto', { title: 'Atención!' });
            return false;
        }

        var authobj = {};
        authobj.idCategoria = $scope.tipoCategoria;
        authobj.Nombre = $scope.NombreProducto;
        authobj.descripcion = $scope.DesProducto;
        authobj.stok = $scope.StokProducto;
        authobj.precio_compra = $scope.PrecioCompra;
        authobj.precio_venta = $scope.PrecioVenta;

        DataHttpService.InsrtProd(authobj).then(function (resp) {
            debugger;
            if (resp.data[0].idRpt == 2) {
                growl.error('El producto ' + $scope.NombreProducto + ' Ya existe ingrese uno diferente!!', { title: 'Exito!' })
            } else {
            growl.success('El producto ' + $scope.NombreProducto + ' se a creado correctamente!!', { title: 'Exito!' })
            $scope.TraerListaProductos();
            $scope.TraerListaProductosMin();
            setTimeout(function () {
                $scope.tipoCategoria = undefined;
                $scope.NombreProducto = undefined;
                $scope.DesProducto = undefined;
                $scope.StokProducto = undefined;
                $scope.PrecioCompra = undefined;
                $scope.PrecioVenta = undefined;
                $scope.CargarComboTipCategoria();
            }, 2000);
            }  
        });
    }

    //Consultar Usuarios
    $scope.TraerUsuarios = function () {
        if ($scope.tipodocUpd == "" || $scope.tipodocUpd == undefined) {
            growl.error('Debe Seleccionar un tipo de documento', { title: 'Atención!' });
            return false;
        }
        if ($scope.documentoUpd == "" || $scope.documentoUpd == undefined) {
            growl.error('Debe Seleccionar un Numero de Documento', { title: 'Atención!' });
            return false;
        }
        //var authobj = {};
        DataHttpService.TraeMod($scope.tipodocUpd, $scope.documentoUpd).then(function (resp) {
            debugger;
            if (resp.data == null) {
                growl.error('Usuario No existe', { title: 'Atención!' });
                //setTimeout(function () { location.reload(); }, 2000);
                setTimeout(function () { $scope.documentoUpd = undefined; $scope.authobj = undefined; }, 2000);
                $scope.tipodocUpd = undefined;
                return false;
            } else {
                $scope.authobj = resp.data[0];
                $scope.row1 = true;
                $scope.row2 = true;
            }
        });

    }

    //Generar Factura
    $scope.GenerarFactura = function () {

        if ($scope.tipodocUpd == "" || $scope.tipodocUpd == undefined) {
            growl.error('Debe Seleccionar un tipo de documento', { title: 'Atención!' });
            return false;
        }
        if ($scope.documentoFac == "" || $scope.documentoFac == undefined) {
            growl.error('Debe ingresar un numero de documento', { title: 'Atención!' });
            return false;
        }

        if ($scope.Nombres == "" || $scope.Nombres == undefined) {
            growl.error('Debe un nombre valido', { title: 'Atención!' });
            return false;
        }
        if ($scope.Apellidos == "" || $scope.Apellidos == undefined) {
            growl.error('Debe un apellido valido', { title: 'Atención!' });
            return false;
        }

        if ($scope.FchNacimiento == "" || $scope.FchNacimiento == undefined) {
            growl.error('Debe ingresar una fecha de nacimiento valida', { title: 'Atención!' });
            return false;
        }

        if ($scope.direccion == "" || $scope.direccion == undefined) {
            growl.error('Debe ingrear una direccion valida', { title: 'Atención!' });
            return false;
        }
        if ($scope.telefono == "" || $scope.telefono == undefined) {
            growl.error('Debe ingresar un telefono valido', { title: 'Atención!' });
            return false;
        }

        if ($scope.tipoProducto == "" || $scope.tipoProducto == undefined) {
            growl.error('Debe por lo menos escribir una observación', { title: 'Atención!' });
            return false;
        }


        var authobj4 = {};

        authobj4.tipDocumento = $scope.tipodocUpd;
        authobj4.NumDocumento = $scope.documentoFac;
        authobj4.Nombres = $scope.Nombres;
        authobj4.Apellidos = $scope.Apellidos;
        authobj4.fchNacimiento = $scope.FchNacimiento;
        authobj4.Direccion = $scope.direccion;
        authobj4.Telefono = $scope.telefono;
        authobj4.ProductoId = $scope.tipoProducto;
        authobj4.Cantidad = $scope.cantidad;
        authobj4.ValUnitario = $scope.valor;

        DataHttpService.InsrtFac(authobj4).then(function (resp) {
            $scope.ResFactura = resp.data[0].Id
            $scope.RespuestaFactura = true;
            growl.success('Factura ' + resp.data[0].Id + ' creada exitosamente!!', { title: 'Exito!' })
            setTimeout(function () {
                $scope.tipodocUpd = undefined
                $scope.documentoFac = undefined;
                $scope.Nombres = undefined;
                $scope.Apellidos = undefined;
                $scope.FchNacimiento = undefined;
                $scope.direccion = undefined;
                $scope.telefono = undefined;
                $scope.tipoProducto = undefined;
                $scope.cantidad = undefined;
                $scope.valor = undefined;
            }, 2000);
        }, function (err) {
            $scope.novalido = err;
        });
    }

    //Consultar Usuarios
    $scope.TraerUsuariosDel = function () {
        if ($scope.tipodocDel == "" || $scope.tipodocDel == undefined) {
            growl.error('Debe Seleccionar un tipo de documento', { title: 'Atención!' });
            return false;
        }
        if ($scope.documentoDel == "" || $scope.documentoDel == undefined) {
            growl.error('Debe Seleccionar un Numero de Documento', { title: 'Atención!' });
            return false;
        }
        //var authobj = {};
        DataHttpService.TraeMod($scope.tipodocDel, $scope.documentoDel).then(function (resp) {
            debugger;
            if (resp.data == null) {
                growl.error('Usuario No existe', { title: 'Atención!' });
                //setTimeout(function () { location.reload(); }, 2000);
                setTimeout(function () { $scope.documentoUpd = undefined; $scope.authobj = undefined; }, 2000);
                $scope.tipodocUpd = undefined;
                return false;
            } else {
                $scope.authobj = resp.data[0];
                $scope.row3 = true;
                $scope.row4 = true;
            }
        });

    }

    //Consultar Borrar Usuarios
    $scope.BorraUsr = function () {
        if ($scope.tipodocDel == "" || $scope.tipodocDel == undefined) {
            growl.error('Debe seleccionar un tipo de documento', { title: 'Atención!' });
            return false;
        }
        if ($scope.documentoDel == "" || $scope.documentoDel == undefined) {
            growl.error('Debe Seleccionar un Numero de Documento', { title: 'Atención!' });
            return false;
        }

        var authobjDel = {};
        authobjDel.TipDoc = $scope.tipodocDel;
        authobjDel.NumDoc = $scope.documentoDel;

        DataHttpService.DelMod(authobjDel).then(function (resp) {
            growl.success('Usuario Eliminado Correctamente!', { title: 'Exito!' });
            setTimeout(function () { location.reload(); }, 3000);
        }, function (err) {
            $scope.novalido = err;
        });
    }

    //Actualizar Borrar Usuarios
    $scope.ActualizaCategoria = function () {

        if ($scope.tipoCategoria == "" || $scope.tipoCategoria == undefined) {
            growl.error('Debe seleccionar una categoria', { title: 'Atención!' });
            return false;
        }
        if ($scope.NuevaCategoria == "" || $scope.NuevaCategoria == undefined) {
            growl.error('Debe ingresar una nueva Categoria', { title: 'Atención!' });
            return false;
        }

        var authobjModal = {};
        authobjModal.idCategoria = $scope.tipoCategoria;
        authobjModal.nombreCategoria = $scope.NuevaCategoria;

        DataHttpService.ActCategoria(authobjModal).then(function (resp) {
            growl.success('Categoria Actualizada Correctamente!', { title: 'Exito!' });
            setTimeout(function () { location.reload(); }, 2000);
        }, function (err) {
            $scope.novalido = err;
        });
    }

    //Eliminar Categoria 
    $scope.EliminaCategoria = function () {

        if ($scope.tipoCategoria == "" || $scope.tipoCategoria == undefined) {
            growl.error('Debe seleccionar una categoria', { title: 'Atención!' });
            return false;
        }

        var authobjModalDel = {};
        authobjModalDel.idCategoria = $scope.tipoCategoria;

        DataHttpService.DelCategoria(authobjModalDel).then(function (resp) {
            growl.success('Categoria Eliminada Correctamente!', { title: 'Exito!' });
            setTimeout(function () { location.reload(); }, 2000);
        }, function (err) {
            $scope.novalido = err;
        });
    }


    //Consulta Lista de Precios
    $scope.TraerListaProductos = function () {
        DataHttpService.TraeProductos().then(function (resp) {
            if (resp.data == null) {
                growl.warning('Sin existencias', { title: 'Atención!' });
                //setTimeout(function () { location.reload(); }, 2000);
                return false;
            } else {
                $scope.authobj2 = resp.data;
            }
        });
    }

    //Consulta Lista de Precios
    $scope.TraerListaProductosMin = function () {
        DataHttpService.TraeProductosMin().then(function (resp) {
            if (resp.data == null) {
                growl.warning('Sin existencias', { title: 'Atención!' });
                //setTimeout(function () { location.reload(); }, 2000);
                return false;
            } else {
                $scope.authobj3 = resp.data;
            }
        });
    }

    //Lista Clientes no mayores a 35
    $scope.TraerUsuarioNoMayores = function () {
    if ($scope.fchIni == "" || $scope.fchIni == undefined) {
        growl.warning('Debe Ingresar una fecha inicio valida', { title: 'Atención!' });
        return false;
    }

        if ($scope.fchFin == "" || $scope.fchFin == undefined) {
        growl.warning('Debe Ingresar una fecha inicio valida', { title: 'Atención!' });
        return false;
    }

    var authobjmay = {};
    authobjmay.fchInicioVenta = $scope.fchIni;
    authobjmay.fchFinVenta = $scope.fchFin;

    DataHttpService.TraeClientesNoMayores(authobjmay).then(function (resp) {
        if (resp.data == null) {
            growl.warning('No hay usuarios con esa edad que compren', { title: 'Atención!' });
            //setTimeout(function () { location.reload(); }, 2000);
            return false;
        } else {
            $scope.TablaNoMayor = true;
            $scope.authobj4 = resp.data;
        }
    });
}

    //Lista Clientes no mayores a 35
    $scope.ConsultarFactura = function () {
    if ($scope.NoFactura == "" || $scope.NoFactura == undefined) {
        growl.warning('Debe Ingresar un numero de factura', { title: 'Atención!' });
        return false;
    }
    var authobjFac = {};
    authobjFac.NroFacturaId = $scope.NoFactura;

    DataHttpService.TraeFactura(authobjFac).then(function (resp) {
        if (resp.data == null || resp.data == 0 ) {
            growl.error('No existe factura', { title: 'Atención!' });
            //setTimeout(function () { location.reload(); }, 2000);
            return false;
        } else {
            $scope.tablaFactura = true
            $scope.authobj8 = resp.data;
        }
    });
    }

    //Consulta Ventas Totales
    $scope.TraerTotalVentas = function () {
        if ($scope.FchTotalVendidos == "" || $scope.FchTotalVendidos == undefined) {
            growl.error('Debe seleccionar un año', { title: 'Atención!' });
            return false;
        }

        var authobjVentas = {};
        authobjVentas.FchaVenta = $scope.FchTotalVendidos;

        DataHttpService.TraeVentasTotales(authobjVentas).then(function (resp) {
            if (resp.data == null) {
                growl.warning('Usuario no tiene Grupo Familiar', { title: 'Atención!' });
                //setTimeout(function () { location.reload(); }, 2000);
                return false;
            } else {
                $scope.authobj5 = resp.data;
                $scope.Table3 = true;
            }
        });
    }

    $scope.TraerListaUltimaCompra = function () {
        DataHttpService.TraeUltimaCompra().then(function (resp) {
            if (resp.data == null) {
                growl.warning('Sin existencias', { title: 'Atención!' });
                //setTimeout(function () { location.reload(); }, 2000);
                return false;
            } else {
                $scope.authobj6 = resp.data;
            }
        });
    }
}
UsuarioController.$inject = ['$scope', '$rootScope', '$location', '$http', 'DataHttpService', 'growl'];