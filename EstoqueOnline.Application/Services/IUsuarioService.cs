using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Application.DTOS;
using EstoqueOnline.Domain.Models;

namespace EstoqueOnline.Application.Services
{
    public interface IUsuarioService
    {
        public Task RegistrarUsuario(UsuarioDTO usuario);
        public Task<string> LogarUsuario(UsuarioLoginDTO usuario);
    }
}
