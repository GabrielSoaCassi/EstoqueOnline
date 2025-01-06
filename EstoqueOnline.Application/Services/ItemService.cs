using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Models;
using EstoqueOnline.Infra.Data.Repositories;

namespace EstoqueOnline.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<bool> AddItem(string estoqueId, Item item)
        {
            return await _itemRepository.AddItem(estoqueId, item);
        }
    }
}