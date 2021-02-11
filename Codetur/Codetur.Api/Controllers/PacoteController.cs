using Codetur.Comum.Commands;
using Codetur.Comum.Enum;
using Codetur.Comum.Queries;
using Codetur.Dominio.Commands.Pacote;
using Codetur.Dominio.Handlers.Pacotes;
using Codetur.Dominio.Queries.Pacotes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Codetur.Api.Controllers
{
    [Route("v1/package")]
    [ApiController]
    public class PacoteController : ControllerBase
    {

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public GenericCommandResult Create(CriarPacoteCommand command,
                                [FromServices] CriarPacoteCommandHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command); 
        }

        [HttpGet]
        [Authorize]

        public GenericQueryResult GetAll([FromServices] ListarPacoteQueryHandle handle)
        {
            ListarPacotesQuery query = new ListarPacotesQuery();


            var tipoUsuario = HttpContext
                .User
                .Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Role);

            if (tipoUsuario.Value.ToString() == EnTipoUsuario.Comum.ToString())
                query.Ativo = true;

            return (GenericQueryResult)handle.Handle(query);
        }
    }
}
