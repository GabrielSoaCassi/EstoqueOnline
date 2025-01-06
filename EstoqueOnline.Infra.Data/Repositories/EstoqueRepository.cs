using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Models;
using EstoqueOnline.Infra.Data.NoSQL;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EstoqueOnline.Infra.Data.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly EstoqueContext _estoqueContext;

        public EstoqueRepository(EstoqueContext estoqueContext)
        {
            _estoqueContext = estoqueContext;
        }

        public async Task Add(Estoque estoque)
        {
            _estoqueContext._estoque.InsertOneAsync(estoque);
        }

        public async Task<Estoque> ObterEstoque(string id)
        {
            var filter = Builders<Estoque>.Filter.Eq("_id",id);
            return await _estoqueContext._estoque.Find(filter).FirstOrDefaultAsync();
        }
    }
}
