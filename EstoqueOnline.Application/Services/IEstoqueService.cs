using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Models;

namespace EstoqueOnline.Application.Services
{
    public interface IEstoqueService
    {
        public Task AddEstoque(string userId, string localizacao);
        public Task<Estoque> FindEstoque(string estoqueId);
    }
}
