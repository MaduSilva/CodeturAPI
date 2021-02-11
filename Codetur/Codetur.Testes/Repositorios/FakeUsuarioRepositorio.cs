using Codetur.Dominio.Entidades;
using Codetur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codetur.Testes.Repositorios
{
    class FakeUsuarioRepositorio : IUsuarioRepositorio
    {

        List<Usuario> _usuarios = new List<Usuario>()
           {

            new Usuario("Maria Eduarda", "email2@email.com", "1234567", Comum.Enum.EnTipoUsuario.Comum),
            new Usuario("Lucia Silva", "email3@email.com", "1234567", Comum.Enum.EnTipoUsuario.Comum)
        };
        public void Adicionar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public void Alterar(Usuario usuario)
        {

        }

        public void AlterarSenha(Usuario usuario)
        {

        }

        public Usuario BuscarPorEmail(string email)
        {
            return _usuarios.FirstOrDefault(x => x.Email == email);

        }

        public Usuario BuscarPorId(Guid id)
        {
            return _usuarios.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Usuario> Listar()
        {
            return _usuarios;

        }
    }
}

