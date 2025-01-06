using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Models;
using EstoqueOnline.Infra.Data.NoSQL;
using MongoDB.Driver;

namespace EstoqueOnline.Infra.Data.Repositories
{
    public class ItemRepository:IItemRepository
    {
        private readonly EstoqueContext _estoqueContext;

        public ItemRepository(EstoqueContext estoqueContext)
        {
            _estoqueContext = estoqueContext;
        }

        public async Task<bool> AddItem(string estoqueId, Item item)
        {
            var filter = Builders<Estoque>.Filter.Eq("_id", estoqueId);

            var update = Builders<Estoque>.Update.Push(e => e.Items, item);
            var resultado = await _estoqueContext._estoque.UpdateOneAsync(filter, update);
            return resultado.ModifiedCount > 0;
        }

    }
}
