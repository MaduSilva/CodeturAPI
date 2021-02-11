using Codetur.Dominio.Entidades;
using Codetur.Dominio.Repositorios;
using Codetur.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codetur.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly CodeturContext _context;

        public UsuarioRepositorio(CodeturContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<Usuario> Listar()
        {
            return _context.Usuarios
                  .AsNoTracking()
                  .Include(u => u.Comentarios)
                  .OrderBy(u => u.DataCriacao)
                  .ToList();
        }

    }
}
