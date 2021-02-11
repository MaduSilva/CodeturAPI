using Codetur.Comum.Handlers;
using Codetur.Comum.Queries;
using Codetur.Dominio.Queries.Pacotes;
using Codetur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Codetur.Dominio.Queries.Pacotes.ListarPacotesQuery;

namespace Codetur.Dominio.Handlers.Pacotes
{
    public class ListarPacoteQueryHandle : IHandlerQuery<ListarPacotesQuery>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;
        public ListarPacoteQueryHandle(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }

        public IQueryResult Handle(ListarPacotesQuery query)
        {
            var pacotes = _pacoteRepositorio.Listar(query.Ativo);

            var retornoPacotes = pacotes.Select(
                p =>
                {
                    return new ListarPacotesQueryResult
                    {
                        Id = p.Id,
                        Titulo = p.Titulo,
                        Descricao = p.Descricao,
                        Ativo = p.Ativo,
                        QuantidadeComentarios = p.Comentarios.Count(),
                        DataCriacao = p.DataCriacao
                    };
                }
             );

            return new GenericQueryResult(true, "Lista de Pacotes", retornoPacotes);
        }
    }
}
