﻿using Codetur.Comum.Entidades;
using Codetur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace Codetur.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public Usuario(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "O nome deve ter pelo menos 3 caracteres")
                .HasMaxLen(nome, 40, "Nome", "O nome deve ter no máximo 40 caracteres")
                .IsEmail(email, "Email", "Informe um e-mail válido")
                .HasMinLen(senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
                

                );

            if (Valid) { 
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            }
        }

        //private, posso ler mas não posso escrever de fora da minha classe
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public string Telefone { get; private set; } 

        public EnTipoUsuario TipoUsuario { get; private set; }
        public IReadOnlyCollection<Comentario> Comentarios { get; set; }

        public void AdicionarTelefone(string telefone)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNewFormatCellPhone(telefone, "Telefone", "Informe um telefone válido")
            );

            if (Valid)
                Telefone = telefone;
        }

        public void AlterarSenha(string senha)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
                .HasMaxLen(senha, 12, "Senha", "A senha deve ter no máximo 12 caracteres")
            );

            if (Valid)
                Senha = senha;
        }

        public void AlterarUsuario(string nome, string email)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "O nome deve ter pelo menos 3 caracteres")
                .HasMaxLen(nome, 40, "Nome", "O nome deve ter no máximo 40 caracteres")
                .IsEmail(email, "Email", "Informe um e-mail válido")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
            }
        }
    }
}


