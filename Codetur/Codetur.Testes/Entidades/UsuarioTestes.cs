using Codetur.Comum.Enum;
using Codetur.Dominio.Entidades;
using Xunit;

namespace CodeTur.Testes.Entidades
{
    public class UsuarioTestes
    {
        [Fact]

        //Verifica se ao criar a instancia do usuario sem passar a informação, vai dar invalido ou valido
        public void DeveRetornarErroSeUsuarioInvalido()
        {
            var usuario = new Usuario("", "email@email.com", "", EnTipoUsuario.Admin);
            Assert.True(usuario.Invalid, "Usuário é válido");
        }

        [Fact]
        public void DeveRetornarSucessoSeUsuarioValido()
        {
            var usuario = new Usuario("Maria Eduarda", "email@email.com", "1234564", EnTipoUsuario.Admin);

            Assert.True(usuario.Valid, "Usuário é inválido");
        }

        //Verifica se ao passar o telefone do usuario, vai dar invalido ou valido
        [Fact]
        public void DeveRetornarErroSeTelefoneUsuarioInValido()
        {
            var usuario = new Usuario("Maria Eduarda", "email@email.com", "1234567", EnTipoUsuario.Admin);
            usuario.AdicionarTelefone("1195288");

            Assert.True(usuario.Invalid, "Número do telefone é válido");
        }

        [Fact]
        public void DeveRetornarSucessoSeTelefoneUsuarioValido()
        {
            var usuario = new Usuario("Maria Eduarda", "email@email.com", "1234567", EnTipoUsuario.Admin);
            usuario.AdicionarTelefone("11952880101");

            Assert.True(usuario.Valid, "Número do telefone é inválido");
        }

    }
}
