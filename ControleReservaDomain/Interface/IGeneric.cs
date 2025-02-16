namespace ControleReserva.Domain.Interface
{
    public interface IGeneric<T> where T : class
    {
        Task Create(T  entity);
        Task Update(T entity, int id);
        Task Delete(int id);
        Task<T> Get(int id);
        Task<List<T>> GetAll();
    }
}
