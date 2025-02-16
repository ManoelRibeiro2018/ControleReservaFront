using ControleReserva.Domain.DTOs;
using ControleReserva.Domain.DTOs.Reserva;
using ControleReservaDomain.Enum;

namespace ControleReserva.Domain.Interface.Service
{
    public interface IReservaService : IGeneric<ResevaInputModel>
    {
        Task<Response> ChangeStatus(Status status);
    }
}
