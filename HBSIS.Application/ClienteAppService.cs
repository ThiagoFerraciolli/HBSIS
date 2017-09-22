using HBSIS.Application.Interface;
using HBSIS.Domain.Entities;
using HBSIS.Domain.Interfaces.Services;

namespace HBSIS.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService):base(clienteService)
        {
            _clienteService = clienteService;
        }
    }
}
