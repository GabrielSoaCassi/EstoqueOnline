using EstoqueOnline.Domain.Models;

namespace EstoqueOnline.Infra.Data.Repositories
{
    public interface IEstoqueRepository
    {
        public Task Add(Estoque estoque);

        public Task<Estoque> ObterEstoque(string id);

    }
}
