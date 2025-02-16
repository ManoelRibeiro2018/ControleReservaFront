using ControleReserva.Domain.DTOs;
using ControleReserva.Domain.Model;
using ControleReservaDomain.Enum;

namespace ControleReserva.Domain.Interface.HttpClient
{
    public interface IReservaHttpClient : IGeneric<Reserva>
    {
        Task<Response> ChangeStatus(Status status);
    }
}
