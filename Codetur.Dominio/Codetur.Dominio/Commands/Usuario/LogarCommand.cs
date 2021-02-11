using Codetur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;

//Commands são ações que o usuário vai efetuar
//Pra essas ações acontecerem eu necessito de parâmetros de entrada

namespace Codetur.Dominio.Commands.Usuario
{
    public class LogarCommand : Notifiable, ICommand
    {
        //Logar recebe apenas email e senha
        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }

        //Valida se as informações estão válidas
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Informe um e-mail válido")
                .HasMinLen(Senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
                .HasMaxLen(Senha, 12, "Senha", "A senha deve ter no máximo 12 caracteres")
            );
        }
    }
}
