using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Models;

namespace EstoqueOnline.Application.Services
{
    public interface ITokenService
    {
        string CreateToken(Usuario user);
    }
}
