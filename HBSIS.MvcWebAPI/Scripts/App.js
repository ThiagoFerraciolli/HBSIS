var ViewModel = function () {
    var self = this;
    self.GetClientes = ko.observableArray();
    self.error = {
        Nome: ko.observable(),
        CpfCnpj: ko.observable(),
        Telefone: ko.observable()
    }
    self.GetUpdate = ko.observable();
    self.newCliente = {
        Nome: ko.observable(),
        CpfCnpj: ko.observable(),
        Telefone: ko.observable()
    }
    self.btnIncuir = ko.observable();

    var ClienteUri = "/api/Clientes/";

    function AjaxDefault(uri, method, data) {
        self.error.Nome('');
        self.error.CpfCnpj('');
        self.error.Telefone('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error.Nome(jqXHR.responseJSON.ModelState["cliente.Nome"]);
            self.error.CpfCnpj(jqXHR.responseJSON.ModelState["cliente.CpfCnpj"]);
            self.error.Telefone(jqXHR.responseJSON.ModelState["cliente.Telefone"]);
        });
    }

    self.IncuirCliente = function () {
        self.btnIncuir(true);
    }

    function GetClientes() {
        AjaxDefault(ClienteUri, 'GET').done(function (data) {
            self.GetClientes(data);
        });
    }

    self.GetUpdateCliente = function (item) {
        AjaxDefault(ClienteUri + item.ID, 'GET').done(function (data) {
            self.GetUpdate(data);
        });
    }

    self.deleteCliente = function (item) {
        AjaxDefault(ClienteUri + item.ID, 'DELETE').done(function (data) {
            self.GetClientes.remove(item);
        });
    }

    self.updateCiente = function (formElement) {
        var cliente = {
            Nome: self.GetUpdate().Nome,
            CpfCnpj: self.GetUpdate().CpfCnpj,
            Telefone: self.GetUpdate().Telefone,
            ID: self.GetUpdate().ID
        };
        AjaxDefault(ClienteUri + cliente.ID, 'PUT', cliente).done(function () {
            GetClientes();
            self.GetUpdate('');
        });
    }

    self.addCliente = function (formElement) {
        var cliente = {
            Nome: self.newCliente.Nome(),
            CpfCnpj: self.newCliente.CpfCnpj(),
            Telefone: self.newCliente.Telefone()
        };

        AjaxDefault(ClienteUri, 'POST', cliente).done(function (item) {
            self.GetClientes.push(item);
            self.newCliente.Nome('');
            self.newCliente.CpfCnpj('');
            self.newCliente.Telefone('');
            self.btnIncuir(false);
        });
    }

    self.Cancelar = function () {
        self.btnIncuir(false);
        self.error.Nome('');
        self.error.CpfCnpj('');
        self.error.Telefone('');
    }
    GetClientes();
};

ko.applyBindings(new ViewModel());