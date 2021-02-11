using Codetur.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codetur.Comum.Handlers
{
    public interface IHandlerQuery<T> where T : IQuery
    {

        IQueryResult Handle(T query);

    }
}
