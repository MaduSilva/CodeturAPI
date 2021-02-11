using Codetur.Comum.Commands;
using Codetur.Comum.Handlers;
using Codetur.Comum.Util;
using Codetur.Dominio.Commands.Usuario;
using Codetur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codetur.Testes.Handlers.Usuario
{
    public class LogarCommandHandle : IHandlerCommand<LogarCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LogarCommandHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handle(LogarCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos", command.Notifications);

            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if (usuario == null)
                return new GenericCommandResult(false, "Senha ou Email Inválido", null);

            if(!Senha.Validar(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha ou Email Inválido", null);

            return new GenericCommandResult(true, "Usuário Logado", usuario);
        }

    }
}
