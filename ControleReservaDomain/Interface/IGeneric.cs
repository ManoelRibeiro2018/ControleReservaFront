using ControleReserva.Domain.DTOs;

namespace ControleReserva.Domain.Interface
{
    public interface IGeneric<T> where T : class
    {
        Task<Response> Create(T  entity);
        Task<Response> Update(T entity, int id);
        Task<Response> Delete(int id);
        Task<Response> Get(int id);
        Task<List<Response>> GetAll();
    }
}
