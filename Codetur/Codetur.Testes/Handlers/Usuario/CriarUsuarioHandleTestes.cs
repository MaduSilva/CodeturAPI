using Codetur.Comum.Commands;
using Codetur.Comum.Enum;
using Codetur.Dominio.Handlers.Usuarios;
using Codetur.Testes.Repositorios;
using CodeTur.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Codetur.Testes.Handlers.Usuario
{
    public class CriarUsuarioHandleTestes
    {
        [Fact]
        public void DeveRetornarErroSeOsDadosDoHandlerForemInvalidos()
        {
            //criar um command
            var command = new CriarUsuarioCommand("Maria Eduarda", "email@email.com", "", "", EnTipoUsuario.Comum);
            //criar um handle
            var handle = new CriarUsuarioHandle(new FakeUsuarioRepositorio());
            //pega o resultado 
            var resultado = (GenericCommandResult)handle.Handle(command);
            //valida a condição
            Assert.False(resultado.Sucesso, "Usuário é válido");
        }

        [Fact]
        public void DeveRetornarErroSeOsDadosDoHandlerForemValidos()
        {
            //criar um command
            var command = new CriarUsuarioCommand("Maria Eduarda", "email@email.com", "1234567", "", EnTipoUsuario.Comum);
            //criar um handle
            var handle = new CriarUsuarioHandle(new FakeUsuarioRepositorio());
            //pega o resultado 
            var resultado = (GenericCommandResult)handle.Handle(command);
            //valida a condição
            Assert.True(resultado.Sucesso, "Usuário é válido");
        }

    }
}
