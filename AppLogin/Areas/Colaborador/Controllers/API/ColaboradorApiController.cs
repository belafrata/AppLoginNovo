using AppLogin.Models;
using AppLogin.Repository;
using AppLogin.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppLogin.Areas.Colaborador.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorApiController : Controller
    {
        private IColaboradorRepository _colaboradorRepository;
        public ColaboradorApiController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public IActionResult ListarColaboradores()
        {
            var colaboradores = _colaboradorRepository.ObterTodosColaboradores();
            return Ok(colaboradores);
        }

        [HttpPost]
        public IActionResult Post(Colaborador colaborador) //cadastrar
        {
            if (colaborador is null)
            {
                return BadRequest(new
                {
                    mensagem = "Os dados do colaborador são obrigatórios."
                });
            }
            _colaboradorRepository.Cadastrar(colaborador);

            return Ok(new
            {
                mensagem = "Cadastro realizado com sucesso.",
                colaborador = colaborador
            });
        }
    }
}
