using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Application.DTOS;
using EstoqueOnline.Domain.Models;
using EstoqueOnline.Infra.Data.Repositories;

namespace EstoqueOnline.Application.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        public EstoqueService(IEstoqueRepository estoqueRepository) {
            _estoqueRepository = estoqueRepository;
        }
        public async Task AddEstoque(string userId, string localizacao)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var estoqueExistente = await FindEstoque(userId);
                if (estoqueExistente is not null) return;
                var newEstoque = new Estoque(userId,localizacao);
                await _estoqueRepository.Add(newEstoque);
            }
        }

        public async Task<Estoque> FindEstoque(string estoqueId)
        {
            if (string.IsNullOrEmpty(estoqueId)) return null;
            return await _estoqueRepository.ObterEstoque(estoqueId);
        }

       
    }
}
