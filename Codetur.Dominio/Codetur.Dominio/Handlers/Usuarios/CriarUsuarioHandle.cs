

using Codetur.Comum.Commands;
using Codetur.Comum.Handlers;
using Codetur.Comum.Util;
using Codetur.Dominio.Entidades;
using Codetur.Dominio.Repositorios;
using CodeTur.Dominio.Commands.Usuario;
using Flunt.Notifications;

namespace Codetur.Dominio.Handlers.Usuarios
{

    //Manipulando o usuário
    //Handlers é essencial para manutenção do código
    //Verificações
    public class CriarUsuarioHandle : Notifiable, IHandlerCommand<CriarUsuarioCommand>
    {
        //Trabalhando com abstrações
        private readonly IUsuarioRepositorio _usuariorepositorio;

        //Injeção de Dependência
        public CriarUsuarioHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuariorepositorio = usuarioRepositorio;
        }

        public ICommandResult Handle(CriarUsuarioCommand command)
        {
            //Cria a instancia do usuario passando os parametros
            //Verifica se os dados são válidos e se sim, envia um email de boas vindas

            //Validar command ----------------------------
            command.Validar();

            //GenericCommandResult - Padronizar as respostas
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do usuário inválidos", command.Notifications);

            //Verifica email existe ----------------------------
            //Regra de negócio
            var usuarioExiste = _usuariorepositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);

            //Criptografar senha ---------------------------
            command.Senha = Senha.Criptografar(command.Senha);

            // Salvar Usuario --------------------------
            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);

            //Verifica se passou telefone ou não
            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AdicionarTelefone(command.Telefone);

            if (usuario.Invalid)
                return new GenericCommandResult(false, "Dados do usuário inválidos", command.Notifications);

            _usuariorepositorio.Adicionar(usuario);

            //TODO: Enviar Email Boas Vindas -------------------------
            //Desafio SendGrid 

            return new GenericCommandResult(true, "Usuário Criado", null);
        }
    }
}
