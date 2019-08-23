var DataHttpService = function ($http) {
    /*******************************************/
    /*Conexion Modulos
    /*******************************************/
    //var UrlSite = "WebApiDigital"; 
    var UrlSite = "";

    this.GetTipo = function () {
        var response = $http({//C:\project_angular7\app-angular\src\app\model.ts
            url: UrlSite + "/TipoDocumento/GetTipo",
            method: "GET"
        });
        return response;
    };

    this.GetTipoProducto = function () {
        var response = $http({
            url: UrlSite + "/Productos/GetTipoProducto",
            method: "GET"
        });
        return response;
    };

    this.GetCategoria = function () {
        var response = $http({
            url: UrlSite + "/categoria/GetCategoria",
            method: "GET"
        });
        return response;
    };

    this.InsrtMod = function (idop) {
        var response = $http({
            url: UrlSite + "/Usuarios/IUsr/",
            method: "POST",
            data: idop
        });
        return response;
    };

    this.InsrtCat = function (idop) {
        var response = $http({
            url: UrlSite + "/categoria/ICtg/",
            method: "POST",
            data: idop
        });
        return response;
    };

    //Insertar producto
    this.InsrtProd = function (idop) {
        var response = $http({
            url: UrlSite + "/Productos/InsrtProd/",
            method: "POST",
            data: idop
        });
        return response;
    };

    this.TraeMod = function (tipDoc, numDoc) {
        var response = $http({
            url: UrlSite + "/Usuarios/GUsr/" + tipDoc + "/" + numDoc,
            method: "GET"
        });
        return response;


    };

    this.TraeProductos = function () {
        var response = $http({
            url: UrlSite + "/Lproductos/TraeProductos/",
            method: "GET"
        });
        return response;
    };

    this.TraeUltimaCompra = function () {
        var response = $http({
            url: UrlSite + "/UltimaFchCompra/TraeUltimaCompra/",
            method: "GET"
        });
        return response;
    };

    this.TraeProductosMin = function () {
        var response = $http({
            url: UrlSite + "/Lproductos/TraeProductosMin/",
            method: "GET"
        });
        return response;
    };

    this.DelMod = function (idop) {
        var response = $http({
            url: UrlSite + "/Usuarios/DUsr/",
            method: "POST",
            data: idop
        });
        return response;
    };

    this.ActCategoria = function (idop) {
        var response = $http({
            url: UrlSite + "/categoria/UCategoria/",
            method: "POST",
            data: idop
        });
        return response;
    };
    //Elimina Categoria
    this.DelCategoria = function (idop) {
        var response = $http({
            url: UrlSite + "/categoria/DelCategoria/",
            method: "POST",
            data: idop
        });
        return response;
    };

    this.InsrtFac = function (idop) {
        var response = $http({
            url: UrlSite + "/FacVentas/IFac/",
            method: "POST",
            data: idop
        });
        return response;
    };

    this.TraeClientesNoMayores = function (idop) {
        var response = $http({
            url: UrlSite + "/ClientesNoMayores/BMayores/",
            method: "POST",
            data: idop
        });
        return response;
    };

    this.TraeFactura = function (idop) {
        var response = $http({
            url: UrlSite + "/buscarFactura/TraeFactura/",
            method: "POST",
            data: idop
        });
        return response;
    };

    this.TraeVentasTotales = function (idop) {
        var response = $http({
            url: UrlSite + "/vTotales/VentaTot/",
            method: "POST",
            data: idop
        });
        return response;
    };
}
DataHttpService.$inject = ['$http'];
