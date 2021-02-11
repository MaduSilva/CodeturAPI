using Codetur.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codetur.Dominio.Queries.Pacotes
{
    public class ListarPacotesQuery : IQuery
    {

        public bool? Ativo { get; set; }
        public void Validar()
        {
        }

        public class ListarPacotesQueryResult
        {
            public Guid Id { get; set; }
            public string Titulo { get; set; }

            public string Descricao { get; set; }

            public bool Ativo { get; set; }

            public int QuantidadeComentarios { get; set; }

            public DateTime DataCriacao { get; set; }
        }
    }
}
