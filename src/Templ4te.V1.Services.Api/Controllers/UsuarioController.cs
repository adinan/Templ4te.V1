using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Templ4te.V1.Domain.Usuarios.Interfaces;

namespace Templ4te.V1.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
            :base(null)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var teste = new Dictionary<string, string>();
            teste.Add("123", "teste de erro");

            return _usuarioRepository.ObterTodos().Select(p => p.Nome);
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            //var eventoCommand = _mapper.Map<RegistrarEventoCommand>(eventoViewModel);

            //_bus.SendCommand(eventoCommand);
            //return Response(eventoCommand);
            return null;
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (!ModelState.IsValid)
            {
                //NotificarErroModelInvalida();
                return Response();
            }

            //_usuarioService.Atualizar(eventoViewModel);
            //return Response(eventoViewModel);
            return null;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioService.Remover(id);
            return Response();
        }
    }
}
