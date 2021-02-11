using Codetur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

//Commands são ações que o usuário vai efetuar
//Pra essas ações acontecerem eu necessito de parâmetros de entrada



namespace Codetur.Dominio.Commands.Pacote
{
    public class AlterarPacoteCommand : Notifiable, ICommand
    {

        public Guid Id { get; set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o Título do pacote")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe o Descrição do pacote")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe o Imagem do pacote")
            );
        }
    }

}
