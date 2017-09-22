using HBSIS.Domain.Entities;
using HBSIS.Domain.Interfaces.Repositories;
using HBSIS.Domain.Interfaces.Services;

namespace HBSIS.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository):base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}
