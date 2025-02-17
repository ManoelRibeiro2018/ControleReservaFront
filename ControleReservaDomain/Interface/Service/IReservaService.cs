using ControleReserva.Domain.DTOs;
using ControleReserva.Domain.DTOs.Reserva;
using ControleReservaDomain.Enum;

namespace ControleReserva.Domain.Interface.Service
{
    public interface IReservaService
    {
        Task ChangeStatus(int id, Status status);
        Task Create(ReservaInputModel entity);
        Task Update(ReservaInputModel entity);
        Task Delete(int id);
        Task<ReservaViewModel> Get(int id);
        Task<List<ReservaViewModel>> GetAll();
    }
}
