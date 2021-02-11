using Codetur.Comum.Enum;
using CodeTur.Dominio.Commands.Usuario;
using Xunit;

namespace Codetur.Testes.Commands
{
    public class CriarUsuarioCommandTestes
    {
        //Validando os commands
        //Tudo oq eu estiver fazendo no meu domínio eu posso efetuar testes
        //Assim já sei em que parte está errado e posso consertar na hora sem prejudicar o resto do código

        [Fact]
        public void DeveRetornarErroSeDadosInvalidos()
        {
            var command = new CriarUsuarioCommand();

            command.Validar();

            Assert.False(command.Valid, "Usuário é válido");
        }

        [Fact]
        public void DeveRetornarErroSeDadosValidos()
        {
            var command = new CriarUsuarioCommand("Maria Eduarda", "maria@email.com", "123456", "", EnTipoUsuario.Comum);

            command.Validar();

            //Se o meu objeto commmand passar pelas validações
            //Invalid = false - se passar pelas validações e der false significa q ele n tá inválido
            //Se não, Invalid = true 

            Assert.True(command.Valid, "Usuário é inválido");
        }
    }
}
