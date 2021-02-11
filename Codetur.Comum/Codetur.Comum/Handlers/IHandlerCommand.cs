using Codetur.Comum.Commands;

namespace Codetur.Comum.Handlers
{


    //Definição de regra - quem herdar o IHandler irá utilizar essa regra
    //Manipulação de comandos, assinatura, contrato

    //Interface IHandler passando o T, onde esse T significa uma classe qualquer que tem como obrigação necessariamente passar o ICommand
    //Ou seja, apenas classes que herdam o ICommand irão herdar o IHandler

    //T é algo genérico
    public interface IHandlerCommand<T> where T : ICommand
    {
        //Regra - passado uma classe que herda o ICommand
        ICommandResult Handle(T command);


    }
}
