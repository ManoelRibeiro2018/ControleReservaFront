using ControleReservaDomain.DTOs.InputModel;
using ControleReservaDomain.Enum;

namespace ControleReserva.Domain.Interface.Service
{
    public interface IReservaService : IGeneric<ResevaInputModel>
    {
        Task ChangeStatus(Status status);
    }
}
