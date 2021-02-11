using Codetur.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Codetur.Dominio.Repositorios
{

    //Abstração
    public interface IUsuarioRepositorio
    {
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);

        ICollection<Usuario> Listar();


    }
}
