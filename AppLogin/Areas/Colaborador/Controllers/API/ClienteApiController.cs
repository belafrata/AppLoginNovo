using AppLogin.Models;
using AppLogin.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppLogin.Areas.Colaborador.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteApiController : Controller
    {
        private IClienteRepository _clienteRepository;
        public ClienteApiController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult ListarClientes()
        {
            var clientes = _clienteRepository.ObterTodosClientes();
            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente) //cadastrar
        {
            if (cliente is null)
            {
                return BadRequest(new
                {
                    mensagem = "Os dados do cliente são obrigatórios."
                });
            }
            _clienteRepository.Cadastrar(cliente);

            return Ok(new
            {
                mensagem = "Cadastro realizado com sucesso.",
                cliente = cliente
            });
        }
    }
}
