using AutoMapper;
using HBSIS.Application.Interface;
using HBSIS.Domain.Entities;
using HBSIS.MvcWebAPI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace HBSIS.MvcWebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteApp;

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        // GET: api/Clientes
        [ResponseType(typeof(IEnumerable<ClienteViewModel>))]
        public IEnumerable<ClienteViewModel> Get()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());
            return clienteViewModel;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult Get(int id)
        {
            var cliente = _clienteApp.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return Ok(clienteViewModel);
        }

        // POST: api/Clientes
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult Post([FromBody]ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Add(clienteDomain);
                cliente.ID = clienteDomain.ID;
                return Ok(cliente);
            }
            return BadRequest(ModelState);
        }
        


        // PUT: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult Put(int id, ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.ID)
            {
                return BadRequest();
            }
            var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
            _clienteApp.Update(clienteDomain);
            return Ok(cliente);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult Delete(int id)
        {
            var cliente = _clienteApp.GetById(id);
            if (cliente == null)
                return NotFound();
            _clienteApp.Remove(cliente);
            return Ok();
        }
    }
}
