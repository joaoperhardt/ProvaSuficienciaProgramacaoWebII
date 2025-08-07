using ProvaSuficiencia.DTO;
using ProvaSuficiencia.Entitys;

namespace ProvaSuficiencia.Contracts.Repository
{
    public interface IComandaRepository
    {
        Task<IEnumerable<Comanda>> GetAll();
        Comanda GetById(int id);
        int Create(ComandaDto comanda);
        bool Update(int comandaId, List<int> produtosId);
        bool Delete(int id);
    }
}
