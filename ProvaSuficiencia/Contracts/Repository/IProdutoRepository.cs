using ProvaSuficiencia.DTO;
using ProvaSuficiencia.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaSuficiencia.Contracts.Repository
{
    public interface IProdutoRepository
    {
        Task Add(ProdutoDto produtoDto);
        Task Update(Produto produto);
        Task Delete(int id);
        Task<IEnumerable<Produto>> GetAll();
        Task<IEnumerable<Produto>> GetByFilter(string filter);
        Task<Produto> GetById(int id);
    }
}
