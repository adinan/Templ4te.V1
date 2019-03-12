using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Templ4te.V1.Domain.Notifications;
using Templ4te.V1.Domain.Usuarios;
using Templ4te.V1.Domain.Usuarios.Interfaces;

namespace Templ4te.V1.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly string sender = typeof(UsuarioController).Name;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService, IDomainNotificationList notification)            
            :base(notification)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Notifications.Add("erro da controller usuario", sender);

            var endereco = new Endereco("", "", "", "", "", "", "");

            var usuario = new Usuario("Jonh Doe", "026.103.931-80");
            //usuario.AtribuirEndereco(endereco);

            _usuarioService.Adicionar(usuario);

            return _usuarioRepository.ObterTodos().Select(p => p.Nome);
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

            var usuario = new Usuario("Jonh Doe", "026.103.931-80");
            _usuarioService.Adicionar(usuario);
            //return Response(eventoCommand);
            return Response(value);
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
