using Codetur.Comum.Commands;
using Codetur.Comum.Handlers;
using Codetur.Dominio.Commands.Pacote;
using Codetur.Dominio.Repositorios;
using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codetur.Dominio.Handlers.Pacotes
{
    public class CriarPacoteCommandHandler : IHandlerCommand<CriarPacoteCommand>
    {

        private readonly IPacoteRepositorio _pacoteRepositorio;

        public CriarPacoteCommandHandler(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }

        public ICommandResult Handle(CriarPacoteCommand command)
        {
            //Valida Command 
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se existe um pacote com o mesmo titulo

            var pacoteexiste = _pacoteRepositorio.BuscarPorTitulo(command.Titulo);

            if(pacoteexiste != null)
                return new GenericCommandResult(false, "Título do pacote já cadastrado", null);

            //Gera entidade pacote
            var pacote = new Pacote(command.Titulo, command.Descricao, command.Imagem, command.Ativo);

            if (pacote.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos", pacote.Notifications);

            //Adiciona no banco
            _pacoteRepositorio.Adicionar(pacote);

            //retorna mensagem de sucesso
            return new GenericCommandResult(true, "Pacote criado", null);
        }
    }
}
