using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Models;
using EstoqueOnline.Infra.Data.Identity;
using Microsoft.EntityFrameworkCore;

namespace EstoqueOnline.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private UsuarioContext _appDbContext;

        public UsuarioRepository(UsuarioContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Usuario> FindUsuarioByLogin(string login)
        {
            var usuario = await _appDbContext.Set<Usuario>().FirstOrDefaultAsync(x => x.Login == login);
            if (usuario is null)
                return null;
            return usuario;
        }

        public async Task<Usuario> AddUsuario(Usuario usuarioToAdd)
        {
            var usuario = await _appDbContext.Set<Usuario>().AddAsync(usuarioToAdd);
            _appDbContext.SaveChanges();
            return usuario.Entity;
        }
    }
}
