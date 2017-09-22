using AutoMapper;
using HBSIS.Application;
using HBSIS.Application.Interface;
using HBSIS.Domain.Entities;
using HBSIS.Domain.Interfaces.Repositories;
using HBSIS.Domain.Services;
using HBSIS.Infra.Data.Repositories;
using HBSIS.MvcWebAPI.Controllers;
using HBSIS.MvcWebAPI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace HBSIS.MvcWebAPI.Tests.Controllers
{
    [TestClass]
    public class ClientesControllerTest
    {
        [TestMethod]
        public void GetCliente_ShouldGetAllClientes()
        {
            var _ClienteAppService = new Mock<IClienteAppService>();
            var controller = new ClientesController(_ClienteAppService.Object);
            var result = controller.Get();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<ClienteViewModel>));
        }

        [TestMethod]
        public void GetCliente_ShouldNotFindClient()
        {
            var _ClienteAppService = new Mock<IClienteAppService>();
            var controller = new ClientesController(_ClienteAppService.Object);
            var result = controller.Get(999);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostCliente_ShouldCreateClient()
        {
            var _ClienteAppService = new Mock<IClienteAppService>();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ClienteViewModel, Cliente>();
                cfg.CreateMap<Cliente, ClienteViewModel>();
            });
            var controller = new ClientesController(_ClienteAppService.Object);
            ClienteViewModel _cliente = new ClienteViewModel()
            {
                Nome = "Thiago",
                CpfCnpj = "111.111.111-11",
                Telefone = "(19)99753-7633"
            };
            var result = controller.Post(_cliente) as OkNegotiatedContentResult<ClienteViewModel>;
            Assert.IsNotNull(result);
            Assert.AreEqual(_cliente.Nome, result.Content.Nome);
        }

        [TestMethod]
        public void DeleteReturnsOk()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClienteViewModel, Cliente>();
                cfg.CreateMap<Cliente, ClienteViewModel>();
            });
            var _ClienteAppService = new Mock<IClienteAppService>();
            _ClienteAppService.Setup(x => x.GetById(1)).Returns(new Cliente
            {
                ID=1,
                Nome = "Thiago",
                CpfCnpj = "111.111.111-11",
                Telefone = "(19)99753-7633"
            });
            var controller = new ClientesController(_ClienteAppService.Object);
            
            var result = controller.Delete(1);            
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
