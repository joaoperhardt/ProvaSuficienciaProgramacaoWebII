using ProvaSuficiencia.DTO;
using ProvaSuficiencia.Entitys;

namespace ProvaSuficiencia.Contracts.Repository
{
    public interface IProdutoRepository
    {
        Task Add(ProdutoDto produtoDto);
        Task Update(Produto produto);
        Task Delete(int id);
        Task<IEnumerable<Produto>> Get();
        Task<IEnumerable<Produto>> GetByFilter(string filter);
        Task<Produto> GetById(int id);
    }
}
