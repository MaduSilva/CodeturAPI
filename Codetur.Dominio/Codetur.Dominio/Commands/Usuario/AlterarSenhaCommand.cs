using Codetur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

//Commands são ações que o usuário vai efetuar
//Pra essas ações acontecerem eu necessito de parâmetros de entrada

namespace Codetur.Dominio.Commands.Usuario
{
    class AlterarSenhaCommand : Notifiable, ICommand
    {

        public Guid IdUsuario { get; set; }

        public string Senha { get; private set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe um Id de usuário válido")
                .IsEmail(Senha, "Email", "Informe um e-mail válido")
                );

        }
    }
}
