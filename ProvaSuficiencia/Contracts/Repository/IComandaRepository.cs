using ProvaSuficiencia.DTO;
using ProvaSuficiencia.Entitys;
using System.Collections.Generic;

namespace ProvaSuficiencia.Contracts.Repository
{
    public interface IComandaRepository
    {
        Task<IEnumerable<Comanda>> GetAll();
        Comanda GetById(int id);
        Comanda Add(ComandaDto comanda);
        bool Update(int comandaId, List<int> produtosId);
        string Delete(int id);
    }
}
