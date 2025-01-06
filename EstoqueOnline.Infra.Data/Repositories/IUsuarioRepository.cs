using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Models;

namespace EstoqueOnline.Infra.Data.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<Usuario> AddUsuario(Usuario usuario);
        public Task<Usuario> FindUsuarioByLogin(string email);
    }
}
